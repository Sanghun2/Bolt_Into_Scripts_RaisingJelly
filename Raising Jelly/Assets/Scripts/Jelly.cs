using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//젤리의 행동을 관리하는 클래스. by상훈
public class Jelly : MonoBehaviour
{
    [Header("능력치")]
    [SerializeField] float moveSpeed;
    bool isWalk;
    float speedX, speedY;
    float speedWeight => 0.3f; //경계에서 되돌아 갈 때 속도 보정값

    Animator anim;
    SpriteRenderer spriteRenderer;

    [Header("매니저")][Space(15f)]
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
    //정해진 방향과 속도에 따라 이동하는 기능. by상훈_22.02.13
    void Move()
    {
        //이동
        transform.Translate(speedX*Time.deltaTime, speedY * Time.deltaTime, speedY * Time.deltaTime);
        //경계에 닿을 때 중앙으로 이동
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
    //이동과 정지 중 다음 행동을 판단하는 함수. by상훈_22.02.13
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
    //이동속도를 0으로 만드는 기능. by상훈_22.02.13
    void Stop()
    {
        isWalk = false;
        anim.SetBool("isWalk", isWalk);
        speedX = 0;
        speedY = 0;
    }
    //이동할 때 방향과 속도를 정하는 기능. by상훈_22.02.13
    void Walk()
    {
        isWalk = true;
        anim.SetBool("isWalk", isWalk);
        speedX = Random.Range(-moveSpeed, moveSpeed);
        speedY = Random.Range(-moveSpeed, moveSpeed);
        ChangeLookDirection();
    }
    //이동하는 방향에 따라 보는 방향을 바꾸는 기능. by상훈_22.02.13
    void ChangeLookDirection()
    {
        if (speedX < 0) spriteRenderer.flipX = true;
        else spriteRenderer.flipX = false;
    }
}
