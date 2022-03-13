using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsManager : MonoBehaviour
{
    static int gold;
    static int jellatine;

    [Header("매니저")]
    [SerializeField] UIManager uiManager;

    public static GoodsManager instance;

    //현재 갖고있는 재화량을 반환하는 기능. by상훈_22.02.16
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

    //재화 획득과 사용에 관한 함수. by상훈_22.02.14
    //골드 회득
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


    //재화 데이터 저장. by상훈_22.02.14
    public void SaveData(string type)
    {
        if (type == "gold") PlayerPrefs.SetInt("gold", gold);
        else if (type == "jellatine") PlayerPrefs.SetInt("jellatine", jellatine);
        //캐시 데이터 저장
        PlayerPrefs.Save();
    }

    #region 테스트함수
    [ContextMenu("Get_100Jellatine")]
    public void Get_100Jellatine()
    {
        jellatine += 500000;
        if (jellatine > 999999999) jellatine = 999999999;
        SaveData("gold");
    }
    #endregion
}
