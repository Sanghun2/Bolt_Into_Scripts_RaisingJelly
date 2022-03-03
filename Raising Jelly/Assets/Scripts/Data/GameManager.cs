using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Vector3[] pointList;
    
    void Awake()
    {
        Application.targetFrameRate = 45;
    }

    //�̵� ������ ������ ��ġ�� ���Ͱ��� ��ȯ�ϴ� ���. by����_22.02.13
    public Vector3 GetPositon(int num) => pointList[num];
}
