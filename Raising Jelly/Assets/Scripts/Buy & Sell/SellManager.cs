using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellManager : MonoBehaviour
{
    bool isSell;

    [Header("��������")]
    [SerializeField] int[] jellyPrice;

    static SellManager instance;
    public static SellManager Instance => instance;

    void Awake()
    {
        instance = this;
    }

    #region �ǸŰ��ɿ��� �Ǵ�
    //��ġ�� �ǸŹ�ư ���� ���� �� ����. by����_22.02.26
    public void GetInToButton()
    {
        isSell = true;
    }

    //��ġ�� �ǸŹ�ư���� ������ �� ����. by����_22.02.26
    public void GetOutFromButton()
    {
        isSell = false;
    }
    #endregion
    #region �Ǹ� ���
    //���� �Ǹ�. by����_22.03.16
    public void SellJelly(GameObject targetJelly)
    {
        Jelly jellyInfo = targetJelly.GetComponent<Jelly>();
        int price = GetJellyPrice(jellyInfo.ID);
        price *= jellyInfo.CurLevel;
        GoodsManager.Instance.GetGold(price);
        //����Ʈ���� ����
        JellyManager.Instance.RemoveJellyFromList(targetJelly);
        //������ ������ ����
        GameData.Instance.SaveJellyAll(JellyManager.Instance.GetJellyList());
        //�Ǹ� �� �����ı�
        Destroy(targetJelly);
    }
    #endregion
    #region �Ǹ� ���� ����
    //�ǸŰ��� ���� ��ȯ�ϴ� ���. by����_22.02.26
    public bool IsSellable() => isSell;

    //�������� ��ȯ�ϴ� ���. by����_22.02.26
    public int GetJellyPrice(int id) => jellyPrice[id];
    #endregion
}
