using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellManager : MonoBehaviour
{
    bool isSell;

    [Header("젤리가격")]
    [SerializeField] int[] jellyPrice;

    static SellManager instance;
    public static SellManager Instance => instance;

    void Awake()
    {
        instance = this;
    }

    #region 판매가능여부 판단
    //터치가 판매버튼 위에 들어갔을 때 실행. by상훈_22.02.26
    public void GetInToButton()
    {
        isSell = true;
    }

    //터치가 판매버튼에서 나왔을 때 실행. by상훈_22.02.26
    public void GetOutFromButton()
    {
        isSell = false;
    }
    #endregion
    #region 판매 기능
    //젤리 판매. by상훈_22.03.16
    public void SellJelly(GameObject targetJelly)
    {
        Jelly jellyInfo = targetJelly.GetComponent<Jelly>();
        int price = GetJellyPrice(jellyInfo.ID);
        price *= jellyInfo.CurLevel;
        GoodsManager.Instance.GetGold(price);
        //리스트에서 제거
        JellyManager.Instance.RemoveJellyFromList(targetJelly);
        //저장할 데이터 수정
        GameData.Instance.SaveJellyAll(JellyManager.Instance.GetJellyList());
        //판매 후 젤리파괴
        Destroy(targetJelly);
    }
    #endregion
    #region 판매 정보 관리
    //판매가능 상태 반환하는 기능. by상훈_22.02.26
    public bool IsSellable() => isSell;

    //젤리가격 반환하는 기능. by상훈_22.02.26
    public int GetJellyPrice(int id) => jellyPrice[id];
    #endregion
}
