using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�˾�â�� �����ϴ� Ŭ����
public class WindowManager : MonoBehaviour
{
    [Header("������")]
    [SerializeField] WindowController[] movableWindow;
    [SerializeField] GameObject optionWindow;

    bool isJellyOpened;
    bool isPlantOpened;
    static bool isOptionOpened;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isJellyOpened)
            {
                OpenJellyWindow(false);
            }
            else if (isPlantOpened)
            {
                OpenPlantWindow(false);
            }
            else if (isOptionOpened)
            {
                OpenOption(false);
            }
            else
            {
                OpenOption(true);
            }
        }
    }

    //���� ������ ON/OFF�ϴ� ���. by����_22.03.03
    public void OpenJellyWindow(bool isOpen)
    {
        if (isOptionOpened) return;

        if (!isJellyOpened)
        {
            movableWindow[0].OpenWindow(isOpen);
            if (isPlantOpened) OpenPlantWindow(false);
            isJellyOpened = true;
        }
        else
        {
            movableWindow[0].OpenWindow(false);
            isJellyOpened = false;
        }
    }

    //�Ǽ� ������ ON/OFF�ϴ� ���. by����_22.03.03
    public void OpenPlantWindow(bool isOpen)
    {
        if (isOptionOpened) return;

        if (!isPlantOpened)
        {
            movableWindow[1].OpenWindow(isOpen);
            if (isJellyOpened) OpenJellyWindow(false);
            isPlantOpened = true;
        }
        else
        {
            movableWindow[1].OpenWindow(false);
            isPlantOpened = false;
        }
    }

    //�ɼ�â ON/OFF�ϴ� ���. by����_22.03.03
    void OpenOption(bool isOpen)
    {
        optionWindow.SetActive(isOpen);
        isOptionOpened = isOpen;
        if (isOptionOpened)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    //�ɼ�â�� ON/OFF���� ��ȯ
    public static bool IsOptionOn() => isOptionOpened;
}
