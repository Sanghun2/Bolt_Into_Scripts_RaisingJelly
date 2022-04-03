using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//�˸� �ý����� �����ϴ� Ŭ����
public class NoticeManager : MonoBehaviour
{
    //�޴��̸�
    public enum Message { Start, Clear, Sell, NotEnoughJellatine, NotEnoughGold, NotEnoughCap}
    //�޼��� ����
    [Header("�޼��� ����")]
    [SerializeField] [TextArea] string[] noticeContent;

    [Header("�޼��� ����")]
    [Space(15f)]
    [SerializeField] Text messageText;
    [SerializeField] RectTransform noticeBoxPos;
    [SerializeField] Image boxColor;

    [Header("�Ŵ���")]
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
    /// ��ư Ŭ���� �޼��� ���̱�. by����_22.04.02
    /// </summary>
    /// <param name="messageType">�ҹ��ڷ� �ۼ�. Ex) sell</param>
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

    //Ư�� �̺�Ʈ �߻� �� �޼��� ���̱�. by����_22.04.02
    public void ShowMessage(Message messageType)
    {
        //�⺻������ positive����
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

    //�˸��޼����� ������ ���. by����_22.04.02
    IEnumerator ShowMessageBox()
    {
        noticeBoxPos.anchoredPosition = showedMessagePos;
        yield return waitFor_3Sec;
        noticeBoxPos.anchoredPosition = hiddenMessagePos;
    }

    //�޼��� ����ġ. by����_22.04.02
    void PlaceMessage()
    {
        noticeBoxPos.anchoredPosition = hiddenMessagePos;
    }
}
