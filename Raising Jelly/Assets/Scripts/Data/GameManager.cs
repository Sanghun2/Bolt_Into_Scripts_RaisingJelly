using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Vector3[] pointList;

    static GameManager instance;
    
    void Awake()
    {
        Application.targetFrameRate = 45;

        instance = this;
    }

    public static GameManager Instance => instance;

    //�̵� ������ ������ ��ġ�� ���Ͱ��� ��ȯ�ϴ� ���. by����_22.02.13
    public Vector3 GetPositon(int num) => pointList[num];
}
