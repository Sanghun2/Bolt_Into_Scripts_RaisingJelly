using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//유저가 가진 데이터를 다루는 클래스
public class GameData : MonoBehaviour
{
    [SerializeField] bool[] unlockList; //해금여부 리스트

    static GameData instance;
    public static GameData Instance => instance;

    void Awake()
    {
        instance = this;

        for (int i = 0; i < unlockList.Length; i++)
        {
            unlockList[i] = false; //나중에 저장된 데이터 읽어와서 설정
        }
    }

    #region 해금 데이터 관리
    //해금 데이터 수정 및 반환. by상훈_22.03.10
    public void SetUnlockData(int index, bool isTrue) => unlockList[index - 1] = isTrue;
    public bool GetUnlockData(int index) => unlockList[index - 1]; //들어오는 매개변수 인덱스는 항상 시작이 1 기준이므로 -1 처리
    #endregion
}
