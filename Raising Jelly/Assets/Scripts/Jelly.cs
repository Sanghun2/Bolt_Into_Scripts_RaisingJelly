using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ �ൿ�� �����ϴ� Ŭ����. by����
public class Jelly : MonoBehaviour
{
    [Header("�ɷ�ġ")]
    [SerializeField] float moveSpeed;
    bool isWalk;
    float speedX, speedY;
    float speedWeight => 0.3f; //��迡�� �ǵ��� �� �� �ӵ� ������

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
    }

    void Update()
    {
        Move();
    }
    //������ ����� �ӵ��� ���� �̵��ϴ� ���. by����_22.02.13
    void Move()
    {
        //�̵�
        transform.Translate(speedX*Time.deltaTime, speedY * Time.deltaTime, speedY * Time.deltaTime);
        //��迡 ���� �� �߾����� �̵�
        if(transform.position.x > gameManager.GetPositon(2).x ||
            transform.position.x < gameManager.GetPositon(0).x ||
            transform.position.y < gameManager.GetPositon(2).y ||
            transform.position.y > gameManager.GetPositon(0).y)
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
}
