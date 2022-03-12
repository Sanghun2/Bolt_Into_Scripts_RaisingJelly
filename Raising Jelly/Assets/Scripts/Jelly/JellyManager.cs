using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//젤리의 상태를 관리하는 클래스
public class JellyManager : MonoBehaviour
{
    [Header("젤리에 대한 데이터")]
    public List<string> jellyNameList = new List<string>();
    public List<int> requiredJellatineList = new List<int>();
    public List<Sprite> jellyImageList = new List<Sprite>();
    static int numOfJelly;

    [Header("젤리의 애니메이션 컨트롤러")][Space(15f)]
    [Tooltip("젤리의 크기를 결정하는 애니메이션 컨트롤러다.")]
    [SerializeField] RuntimeAnimatorController[] controller;
    int maxExpPerLevel => 30;

    public static JellyManager instance;

    void Awake()
    {
        instance = this;
        numOfJelly = jellyNameList.Count;
    }

    #region 젤리 상태 관리
    //젤리 레벨업 기능. by상훈_22.02.21
    public void LevelUp(Jelly jelly)
    {
        //3일때는 레벨업X
        if (jelly.CurLevel() == 3) return;

        //3이 아니라면 레벨업
        jelly.SetLevel(jelly.CurLevel() + 1);
        //경험치 초기화
        jelly.SetExp(0);
        //필요 경험치 설정
        jelly.SetMaxExp(jelly.CurLevel()*maxExpPerLevel);
        //젤리의 사이즈 변경
        jelly.SetController(ChangeController(jelly.CurLevel()));
    }

    //젤리의 컨트롤러를 변경하는 기능. by상훈_22.02.21
    public RuntimeAnimatorController ChangeController(int level) => controller[level-1];

    #endregion

    #region 젤리 정보 관리
    //레벨당 필요한 경험치를 반환하는 함수. by상훈_22.02.21
    public int MaxExpPerLevel() => maxExpPerLevel;
    //전체 젤리의 수를 반환하는 함수. by상훈_22.03.10
    public static int HowManyJelly() => numOfJelly;
    //특정 젤리 해금에 필요한 값 반환. by상훈_22.03.10
    public int ReqiredJellatine(int index) => requiredJellatineList[index - 1];
    #endregion
}
