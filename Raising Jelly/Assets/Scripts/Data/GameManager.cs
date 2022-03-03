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

    //이동 제한을 결정할 위치의 벡터값을 반환하는 기능. by상훈_22.02.13
    public Vector3 GetPositon(int num) => pointList[num];
}
