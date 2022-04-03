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

    [Header("클리어 뱃지")]
    [Space(15f)]
    [SerializeField] GameObject clearBadge;

    [Header("매니저")] [Space(15f)]
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

    //클리어 뱃지 ON/OFF. by상훈_22.04.03
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
