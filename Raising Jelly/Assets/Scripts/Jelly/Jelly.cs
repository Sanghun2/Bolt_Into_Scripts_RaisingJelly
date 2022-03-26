using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ �ൿ�� �����ϴ� Ŭ����. by����
[RequireComponent(typeof(CircleCollider2D), typeof(Animator))]
public class Jelly : MonoBehaviour
{
    [Header("�ɷ�ġ")]
    int id;
    int level;
    float exp;
    int maxExp; //�ʿ� ����ġ

    bool isWalk; //�ȴ� ������ �Ǵ�
    float moveSpeed => 1;
    float speedX, speedY; //�������� ���ǵ�
    float speedWeight => 0.8f; //��迡�� �ǵ��� �� �� �ӵ� ������

    float pickTime;
    bool isPicked; //������ ��ġ �������� ����
    bool isPicking; //������ �巡�׷� �̵������� ����

    //��ȭ ȹ�� �ֱ�
    float gainTime;

    Animator anim;
    SpriteRenderer spriteRenderer;
    Vector3 correctedValue; //�巡�� �� ���� ������ ���̵��� �����ϴ� ��
    Transform shaodwPos;

    void Update()
    {
        Move();
        gainTime += Time.deltaTime;

        //�ð��� ���� ����ġ ��������. by����_22.02.21
        //���� üũ�ؼ� ������ 3���� ������ ����ġ ȹ��
        if (level < 3)
        {
            exp += Time.deltaTime;
            //����ġ�� ������ġ�� ������ �� ������ �Լ� ����
            CheckExp();
        }

        //���� �ð����� ����ƾ ȹ��
        if(gainTime >= 5)
        {
            GoodsManager.Instance.GetJellatine((id + 1) * level * GameData.Instance.ClickLevel);
            gainTime = 0;
        }

        //�����ð� ��ġ �����ϴ� ��� �巡�� ����. by����
        if (isPicked)
        {
            pickTime += Time.deltaTime;
            if (pickTime >= 0.1f)
            {
                isPicking = true;
                transform.position = (Vector3)CoordinateGetter.GetTouchPos() + correctedValue;
            }
        }
    }

    private void OnEnable() {
        //�⺻ ���� ����
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        shaodwPos = GetComponentInChildren<Transform>();
        correctedValue = new Vector3(0, 0, -5);
        SetMaxExp(CurLevel * JellyManager.Instance.MaxExpPerLevel());

        //�׸��� ��ġ ����
        shaodwPos.position = new Vector3(0, JellyManager.Instance.GetShadowPos(id), 0);

        //�̵�����
        StartCoroutine(Think());
    }

    #region ������ �̵����� ����
    //������ ����� �ӵ��� ���� �̵��ϴ� ���. by����_22.02.13
    void Move()
    {
        //�̵�
        transform.Translate(speedX*Time.deltaTime, speedY * Time.deltaTime, speedY * Time.deltaTime);
        //��迡 ���� �� �߾����� �̵�
        if(IsBorder())
        {
            Vector3 direction = (GameManager.Instance.GetPositon(1) - transform.position).normalized;
            speedX = direction.x * speedWeight;
            speedY = direction.y * speedWeight;
            ChangeLookDirection();
        }
    }
    //�̵��� ���� �� ���� �ൿ�� �Ǵ��ϴ� �Լ�. by����_22.02.13
    IEnumerator Think()
    {
        int action = Random.Range(0, 3);
        switch (action)
        {
            case 0:
            case 1:
                Stop();
                break;
            case 2:
                Walk();
                break;                
            default:
                break;
        }

        float waitForThinking = Random.Range(1f, 3f);
        yield return new WaitForSeconds(waitForThinking);
        StartCoroutine(Think());
    }
    //�̵��ӵ��� 0���� ����� ���. by����_22.02.13
    void Stop()
    {
        isWalk = false;
        anim.SetBool("isWalk", isWalk);
        speedX = 0;
        speedY = 0;
    }
    //�̵��� �� ����� �ӵ��� ���ϴ� ���. by����_22.02.13
    void Walk()
    {
        isWalk = true;
        anim.SetBool("isWalk", isWalk);
        speedX = Random.Range(-moveSpeed, moveSpeed);
        speedY = Random.Range(-moveSpeed, moveSpeed);
        ChangeLookDirection();
    }
    //�̵��ϴ� ���⿡ ���� ���� ������ �ٲٴ� ���. by����_22.02.13
    void ChangeLookDirection()
    {
        if (speedX < 0) spriteRenderer.flipX = true;
        else spriteRenderer.flipX = false;
    }
    #endregion

