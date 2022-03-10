using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�������� ��������� ���� �� ���ΰ�ħ�� ����ϴ� Ŭ����
public class PageRenewer : MonoBehaviour
{
    [Header("���ΰ�ħ �׸�")]
    [SerializeField] Text pageNumText;
    [SerializeField] Image lockedJellyImage;
    [SerializeField] Image unlockedJellyImage;
    [SerializeField] Text jellyNameText;
    [SerializeField] Text jellyGoldText;
    [SerializeField] Text jellyJellatineText;

    [Header("���/��")]
    [Space(15f)]
    [SerializeField] GameObject unlockObj;
    [SerializeField] GameObject lockObj;

    [Header("�Ŵ���")][Space(15f)]
    [SerializeField] JellyManager jellyManager;

    //������ ���ΰ�ħ ���. by����_22.03.09
    public void RenewPage(int curIndex)
    {
        //������ �ѹ� ����
        pageNumText.text = $"#{curIndex:00}";
        //�رݵ� ����
        if (GameData.instance.GetUnlockData(curIndex))
        {
            ShowUnlock(curIndex);
        }
        else //������
        {
            ShowLock(curIndex);
        }
    }

    //��� ������ ������ �����ִ� �Լ�. by����_22.03.10
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
        int gold = 1000; //�ӽõ�����
        jellyGoldText.text = $"{gold:n0}";
    }

    //�� ������ ������ �����ִ� �Լ�. by����_22.03.10
    void ShowLock(int index)
    {
        //��� �̹��� �����
        HideLockObj(false);

        //���� �̹��� ����
        lockedJellyImage.sprite = jellyManager.jellyImageList[index - 1];
        //setNative()
        lockedJellyImage.SetNativeSize();
        //���� ���� ����(���ڸ� ���� ,)
        jellyJellatineText.text = $"{jellyManager.requiredJellatineList[index - 1]:n0}";
    }

    void HideLockObj(bool isShow)
    {
        lockObj.SetActive(!isShow);
        unlockObj.SetActive(isShow);
    }
}
