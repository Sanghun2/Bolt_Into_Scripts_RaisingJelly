using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//구매를 관리하는 클래스
public class BuyManager : MonoBehaviour
{
    [Header("매니저")]
    [SerializeField] PageSwitcher pageSwitcher;

    #region 골드

    #endregion

    #region 젤라틴
    //젤리를 해금하는 기능. by상훈_22.03.11
    public void UnlockJelly()
    {
        int num = pageSwitcher.GetIndex();
        int amount = JellyManager.instance.ReqiredJellatine(num);
        //충분한 젤라틴을 가졌는지 체크
        if (GoodsManager.JellatineIHave() >= amount)
        {
            //재화 처리
            GoodsManager.instance.UseJellatine(amount);
            //젤리 해금
            GameData.instance.SetUnlockData(num, true);
            //새로고침
            PageRenewer.instance.RenewPage(num);
        }
    }
    #endregion
}
