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
    [SerializeField] SoundManager soundManager;
    [SerializeField] NoticeManager noticeManager;
    [SerializeField] UIManager uiManager;

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
        if(jellyManager.CurJellyCount >= gameData.NumberLevel * 2)
        {
            noticeManager.ShowMessage(NoticeManager.Message.NotEnoughCap);
            return;
        }

        int num = pageSwitcher.GetIndex();
        int amount = JellyManager.Instance.ReqiredGold(num);
        int id = PageSwitcher.Instance.GetIndex() - 1;
        //충분한 젤라틴을 가졌는지 체크
        if (GoodsManager.GoldIHave() >= amount)
        {
            //재화 처리
            GoodsManager.Instance.UseGold(amount);
            soundManager.PlayBuySound();
            //젤리생성
            JellyManager.Instance.CreateJelly(id);
        }
        else
        {
            soundManager.PlayFailSound();
            noticeManager.ShowMessage(NoticeManager.Message.NotEnoughGold);
        }
    }
    #endregion
    #region 젤라틴
    //젤리를 해금. by상훈_22.03.11
    public void UnlockJelly()
    {
        int curIndex = pageSwitcher.GetIndex();
        int amount = JellyManager.Instance.ReqiredJellatine(curIndex);
        //충분한 젤라틴을 가졌는지 체크
        if (GoodsManager.JellatineIHave() >= amount)
        {
            //재화 처리
            GoodsManager.Instance.UseJellatine(amount);
            //젤리 해금
            GameData.Instance.SetUnlockData(curIndex, true);
            soundManager.PlayUnlockSound();
            //새로고침
            if(curIndex == jellyManager.GetAllJellyCount())
            {
                uiManager.ShowClearBadge(true);
            }
            PageRenewer.Instance.RenewPage(curIndex);
        }
        else
        {
            soundManager.PlayFailSound();
            noticeManager.ShowMessage(NoticeManager.Message.NotEnoughJellatine);
        }
    }
    #endregion
    #region 데이터 관리
    //해당 인덱스의 젤리 구매 가격 반환. by상훈_22.04.03
    public int GetPriceOfJelly(int index) => requiredGoldList[index];
    #endregion
}