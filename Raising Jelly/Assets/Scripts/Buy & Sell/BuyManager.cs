using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���Ÿ� �����ϴ� Ŭ����
public class BuyManager : MonoBehaviour
{
    [Header("���� ���� ������")]
    public List<int> requiredJellatineList = new List<int>();
    public List<int> requiredGoldList = new List<int>();

    [Header("�Ŵ���")][Space(15f)]
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

    #region ���
    //������ ����. by����_22.03.14
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
        //����� ����ƾ�� �������� üũ
        if (GoodsManager.GoldIHave() >= amount)
        {
            //��ȭ ó��
            GoodsManager.Instance.UseGold(amount);
            soundManager.PlayBuySound();
            //��������
            JellyManager.Instance.CreateJelly(id);
        }
        else
        {
            soundManager.PlayFailSound();
            noticeManager.ShowMessage(NoticeManager.Message.NotEnoughGold);
        }
    }
    #endregion
    #region ����ƾ
    //������ �ر�. by����_22.03.11
    public void UnlockJelly()
    {
        int curIndex = pageSwitcher.GetIndex();
        int amount = JellyManager.Instance.ReqiredJellatine(curIndex);
        //����� ����ƾ�� �������� üũ
        if (GoodsManager.JellatineIHave() >= amount)
        {
            //��ȭ ó��
            GoodsManager.Instance.UseJellatine(amount);
            //���� �ر�
            GameData.Instance.SetUnlockData(curIndex, true);
            soundManager.PlayUnlockSound();
            //���ΰ�ħ
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
    #region ������ ����
    //�ش� �ε����� ���� ���� ���� ��ȯ. by����_22.04.03
    public int GetPriceOfJelly(int index) => requiredGoldList[index];
    #endregion
}