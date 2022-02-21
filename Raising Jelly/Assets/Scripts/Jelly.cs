using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//젤리의 행동을 관리하는 클래스. by상훈
public class Jelly : MonoBehaviour
{
    [Header("능력치")]
    [SerializeField] float moveSpeed;
    [SerializeField] int id;
    [SerializeField] int level;
    float exp;
    int maxExp; //필요 경험치
    bool isWalk; //걷는 중인지 판단
    float speedX, speedY; //걸을때의 스피드
    float speedWeight => 0.8f; //경계에서 되돌아 갈 때 속도 보정값

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
        SetMaxExp(CurLevel()*JellyManager.instance.MaxExpPerLevel());
    }

    void Update()
    {
        Move();

        //시간에 따라 경험치 증가로직. by상훈_22.02.21
        //레벨 체크해서 레벨이 3보다 작으면 경험치 획득
        if (level < 3)
        {
            exp += Time.deltaTime;
            //경험치가 일정수치에 도달할 시 레벨업 함수 실행
            CheckExp();
        }
    }
    //정해진 방향과 속도에 따라 이동하는 기능. by상훈_22.02.13
    void Move()
    {
        //이동
        transform.Translate(speedX*Time.deltaTime, speedY * Time.deltaTime, speedY * Time.deltaTime);
        //경계에 닿을 때 중앙으로 이동
        if(transform.position.x < gameManager.GetPositon(0).x || transform.position.x > gameManager.GetPositon(2).x ||
             transform.position.y > gameManager.GetPositon(0).y ||transform.position.y < gameManager.GetPositon(2).y)
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

    //젤리 클릭시 발생하는 이벤트. by상훈_22.02.21
    void OnMouseDown()
    {
        //재화증가
        GoodsManager.instance.GetJellatine((id+1)*level);
        //경험치증가
        if (level < 3) exp++;
        //터치 애니메이션 실행
        anim.SetTrigger("doTouch");
        StopMove();
    }

    //클릭시 이동정지 기능. by상훈_22.02.21
    void StopMove()
    {
        StopAllCoroutines();
        Stop();
        StartCoroutine(Re_Move());
    }

    //재이동 기능 코루틴. by상훈_22.02.21
    IEnumerator Re_Move()
    {
        yield return new WaitForSeconds(Random.Range(2, 4f));
        StartCoroutine(Think());
    }

    //현재 레벨값 반환하는 기능. by상훈_22.02.21
    public int CurLevel() => level;
    //현재 레벨값 셋팅하는 기능. by상훈_22.02.21
    public void SetLevel(int value) => level = value;

    //젤리의 ID 반환하는 기능. by상훈_22.02.21
    public int ID() => id;

    //젤리의 현재 경험치 반환. by상훈_22.02.21
    public float CurExp() => exp;
    //젤리의 현재 경험치 설정. by상훈_22.02.21
    public void SetExp(int value) => exp = value;
    //젤리의 필요 경험치 설정. by상훈_22.02.21
    public void SetMaxExp(int value) => maxExp = value;

    //젤리의 컨트롤러 변경. by상훈_22.02.21
    public void SetController(RuntimeAnimatorController rc) => anim.runtimeAnimatorController = rc;

    //젤리의 현재 경험치가 일정수치에 도달했는지 체크하는 함수. by상훈_22.02.21
    void CheckExp()
    {
        //현재 레벨과 경험치 체크 => 일정수치 도달시 레벨업
        if (level < 3 && exp > maxExp) JellyManager.instance.LevelUp(this);
    }
}
