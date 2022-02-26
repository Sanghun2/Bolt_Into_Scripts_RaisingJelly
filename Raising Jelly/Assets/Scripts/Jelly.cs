using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ �ൿ�� �����ϴ� Ŭ����. by����
[RequireComponent(typeof(CircleCollider2D), typeof(Animator))]
public class Jelly : MonoBehaviour
{
    [Header("�ɷ�ġ")]
    [SerializeField] float moveSpeed;
    [SerializeField] int id;
    [SerializeField] int level;
    float exp;
    int maxExp; //�ʿ� ����ġ
    bool isWalk; //�ȴ� ������ �Ǵ�
    float speedX, speedY; //�������� ���ǵ�
    float speedWeight => 0.8f; //��迡�� �ǵ��� �� �� �ӵ� ������

    float pickTime;
    bool isPicked; //������ ��ġ �������� ����
    bool isPicking; //������ �巡�׷� �̵������� ����

    Animator anim;
    SpriteRenderer spriteRenderer;
    Vector3 correctedValue; //�巡�� �� ���� ������ ���̵��� �����ϴ� ��


   [Header("�Ŵ���")][Space(15f)]
    [SerializeField] GameManager gameManager;

    void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        correctedValue = new Vector3(0, 0, -5);
    }

    void Start()
    {
        StartCoroutine(Think());
        SetMaxExp(CurLevel()*JellyManager.instance.MaxExpPerLevel());
    }

    void Update()
    {
        Move();

        //�ð��� ���� ����ġ ��������. by����_22.02.21
        //���� üũ�ؼ� ������ 3���� ������ ����ġ ȹ��
        if (level < 3)
        {
            exp += Time.deltaTime;
            //����ġ�� ������ġ�� ������ �� ������ �Լ� ����
            CheckExp();
        }

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

    #region ������ �̵����� ����
    //������ ����� �ӵ��� ���� �̵��ϴ� ���. by����_22.02.13
    void Move()
    {
        //�̵�
        transform.Translate(speedX*Time.deltaTime, speedY * Time.deltaTime, speedY * Time.deltaTime);
        //��迡 ���� �� �߾����� �̵�
        if(IsBorder())
        {
            Vector3 direction = (gameManager.GetPositon(1) - transform.position).normalized;
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
        if (transform.position.x < gameManager.GetPositon(0).x || transform.position.x > gameManager.GetPositon(2).x ||
             transform.position.y > gameManager.GetPositon(0).y || transform.position.y < gameManager.GetPositon(2).y)
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
        //��ȭ����
        GoodsManager.instance.GetJellatine((id+1)*level);
        //����ġ����
        if (level < 3) exp++;
        //��ġ �ִϸ��̼� ����
        anim.SetTrigger("doTouch");
        StopMove();
    }

    //���� ��� Ŭ���� �߻��ϴ� �̺�Ʈ. by����_22.02.26
    void OnMouseDrag()
    {
        isPicked = true;
    }

    //������ ������ �� �߻��ϴ� �̺�Ʈ. by����_22.02.26
    void OnMouseUp()
    {
        //�ǸŻ��¸� �Ǹ� ����
        if (SellManager.instance.IsSellable())
        {
            int price = SellManager.instance.GetJellyPrice(id);
            price *= level;
            GoodsManager.instance.GetGold(price);

            //�Ǹ� �� �����ı�
            Destroy(gameObject);
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
    //���� ������ ��ȯ�ϴ� ���. by����_22.02.21
    public int CurLevel() => level;
    //���� ������ �����ϴ� ���. by����_22.02.21
    public void SetLevel(int value) => level = value;
    //������ ID ��ȯ�ϴ� ���. by����_22.02.21
    public int ID() => id;
    //������ ���� ����ġ ��ȯ. by����_22.02.21
    public float CurExp() => exp;
    //������ ���� ����ġ ����. by����_22.02.21
    public void SetExp(int value) => exp = value;
    //������ �ʿ� ����ġ ����. by����_22.02.21
    public void SetMaxExp(int value) => maxExp = value;
    #endregion

    #region ���� ������ ���� ���
    //������ ��Ʈ�ѷ� ����. by����_22.02.21
    public void SetController(RuntimeAnimatorController rc) => anim.runtimeAnimatorController = rc;

    //������ ���� ����ġ�� ������ġ�� �����ߴ��� üũ�ϴ� �Լ�. by����_22.02.21
    void CheckExp()
    {
        //���� ������ ����ġ üũ => ������ġ ���޽� ������
        if (level < 3 && exp > maxExp) JellyManager.instance.LevelUp(this);
    }
    #endregion
}
