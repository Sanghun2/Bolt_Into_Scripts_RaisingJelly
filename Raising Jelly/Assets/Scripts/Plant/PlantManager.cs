using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public enum CostType { Number, Click}
    public CostType costType;

    [Header("���׷��̵� ���")]
    [SerializeField] int[] numCostList;
    [SerializeField] int[] clickCostList;

    static PlantManager instance;
    public static PlantManager Instance => instance;

    void Awake()
    {
        instance = this;
    }

    #region ��ų ���׷��̵�
    public void UpgradeNum()
    {
        int cost = numCostList[GameData.Instance.NumberLevel];
        if (cost <= GoodsManager.GoldIHave())
        {
            GoodsManager.Instance.UseGold(cost); //��ȭ����
            GameData.Instance.AddNumLevel(1); //������
            costType = CostType.Number;
            PageRenewer.Instance.RenewPlantPage(costType); //������ ����
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

    #region ���۽� �ʱ�ȭ
    public void InitSkillLevel()
    {
        PageRenewer.Instance.RenewPlantPage();
    }
    #endregion

    #region ������ ����
    public int GetNumCost(int index) => numCostList[index];
    public int GetClickCost(int index) => clickCostList[index];
    #endregion
}
