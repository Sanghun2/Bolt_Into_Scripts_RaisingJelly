using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//구매를 관리하는 클래스
public class BuyManager : MonoBehaviour
{
    [Header("젤리 구매 데이터")]
    public List<int> requiredJellatineList = new List<int>();
    public List<int> requiredGoldList = new List<int>();

    [Header("매니저")][Space(15f)]
    [SerializeField] PageSwitcher pageSwitcher;
    [SerializeField] JellyManager jellyManager;
    [SerializeField] GameData gameData;

    private static BuyManager instance;
    public static BuyManager Instance => instance;

    void Awake()
    {
        instance = this;
    }

    #region 골드
    //젤리를 구매. by상훈_22.03.14
    public void BuyJelly()
    {
        if(jellyManager.CurJellyCount >= gameData.NumberLevel*2) return;

        int num = pageSwitcher.GetIndex();
        int amount = JellyManager.Instance.ReqiredGold(num);
        int id = PageSwitcher.Instance.GetIndex() - 1;
        //충분한 젤라틴을 가졌는지 체크
        if (GoodsManager.GoldIHave() >= amount)
        {
            //재화 처리
            GoodsManager.Instance.UseGold(amount);
            //젤리생성
            JellyManager.Instance.CreateJelly(id);
        }
    }
    #endregion

    #region 젤라틴
    //젤리를 해금. by상훈_22.03.11
    public void UnlockJelly()
    {
        int num = pageSwitcher.GetIndex();
        int amount = JellyManager.Instance.ReqiredJellatine(num);
        //충분한 젤라틴을 가졌는지 체크
        if (GoodsManager.JellatineIHave() >= amount)
        {
            //재화 처리
            GoodsManager.Instance.UseJellatine(amount);
            //젤리 해금
            GameData.Instance.SetUnlockData(num, true);
            //새로고침
            PageRenewer.Instance.RenewPage(num);
        }
    }
    #endregion
}
