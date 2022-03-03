using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�˾�â�� �����ϴ� Ŭ����
public class WindowManager : MonoBehaviour
{
    [Header("�����Ǵ� ������")]
    [SerializeField] GameObject jellyWindow;
    [SerializeField] GameObject plantWindow;
    [SerializeField] GameObject optionWindow;

    WindowController jellyWindowController;
    WindowController plantWindowController;

    bool isJellyOpened;
    bool isPlantOpened;
    bool isOptionOpened;

    void Awake()
    {
        jellyWindowController = jellyWindow.GetComponent<WindowController>();
        plantWindowController = plantWindow.GetComponent<WindowController>();
    }

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
                OpenOptionWindow(false);
            }
            else
            {
                OpenOptionWindow(true);
            }
        }
    }

    //����â ON/OFF�ϴ� ���. by����_22.03.03
    public void OpenJellyWindow(bool isOpen)
    {
        if (!isJellyOpened && isOpen)
        {
            ShowWindow("jelly");
        }
        else
        {
            jellyWindowController.CloseWindow();
        }

        isJellyOpened = isOpen;
    }

    //�Ǽ�â ON/OFF�ϴ� ���. by����_22.03.03
    public void OpenPlantWindow(bool isOpen)
    {
        if (!isPlantOpened && isOpen)
        {
            ShowWindow("plant");
        }
        else
        {
            plantWindowController.CloseWindow();
        }

        isPlantOpened = isOpen;
    }

    //�ɼ�â ON/OFF�ϴ� ���. by����_22.03.03
    public void OpenOptionWindow(bool isOpen)
    {
        ShowWindow("option");
        isOptionOpened = isOpen;
    }

    //������ ���� �� ������ �� �����ϴ� ���.
    void ShowWindow(string name)
    {
        switch (name)
        {
            case "jelly":
                jellyWindow.SetActive(true); //ON
                plantWindowController.CloseWindow();
                optionWindow.SetActive(false);
                break;
            case "plant":
                jellyWindowController.CloseWindow();
                plantWindow.SetActive(true); //ON
                optionWindow.SetActive(false);
                break;
            case "option":
                jellyWindowController.CloseWindow();
                plantWindowController.CloseWindow();
                optionWindow.SetActive(true); //ON
                break;
            default:
                break;
        }
    }
}
