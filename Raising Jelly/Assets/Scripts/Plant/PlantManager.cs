using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
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
            GoodsManager.Instance.UseGold(cost);
            GameData.Instance.AddNumLevel(1);
            PageRenewer.Instance.RenewPlantPage();
        }
    }
    public void UpgradeClick()
    {
        int cost = numCostList[GameData.Instance.ClickLevel];
        if (cost <= GoodsManager.GoldIHave())
        {
            GoodsManager.Instance.UseGold(cost);
            GameData.Instance.AddClickLevel(1);
            PageRenewer.Instance.RenewPlantPage();
        }
    }
    #endregion

    #region 시작시 초기화
    public void InitSkillLevel()
    {
        PageRenewer.Instance.RenewPlantPage();
    }
    #endregion
}
