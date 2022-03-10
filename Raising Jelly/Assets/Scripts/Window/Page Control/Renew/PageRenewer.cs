using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//페이지에 변경사항이 있을 때 새로고침을 담당하는 클래스
public class PageRenewer : MonoBehaviour
{
    [Header("새로고침 항목")]
    [SerializeField] Text pageNumText;
    [SerializeField] Image lockedJellyImage;
    [SerializeField] Image unlockedJellyImage;
    [SerializeField] Text jellyNameText;
    [SerializeField] Text jellyGoldText;
    [SerializeField] Text jellyJellatineText;

    [Header("언락/락")]
    [Space(15f)]
    [SerializeField] GameObject unlockObj;
    [SerializeField] GameObject lockObj;

    [Header("매니저")][Space(15f)]
    [SerializeField] JellyManager jellyManager;

    //페이지 새로고침 기능. by상훈_22.03.09
    public void RenewPage(int curIndex)
    {
        //페이지 넘버 갱신
        pageNumText.text = $"#{curIndex:00}";
        //해금된 상태
        if (GameData.instance.GetUnlockData(curIndex))
        {
            ShowUnlock(curIndex);
        }
        else //잠김상태
        {
            ShowLock(curIndex);
        }
    }

    //언락 상태인 젤리를 보여주는 함수. by상훈_22.03.10
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
        int gold = 1000; //임시데이터
        jellyGoldText.text = $"{gold:n0}";
    }

    //락 상태인 젤리를 보여주는 함수. by상훈_22.03.10
    void ShowLock(int index)
    {
        //언락 이미지 숨기기
        HideLockObj(false);

        //젤리 이미지 갱신
        lockedJellyImage.sprite = jellyManager.jellyImageList[index - 1];
        //setNative()
        lockedJellyImage.SetNativeSize();
        //젤리 가격 갱신(세자리 마다 ,)
        jellyJellatineText.text = $"{jellyManager.requiredJellatineList[index - 1]:n0}";
    }

    void HideLockObj(bool isShow)
    {
        lockObj.SetActive(!isShow);
        unlockObj.SetActive(isShow);
    }
}
