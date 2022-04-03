using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�������� ��������� ���� �� ���ΰ�ħ�� ����ϴ� Ŭ����
public class PageRenewer : MonoBehaviour
{
    [Header("���� ���ΰ�ħ �׸�")]
    [SerializeField] Text pageNumText;
    [SerializeField] Image lockedJellyImage;
    [SerializeField] Image unlockedJellyImage;
    [SerializeField] Text jellyNameText;
    [SerializeField] Text jellyGoldText;
    [SerializeField] Text jellyJellatineText;

    [Header("��ų ���ΰ�ħ �׸�")]
    [Space(15f)]
    [SerializeField] Text numSubText;
    [SerializeField] Text clickSubText;
    [SerializeField] Text numPriceText;
    [SerializeField] Text clickPriceText;
    [SerializeField] GameObject numButton;
    [SerializeField] GameObject clickButton;
    PlantManager.CostType costType;

    [Header("���/��")]
    [Space(15f)]
    [SerializeField] GameObject unlockObj;
    [SerializeField] GameObject lockObj;

    [Header("�Ŵ���")][Space(15f)]
    [SerializeField] JellyManager jellyManager;
    [SerializeField] PlantManager plantManager;
    [SerializeField] GameData gameData;
    [SerializeField] BuyManager buyManager;

    static PageRenewer instance;
    public static PageRenewer Instance => instance;

    void Awake()
    {
        instance = this;
    }

    #region ����â
    //������ ���ΰ�ħ. by����_22.03.09
    public void RenewPage(int curIndex)
    {
        //������ �ѹ� ����
        pageNumText.text = $"#{curIndex:00}";
        //�رݵ� ����
        if (GameData.Instance.GetUnlockData(curIndex))
        {
            ShowUnlock(curIndex);
        }
        else //������
        {
            ShowLock(curIndex);
        }
    }
    //��� ������ ������ �����ֱ�. by����_22.03.10
    void ShowUnlock(int index)
    {
        //�� �̹��� �����
        HideLockObj(true);

        //���� �̹��� ����
        unlockedJellyImage.sprite = jellyManager.jellyImageList[index - 1];
        //setNative()
        unlockedJellyImage.SetNativeSize();
        //���� �̸� ����
        jellyNameText.text = jellyManager.jellyNameList[index - 1];
        //���� ���� ����(���ڸ� ���� ,)
        int requiredGold = buyManager.GetPriceOfJelly(index - 1); //�ӽõ�����
        jellyGoldText.text = $"{requiredGold:n0}";
    }
    //�� ������ ������ �����ֱ�. by����_22.03.10
    void ShowLock(int index)
    {
        //��� �̹��� �����
        HideLockObj(false);

        //���� �̹��� ����
        lockedJellyImage.sprite = jellyManager.jellyImageList[index - 1];
        //setNative()
        lockedJellyImage.SetNativeSize();
        //���� ���� ����(���ڸ� ���� ,)
        jellyJellatineText.text = $"{BuyManager.Instance.requiredJellatineList[index - 1]:n0}";
    }
    //��� ���� ������Ʈ �����(����� ���). by����
    void HideLockObj(bool isShow)
    {
        lockObj.SetActive(!isShow);
        unlockObj.SetActive(isShow);
    }
    #endregion
    #region ��ųâ
    //�Ǽ������� ���� ���ΰ�ħ. by����
    public void RenewPlantPage()
    {
        int skillLevel = gameData.NumberLevel;
        numSubText.text = $"���� ���뷮 {skillLevel * 2}";
        costType = PlantManager.CostType.Number;
        if (skillLevel == 5)
        {
            HidePriceButton(costType);
        }
        else
        {
            numPriceText.text = $"{plantManager.GetNumCost(skillLevel)}";
        }

        skillLevel = gameData.ClickLevel;
        clickSubText.text = $"Ŭ�� ���귮 x {skillLevel}";
        costType = PlantManager.CostType.Click;
        if (skillLevel == 5)
        {
            HidePriceButton(costType);
        }
        else
        {
            clickPriceText.text = $"{plantManager.GetClickCost(skillLevel)}";
        }
    }
    public void RenewPlantPage(PlantManager.CostType costType)
    {
        
        if (costType == PlantManager.CostType.Number)
        {
            int skillLevel = gameData.NumberLevel;
            numSubText.text = $"���� ���뷮 {skillLevel * 2}";
            costType = PlantManager.CostType.Number;
            if (skillLevel == 5)
            {
                HidePriceButton(costType);
            }
            else
            {
                numPriceText.text = $"{plantManager.GetNumCost(skillLevel)}";
            }
        }
        else
        {
            int skillLevel = gameData.ClickLevel;
            clickSubText.text = $"Ŭ�� ���귮 x {skillLevel}";
            costType = PlantManager.CostType.Click;
            if (skillLevel == 5)
            {
                HidePriceButton(costType);
            }
            else
            {
                clickPriceText.text = $"{plantManager.GetClickCost(skillLevel)}";
            }
        }
    }
    //���ݹ�ư �����(�ִ� ������ ���). by����
    void HidePriceButton(PlantManager.CostType costType)
    {
        switch (costType)
        {
            case PlantManager.CostType.Number:
                numButton.SetActive(false);
                break;
            case PlantManager.CostType.Click:
                clickButton.SetActive(false);
                break;
            default:
                break;
        }
    }
    //���ݹ�ư ���̱�. by����
    public void ShowPriceButton()
    {
        numButton.SetActive(true);
        clickButton.SetActive(true);
    }
    public void ShowPriceButton(PlantManager.CostType costType)
    {
        switch (costType)
        {
            case PlantManager.CostType.Number:
                numButton.SetActive(true);
                break;
            case PlantManager.CostType.Click:
                clickButton.SetActive(true);
                break;
            default:
                break;
        }
    }
    #endregion
}
