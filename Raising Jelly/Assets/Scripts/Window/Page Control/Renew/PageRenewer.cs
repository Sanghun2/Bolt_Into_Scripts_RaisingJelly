using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//페이지에 변경사항이 있을 때 새로고침을 담당하는 클래스
public class PageRenewer : MonoBehaviour
{
    [Header("젤리 새로고침 항목")]
    [SerializeField] Text pageNumText;
    [SerializeField] Image lockedJellyImage;
    [SerializeField] Image unlockedJellyImage;
    [SerializeField] Text jellyNameText;
    [SerializeField] Text jellyGoldText;
    [SerializeField] Text jellyJellatineText;

    [Header("스킬 새로고침 항목")]
    [Space(15f)]
    [SerializeField] Text numSubText;
    [SerializeField] Text clickSubText;
    [SerializeField] Text numPriceText;
    [SerializeField] Text clickPriceText;
    [SerializeField] GameObject numButton;
    [SerializeField] GameObject clickButton;
    PlantManager.CostType costType;

    [Header("언락/락")]
    [Space(15f)]
    [SerializeField] GameObject unlockObj;
    [SerializeField] GameObject lockObj;

    [Header("매니저")][Space(15f)]
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

    #region 젤리창
    //페이지 새로고침. by상훈_22.03.09
    public void RenewPage(int curIndex)
    {
        //페이지 넘버 갱신
        pageNumText.text = $"#{curIndex:00}";
        //해금된 상태
        if (GameData.Instance.GetUnlockData(curIndex))
        {
            ShowUnlock(curIndex);
        }
        else //잠김상태
        {
            ShowLock(curIndex);
        }
    }
    //언락 상태인 젤리를 보여주기. by상훈_22.03.10
    void ShowUnlock(int index)
    {
        //락 이미지 숨기기
        HideLockObj(true);

        //젤리 이미지 갱신
        unlockedJellyImage.sprite = jellyManager.jellyImageList[index - 1];
        //setNative()
        unlockedJellyImage.SetNativeSize();
        //젤리 이름 갱신
        jellyNameText.text = jellyManager.jellyNameList[index - 1];
        //젤리 가격 갱신(세자리 마다 ,)
        int requiredGold = buyManager.GetPriceOfJelly(index - 1); //임시데이터
        jellyGoldText.text = $"{requiredGold:n0}";
    }
    //락 상태인 젤리를 보여주기. by상훈_22.03.10
    void ShowLock(int index)
    {
        //언락 이미지 숨기기
        HideLockObj(false);

        //젤리 이미지 갱신
        lockedJellyImage.sprite = jellyManager.jellyImageList[index - 1];
        //setNative()
        lockedJellyImage.SetNativeSize();
        //젤리 가격 갱신(세자리 마다 ,)
        jellyJellatineText.text = $"{BuyManager.Instance.requiredJellatineList[index - 1]:n0}";
    }
    //잠김 관련 오브젝트 숨기기(언락된 경우). by상훈
    void HideLockObj(bool isShow)
    {
        lockObj.SetActive(!isShow);
        unlockObj.SetActive(isShow);
    }
    #endregion
    #region 스킬창
    //건설페이지 정보 새로고침. by상훈
    public void RenewPlantPage()
    {
        int skillLevel = gameData.NumberLevel;
        numSubText.text = $"젤리 수용량 {skillLevel * 2}";
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
        clickSubText.text = $"클릭 생산량 x {skillLevel}";
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
            numSubText.text = $"젤리 수용량 {skillLevel * 2}";
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
            clickSubText.text = $"클릭 생산량 x {skillLevel}";
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
    //가격버튼 숨기기(최대 레벨일 경우). by상훈
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
    //가격버튼 보이기. by상훈
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
