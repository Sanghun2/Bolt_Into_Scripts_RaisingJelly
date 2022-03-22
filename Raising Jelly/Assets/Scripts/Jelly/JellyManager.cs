using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//젤리들의 상태를 관리하는 클래스
public class JellyManager : MonoBehaviour
{
    [Header("젤리 데이터")]
    public List<string> jellyNameList = new List<string>();
    public List<Sprite> jellyImageList = new List<Sprite>();
    public float[] shadowPos;
    static int numOfJelly;

    [Header("젤리 생성")]
    [Space(15f)]
    [Tooltip("젤리 프리펩")]
    [SerializeField] GameObject jellyPrefab;
    [Tooltip("생성되는 위치")]
    [SerializeField] Transform spawnPoint;

    [Header("생성된 젤리 리스트")]
    [Space(15f)]
    List<GameObject> jellyList = new List<GameObject>();

    [Header("젤리의 애니메이션 컨트롤러")][Space(15f)]
    [Tooltip("젤리의 크기를 결정하는 애니메이션 컨트롤러다.")]
    [SerializeField] RuntimeAnimatorController[] controller;
    int maxExpPerLevel => 30;

    static JellyManager instance;
    public static JellyManager Instance => instance;

    void Awake()
    {
        instance = this;
        numOfJelly = jellyNameList.Count;
    }

    #region 젤리 상태
    //젤리 레벨업 기능. by상훈_22.02.21
    public void LevelUp(Jelly jelly)
    {
        //3일때는 레벨업X
        if (jelly.CurLevel == 3) return;

        //3이 아니라면 레벨업
        jelly.SetLevel(jelly.CurLevel + 1);
        //경험치 초기화
        jelly.SetExp(0);
        //필요 경험치 설정
        jelly.SetMaxExp(jelly.CurLevel*maxExpPerLevel);
        //젤리의 사이즈 변경
        jelly.SetController(ChangeController(jelly.CurLevel));
    }

    //젤리의 컨트롤러를 변경하는 기능. by상훈_22.02.21
    public RuntimeAnimatorController ChangeController(int level) => controller[level-1];

    #endregion

    #region 젤리 생성
    //젤리생성. by상훈_22.03.14
    public void CreateJelly(int id)
    {
        GameObject jelly = Instantiate(jellyPrefab, spawnPoint);
        Jelly jellyInfo = jelly.GetComponent<Jelly>();
        Animator jellyAnim = jelly.GetComponent<Animator>();
        SpriteRenderer jellySprite = jelly.GetComponent<SpriteRenderer>();
        jellyInfo.SetID(id);
        jellyInfo.SetLevel(1);
        jellyInfo.SetExp(0);
        jellyInfo.SetMaxExp(jellyInfo.CurLevel * maxExpPerLevel);

        jellyAnim.runtimeAnimatorController = controller[jellyInfo.CurLevel - 1];
        jellySprite.sprite = jellyImageList[id];

        AddJellyToList(jelly);
        GameData.Instance.SaveJellyAll(jellyList);
    }

    //생성된 젤리 리스트에 추가. by상훈_22.03.16
    public void AddJellyToList(GameObject jellyObj)
    {
        jellyList.Add(jellyObj);
    }

    //판매된 젤리 리스트에서 제거. by상훈_22.03.16
    public void RemoveJellyFromList(GameObject jellyObj)
    {
        jellyList.Remove(jellyObj);
    }
    #endregion

    #region 젤리 정보
    //레벨당 필요한 경험치를 반환하는 함수. by상훈_22.02.21
    public int MaxExpPerLevel() => maxExpPerLevel;
    //전체 젤리의 수를 반환하는 함수. by상훈_22.03.10
    public static int HowManyJelly() => numOfJelly;
    //특정 젤리 해금에 필요한 값 반환. by상훈_22.03.10
    public int ReqiredJellatine(int index) => BuyManager.Instance.requiredJellatineList[index - 1];
    public int ReqiredGold(int index) => BuyManager.Instance.requiredGoldList[index - 1];
    
    //젤리 그림자의 위차값 반환. by상훈_22.03.14
    public float GetShadowPos(int id){
        switch (id)
        {
            case 0:
                return shadowPos[0];
            case 3:
                return shadowPos[1];
            case 6:
                return shadowPos[2];
            case 10:
            case 11:
            default:
                return shadowPos[3];
        }
    }

    //현재 젤리 리스트 반환. by상훈_22.03.16
    public List<GameObject> GetJellyList() => jellyList;
    //현재 젤리 수 반환
    public int CurJellyCount => jellyList.Count;
    #endregion
}
