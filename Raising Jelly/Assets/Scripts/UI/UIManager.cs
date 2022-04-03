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

    [Header("Ŭ���� ����")]
    [Space(15f)]
    [SerializeField] GameObject clearBadge;

    [Header("�Ŵ���")] [Space(15f)]
    [SerializeField] GameData gameData;
    [SerializeField] NoticeManager noticeManager;

    void Start()
    {
        if (gameData.IsCleared()) ShowClearBadge(true);
    }

    void LateUpdate()
    {
        goldText.text = $"{Mathf.SmoothStep(float.Parse(goldText.text), GoodsManager.GoldIHave(), 0.5f):n0}";
        jellatineText.text = $"{Mathf.SmoothStep(float.Parse(jellatineText.text), GoodsManager.JellatineIHave(), 0.5f):n0}";
    }

    //Ŭ���� ���� ON/OFF. by����_22.04.03
    public void ShowClearBadge(bool isShow)
    {
        clearBadge.SetActive(isShow);
        gameData.MakeClear(isShow);
        if (isShow)
        {
            noticeManager.ShowMessage(NoticeManager.Message.Clear);
        }
    }
}
