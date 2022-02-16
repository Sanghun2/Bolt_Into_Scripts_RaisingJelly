using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//화면에 보이는 UI를 관리하는 클래스
public class UIManager : MonoBehaviour
{
    [Header("재화 UI")]
    [SerializeField] Text goldText;
    [SerializeField] Text jellatineText;

    void LateUpdate()
    {
        goldText.text = $"{Mathf.SmoothStep(float.Parse(goldText.text), GoodsManager.GoldIHave(), 0.5f):n0}";
        jellatineText.text = $"{Mathf.SmoothStep(float.Parse(jellatineText.text), GoodsManager.JellatineIHave(), 0.5f):n0}";
    }
}
