using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public enum CostType { Number, Click}
    public CostType costType;

    [Header("업그레이드 비용")]
    [SerializeField] int[] numCostList;
    [SerializeField] int[] clickCostList;

    static PlantManager instance;
    public static PlantManager Instance => instance;

    void Awake()
    {
        instance = this;
    }

    #region 스킬 업그레이드
    public void UpgradeNum()
    {
        int cost = numCostList[GameData.Instance.NumberLevel];
        if (cost <= GoodsManager.GoldIHave())
        {
            GoodsManager.Instance.UseGold(cost); //재화차감
            GameData.Instance.AddNumLevel(1); //레벨업
            costType = CostType.Number;
            PageRenewer.Instance.RenewPlantPage(costType); //페이지 갱신
        }
    }
    public void UpgradeClick()
    {
        int cost = numCostList[GameData.Instance.ClickLevel];
        if (cost <= GoodsManager.GoldIHave())
        {
            GoodsManager.Instance.UseGold(cost);
            GameData.Instance.AddClickLevel(1);
            costType = CostType.Click;
            PageRenewer.Instance.RenewPlantPage(costType);
        }
    }
    #endregion

    #region 시작시 초기화
    public void InitSkillLevel()
    {
        PageRenewer.Instance.RenewPlantPage();
    }
    #endregion

    #region 데이터 관리
    public int GetNumCost(int index) => numCostList[index];
    public int GetClickCost(int index) => clickCostList[index];
    #endregion
}
