using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsManager : MonoBehaviour
{
    static int gold;
    static int jellatine;

    [Header("�Ŵ���")]
    [SerializeField] UIManager uiManager;

    public static GoodsManager instance;

    //���� �����ִ� ��ȭ���� ��ȯ�ϴ� ���. by����_22.02.16
    public static int GoldIHave() => gold;
    public static int JellatineIHave() => jellatine;

    void Awake()
    {
        instance = this;

        if (PlayerPrefs.HasKey("gold")) gold = PlayerPrefs.GetInt("gold");
        else gold = 0;
        if (PlayerPrefs.HasKey("jellatine")) jellatine = PlayerPrefs.GetInt("jellatine");
        else jellatine = 0;
    }

    //��ȭ ȹ��� ��뿡 ���� �Լ�. by����_22.02.14
    //��� ȸ��
    public void GetGold(int amount)
    {
        gold += amount;
        if (gold > 999999999) gold = 999999999;
        SaveData("gold");
    }
    public void UseGold(int amount)
    {
        gold -= amount;
        SaveData("gold");
    }
    public void GetJellatine(int amount)
    {
        jellatine += amount;
        if (jellatine > 999999999) jellatine = 999999999;
        SaveData("jellatine");
    }
    public void UseJellatine(int amount)
    {
        jellatine -= amount;
        SaveData("jellatine");
    }


    //��ȭ ������ ����. by����_22.02.14
    public void SaveData(string type)
    {
        if (type == "gold") PlayerPrefs.SetInt("gold", gold);
        else if (type == "jellatine") PlayerPrefs.SetInt("jellatine", jellatine);
        //ĳ�� ������ ����
        PlayerPrefs.Save();
    }

    #region �׽�Ʈ�Լ�
    [ContextMenu("Get_100Jellatine")]
    public void Get_100Jellatine()
    {
        jellatine += 500000;
        if (jellatine > 999999999) jellatine = 999999999;
        SaveData("gold");
    }
    #endregion
}
