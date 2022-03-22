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
        if(jellyManager.CurJellyCount >= gameData.NumberLevel*2) return;

        int num = pageSwitcher.GetIndex();
        int amount = JellyManager.Instance.ReqiredGold(num);
        int id = PageSwitcher.Instance.GetIndex() - 1;
        //����� ����ƾ�� �������� üũ
        if (GoodsManager.GoldIHave() >= amount)
        {
            //��ȭ ó��
            GoodsManager.Instance.UseGold(amount);
            //��������
            JellyManager.Instance.CreateJelly(id);
        }
    }
    #endregion

    #region ����ƾ
    //������ �ر�. by����_22.03.11
    public void UnlockJelly()
    {
        int num = pageSwitcher.GetIndex();
        int amount = JellyManager.Instance.ReqiredJellatine(num);
        //����� ����ƾ�� �������� üũ
        if (GoodsManager.JellatineIHave() >= amount)
        {
            //��ȭ ó��
            GoodsManager.Instance.UseJellatine(amount);
            //���� �ر�
            GameData.Instance.SetUnlockData(num, true);
            //���ΰ�ħ
            PageRenewer.Instance.RenewPage(num);
        }
    }
    #endregion
}
