using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ȭ�鿡 ���̴� UI�� �����ϴ� Ŭ����
public class UIManager : MonoBehaviour
{
    [Header("��ȭ UI")]
    [SerializeField] Text goldText;
    [SerializeField] Text jellatineText;

    void LateUpdate()
    {
        goldText.text = $"{Mathf.SmoothStep(float.Parse(goldText.text), GoodsManager.GoldIHave(), 0.5f):n0}";
        jellatineText.text = $"{Mathf.SmoothStep(float.Parse(jellatineText.text), GoodsManager.JellatineIHave(), 0.5f):n0}";
    }
}
