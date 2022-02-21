using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ �ൿ�� �����ϴ� Ŭ����. by����
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

    Animator anim;
    SpriteRenderer spriteRenderer;

    [Header("�Ŵ���")][Space(15f)]
    [SerializeField] GameManager gameManager;

    void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
    }
    //������ ����� �ӵ��� ���� �̵��ϴ� ���. by����_22.02.13
    void Move()
    {
        //�̵�
        transform.Translate(speedX*Time.deltaTime, speedY * Time.deltaTime, speedY * Time.deltaTime);
        //��迡 ���� �� �߾����� �̵�
        if(transform.position.x < gameManager.GetPositon(0).x || transform.position.x > gameManager.GetPositon(2).x ||
             transform.position.y > gameManager.GetPositon(0).y ||transform.position.y < gameManager.GetPositon(2).y)
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

    //������ ��Ʈ�ѷ� ����. by����_22.02.21
    public void SetController(RuntimeAnimatorController rc) => anim.runtimeAnimatorController = rc;

    //������ ���� ����ġ�� ������ġ�� �����ߴ��� üũ�ϴ� �Լ�. by����_22.02.21
    void CheckExp()
    {
        //���� ������ ����ġ üũ => ������ġ ���޽� ������
        if (level < 3 && exp > maxExp) JellyManager.instance.LevelUp(this);
    }
}
