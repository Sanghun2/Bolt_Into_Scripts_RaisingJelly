using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//알림 시스템을 관리하는 클래스
public class NoticeManager : MonoBehaviour
{
    //메뉴이름
    public enum Message { Start, Clear, Sell, NotEnoughJellatine, NotEnoughGold, NotEnoughCap}
    //메세지 내용
    [Header("메세지 내용")]
    [SerializeField] [TextArea] string[] noticeContent;

    [Header("메세지 관리")]
    [Space(15f)]
    [SerializeField] Text messageText;
    [SerializeField] RectTransform noticeBoxPos;
    [SerializeField] Image boxColor;

    [Header("매니저")]
    [Space(15f)]
    [SerializeField] SoundManager soundManager;
    [SerializeField] ColorManager colorManager;
    [SerializeField] GameData gameData;

    static NoticeManager instance;
    public static NoticeManager Instance => instance;

    YieldInstruction waitFor_3Sec;
    Vector3 showedMessagePos;
    Vector3 hiddenMessagePos;
    IEnumerator showMessageBox;

    void Awake()
    {
        instance = this;

        waitFor_3Sec = new WaitForSeconds(3f);
        showedMessagePos = new Vector3(0, -10, 0);
        hiddenMessagePos = new Vector3(0, 10, 0);
    }

    void Start()
    {
        if (gameData.IsFirstGame())
        {
            ShowMessage(Message.Start);
        }
    }

    /// <summary>
    /// 버튼 클릭시 메세지 보이기. by상훈_22.04.02
    /// </summary>
    /// <param name="messageType">소문자로 작성. Ex) sell</param>
    public void ShowMessage(string messageType)
    {
        switch (messageType)
        {
            case "sell":
                ShowMessage(Message.Sell);
                break;
            default:
                break;
        }
    }

    //특정 이벤트 발생 시 메세지 보이기. by상훈_22.04.02
    public void ShowMessage(Message messageType)
    {
        //기본값으로 positive설정
        boxColor.color = colorManager.MakePositive();

        switch (messageType)
        {
            case Message.Start:
                break;
            case Message.Clear:
                soundManager.PlayClearSound();
                break;
            case Message.Sell:
                soundManager.PlaySellSound();
                break;
            case Message.NotEnoughJellatine:
                boxColor.color = colorManager.MakeNegative();
                break;
            case Message.NotEnoughGold:
                boxColor.color = colorManager.MakeNegative();
                break;
            case Message.NotEnoughCap:
                boxColor.color = colorManager.MakeNegative();
                break;
            default:
                break;
        }

        if(showMessageBox != null)
            StopCoroutine(showMessageBox);

        PlaceMessage();
        messageText.text = noticeContent[Convert.ToInt32(messageType)];
        showMessageBox = ShowMessageBox();
        StartCoroutine(showMessageBox);
    }

    //알림메세지가 나오는 기능. by상훈_22.04.02
    IEnumerator ShowMessageBox()
    {
        noticeBoxPos.anchoredPosition = showedMessagePos;
        yield return waitFor_3Sec;
        noticeBoxPos.anchoredPosition = hiddenMessagePos;
    }

    //메세지 원위치. by상훈_22.04.02
    void PlaceMessage()
    {
        noticeBoxPos.anchoredPosition = hiddenMessagePos;
    }
}
