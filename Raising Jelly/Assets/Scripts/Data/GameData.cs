using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//유저가 가진 데이터를 다루는 클래스(파일로 저장)
public class GameData : MonoBehaviour
{
    [Header("유저 데이터")]
    [SerializeField] bool[] unlockList; //해금여부 리스트
    public List<JellyData> jellyDataList = new List<JellyData>();

    string jellyDataFile => "Resources/JellyData.Json";
    string unlockDataFile => "Resources/UnlockData.Json";
    //Assets/Resources/UnlockData.Json

    static GameData instance;
    public static GameData Instance => instance;

    void Awake()
    {
        instance = this;

        LoadUnlockData();
        LoadJellyData();

        GameManager.Instance.StartGame(true);
    }

    #region 데이터 저장
    //젤리 전체 데이터 리스트에 추가. by상훈_22.03.16
    public void SaveJellyAll(List<GameObject> jellyList)
    {
        jellyDataList.Clear();
        foreach (var jelly in jellyList)
        {
            SavaJelly(jelly.GetComponent<Jelly>());
        }

        //세이브파일로 저장
        SaveJellyData();
    }
    //젤리 낱개 데이터 리스트에 추가. by상훈_22.03.16
    void SavaJelly(Jelly jellyInfo)
    {
        jellyDataList.Add(new JellyData(jellyInfo.ID, jellyInfo.CurLevel, jellyInfo.CurExp));
    }
    //해금 상태 파일저장. by상훈_22.03.16
    void SaveUnlockData()
    {
        string tempContent = string.Empty;
        foreach (var status in unlockList)
        {
            tempContent += $"{status},";
        }
        tempContent = tempContent.Substring(0, tempContent.Length - 1);
        string filePath = Path.Combine(Application.dataPath, unlockDataFile);
        File.WriteAllText(filePath, tempContent);
    }
    //젤리현황 파일저장. by상훈_22.03.16
    void SaveJellyData()
    {
        string jsonJellyData = string.Empty;
        if (jellyDataList.Count != 0)
        {
            foreach (var content in jellyDataList)
            {
                jsonJellyData += $"{JsonUtility.ToJson(content)},";
            }
            jsonJellyData = jsonJellyData.Substring(0, jellyDataList.Count - 1);
        }
        string filePath = Path.Combine(Application.dataPath, jellyDataFile);
        File.WriteAllText(filePath, jsonJellyData);
    }
    #endregion
    #region 데이터 로드
    void LoadUnlockData()
    {
        string dataPath = Path.Combine(Application.dataPath, unlockDataFile);
        if (File.Exists(dataPath)) //파일이 있으면 로드
        {
            string[] tempData = File.ReadAllText(dataPath).Split(',');
            for (int i = 1; i <= tempData.Length; i++)
            {
                if (tempData[i - 1] == "true") SetUnlockData(i, true);
                else SetUnlockData(i, false);
            }
        }
        else //없으면 디폴트값으로 초기화
        {
            for (int i = 1; i <= unlockList.Length; i++)
            {
                if (i == 1) SetUnlockData(i, true);
                else SetUnlockData(i, false);
            }
        }
    }
    void LoadJellyData()
    {

    }
    #endregion
    #region 해금 데이터 관리
    //해금 데이터 수정 및 반환. by상훈_22.03.10
    public void SetUnlockData(int index, bool isTrue)
    {
        unlockList[index - 1] = isTrue;
        if(GameManager.Instance.IsStarted()) SaveUnlockData();
    }
    public bool GetUnlockData(int index) => unlockList[index - 1]; //들어오는 매개변수 인덱스는 항상 시작이 1 기준이므로 -1 처리
    #endregion
}
