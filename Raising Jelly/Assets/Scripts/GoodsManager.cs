using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsManager : MonoBehaviour
{
    static int gold;
    static int jellatine;

    [Header("매니저")]
    [SerializeField] UIManager uiManager;

    //재화 획득과 사용에 관한 함수. by상훈_22.02.14
    //골드 회득
    public void GetGold(int amount)
    {
        gold += amount;
        uiManager.SetGoldText(gold);
        //데이터 저장
        SaveData("gold");
    }
    public void UseGold(int amount)
    {
        gold -= amount;
        uiManager.SetGoldText(gold);
        //데이터 저장
        SaveData("gold");
    }
    public void GetJellatine(int amount)
    {
        gold += amount;
        uiManager.SetjellatineText(jellatine);
        //데이터 저장
        SaveData("jellatine");
    }
    public void UseJellatine(int amount)
    {
        gold -= amount;
        uiManager.SetjellatineText(jellatine);
        //데이터 저장
        SaveData("jellatine");
    }


    //재화 데이터 저장하는 기능. by상훈_22.02.14
    public void SaveData(string type)
    {
        if (type == "gold") PlayerPrefs.SetInt("gold", gold);
        else if (type == "jellatine") PlayerPrefs.SetInt("jellatine", jellatine);
        //캐시 데이터 저장
        PlayerPrefs.Save();
    }
}
