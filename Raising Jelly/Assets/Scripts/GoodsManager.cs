using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsManager : MonoBehaviour
{
    static int gold;
    static int jellatine;

    [Header("�Ŵ���")]
    [SerializeField] UIManager uiManager;

    //��ȭ ȹ��� ��뿡 ���� �Լ�. by����_22.02.14
    //��� ȸ��
    public void GetGold(int amount)
    {
        gold += amount;
        uiManager.SetGoldText(gold);
        //������ ����
        SaveData("gold");
    }
    public void UseGold(int amount)
    {
        gold -= amount;
        uiManager.SetGoldText(gold);
        //������ ����
        SaveData("gold");
    }
    public void GetJellatine(int amount)
    {
        gold += amount;
        uiManager.SetjellatineText(jellatine);
        //������ ����
        SaveData("jellatine");
    }
    public void UseJellatine(int amount)
    {
        gold -= amount;
        uiManager.SetjellatineText(jellatine);
        //������ ����
        SaveData("jellatine");
    }


    //��ȭ ������ �����ϴ� ���. by����_22.02.14
    public void SaveData(string type)
    {
        if (type == "gold") PlayerPrefs.SetInt("gold", gold);
        else if (type == "jellatine") PlayerPrefs.SetInt("jellatine", jellatine);
        //ĳ�� ������ ����
        PlayerPrefs.Save();
    }
}
