using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//������ ���� �����͸� �ٷ�� Ŭ����(���Ϸ� ����)
public class GameData : MonoBehaviour
{
    [Header("���� ������")]
    [SerializeField] bool[] unlockList; //�رݿ��� ����Ʈ
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

    #region ������ ����
    //���� ��ü ������ ����Ʈ�� �߰�. by����_22.03.16
    public void SaveJellyAll(List<GameObject> jellyList)
    {
        jellyDataList.Clear();
        foreach (var jelly in jellyList)
        {
            SavaJelly(jelly.GetComponent<Jelly>());
        }

        //���̺����Ϸ� ����
        SaveJellyData();
    }
    //���� ���� ������ ����Ʈ�� �߰�. by����_22.03.16
    void SavaJelly(Jelly jellyInfo)
    {
        jellyDataList.Add(new JellyData(jellyInfo.ID, jellyInfo.CurLevel, jellyInfo.CurExp));
    }
    //�ر� ���� ��������. by����_22.03.16
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
    //������Ȳ ��������. by����_22.03.16
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
    #region ������ �ε�
    void LoadUnlockData()
    {
        string dataPath = Path.Combine(Application.dataPath, unlockDataFile);
        if (File.Exists(dataPath)) //������ ������ �ε�
        {
            string[] tempData = File.ReadAllText(dataPath).Split(',');
            for (int i = 1; i <= tempData.Length; i++)
            {
                if (tempData[i - 1] == "true") SetUnlockData(i, true);
                else SetUnlockData(i, false);
            }
        }
        else //������ ����Ʈ������ �ʱ�ȭ
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
    #region �ر� ������ ����
    //�ر� ������ ���� �� ��ȯ. by����_22.03.10
    public void SetUnlockData(int index, bool isTrue)
    {
        unlockList[index - 1] = isTrue;
        if(GameManager.Instance.IsStarted()) SaveUnlockData();
    }
    public bool GetUnlockData(int index) => unlockList[index - 1]; //������ �Ű����� �ε����� �׻� ������ 1 �����̹Ƿ� -1 ó��
    #endregion
}