    #region ������ ��ġ �Ǵ��ϴ� ����
    //������ ��ġ�� ��踦 �Ѿ���� üũ�ϴ� ����. by����_22.02.26
    bool IsBorder()
    {
        if (transform.position.x < GameManager.Instance.GetPositon(0).x || transform.position.x > GameManager.Instance.GetPositon(2).x ||
             transform.position.y > GameManager.Instance.GetPositon(0).y || transform.position.y < GameManager.Instance.GetPositon(2).y)
        {
            return true;
        }
        else return false;
    }
    #endregion

    #region ��ġ�� �߻��ϴ� ����
    //���� Ŭ���� �߻��ϴ� �̺�Ʈ. by����_22.02.21
    void OnMouseDown()
    {
        if (WindowManager.IsOptionOn()) return;

        //��ȭ����
        GoodsManager.Instance.GetJellatine((id+1)*level*GameData.Instance.ClickLevel);
        //����ġ����
        if (level < 3) exp++;

        SoundManager.Instance.PlayTouchSound();
        //��ġ �ִϸ��̼� ����
        anim.SetTrigger("doTouch");
        StopMove();
    }

    //���� ��� Ŭ���� �߻��ϴ� �̺�Ʈ. by����_22.02.26
    void OnMouseDrag()
    {
        if (WindowManager.IsOptionOn()) return;

        isPicked = true;
    }

    //������ ������ �� �߻��ϴ� �̺�Ʈ. by����_22.02.26
    void OnMouseUp()
    {
        if (WindowManager.IsOptionOn()) return;

        //�ǸŻ��¸� �Ǹ� ����
        if (SellManager.Instance.IsSellable())
        {
            SellManager.Instance.SellJelly(gameObject);
        }
        else //�ƴϸ� ����ġ
        {
            pickTime = 0;
            isPicking = false;
            isPicked = false;

            //z���� �� ��������
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);

            //������ ��ġ�� ������ �����ͼ� �������� �ǵ�����
            if (IsBorder())
            {
                transform.position = transform.parent.position;
            }

            //���� ������ �̵����̸� �̵� �ִϸ��̼����� �ٲ��ֱ�
            if (speedX != 0 || speedY != 0)
            {
                isWalk = true;
                anim.SetBool("isWalk", isWalk);
            }
        }
    }

    //Ŭ���� �̵����� ���. by����_22.02.21
    void StopMove()
    {
        StopAllCoroutines();
        Stop();
        StartCoroutine(Re_Move());
    }

    //���̵� ��� �ڷ�ƾ. by����_22.02.21
    IEnumerator Re_Move()
    {
        yield return new WaitForSeconds(Random.Range(2, 4f));
        StartCoroutine(Think());
    }
    #endregion

    #region ������ ���� �ٷ�� ���
    //����
    //id ����. by����_22.03.14
    public void SetID(int value) => id = value;
    //���� ������ �����ϴ� ���. by����_22.02.21
    public void SetLevel(int value) => level = value;
    //������ ���� ����ġ ����. by����_22.02.21
    public void SetExp(int value) => exp = value;
    //������ �ʿ� ����ġ ����. by����_22.02.21
    public void SetMaxExp(int value) => maxExp = value;

    //��ȯ
    //������ ID ��ȯ�ϴ� ���. by����_22.02.21
    public int ID => id;
    //���� ������ ��ȯ�ϴ� ���. by����_22.02.21
    public int CurLevel => level;
    //������ ���� ����ġ ��ȯ. by����_22.02.21
    public float CurExp => exp;
    #endregion

    #region ���� ������ ���� ���
    //������ ��Ʈ�ѷ� ����. by����_22.02.21
    public void SetController(RuntimeAnimatorController rc) => anim.runtimeAnimatorController = rc;

    //������ ���� ����ġ�� ������ġ�� �����ߴ��� üũ�ϴ� �Լ�. by����_22.02.21
    void CheckExp()
    {
        //���� ������ ����ġ üũ => ������ġ ���޽� ������
        if (level < 3 && exp > maxExp) JellyManager.Instance.LevelUp(this);
    }
    #endregion
}
