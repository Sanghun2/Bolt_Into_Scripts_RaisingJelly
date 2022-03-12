using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���Ÿ� �����ϴ� Ŭ����
public class BuyManager : MonoBehaviour
{
    [Header("�Ŵ���")]
    [SerializeField] PageSwitcher pageSwitcher;

    #region ���

    #endregion

    #region ����ƾ
    //������ �ر��ϴ� ���. by����_22.03.11
    public void UnlockJelly()
    {
        int num = pageSwitcher.GetIndex();
        int amount = JellyManager.instance.ReqiredJellatine(num);
        //����� ����ƾ�� �������� üũ
        if (GoodsManager.JellatineIHave() >= amount)
        {
            //��ȭ ó��
            GoodsManager.instance.UseJellatine(amount);
            //���� �ر�
            GameData.instance.SetUnlockData(num, true);
            //���ΰ�ħ
            PageRenewer.instance.RenewPage(num);
        }
    }
    #endregion
}
