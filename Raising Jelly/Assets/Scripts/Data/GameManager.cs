using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Vector3[] pointList;

    bool isStarted;

    static GameManager instance; 
    public static GameManager Instance => instance;

    void Awake()
    {
        Application.targetFrameRate = 45;

        instance = this;
    }

    //게임시작 상태 변경 및 확인. by상훈_22.03.16
    public void StartGame(bool isStarted) => this.isStarted = isStarted;
    public bool IsStarted() => isStarted;
    //이동 제한을 결정할 위치의 벡터값을 반환하는 기능. by상훈_22.02.13
    public Vector3 GetPositon(int num) => pointList[num];
}
