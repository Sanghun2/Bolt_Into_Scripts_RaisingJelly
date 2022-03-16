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

    //���ӽ��� ���� ���� �� Ȯ��. by����_22.03.16
    public void StartGame(bool isStarted) => this.isStarted = isStarted;
    public bool IsStarted() => isStarted;
    //�̵� ������ ������ ��ġ�� ���Ͱ��� ��ȯ�ϴ� ���. by����_22.02.13
    public Vector3 GetPositon(int num) => pointList[num];
}
