using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//팝업창을 관리하는 클래스
public class WindowManager : MonoBehaviour
{
    [Header("관리되는 윈도우")]
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

    //젤리창 ON/OFF하는 기능. by상훈_22.03.03
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

    //건설창 ON/OFF하는 기능. by상훈_22.03.03
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

    //옵션창 ON/OFF하는 기능. by상훈_22.03.03
    public void OpenOptionWindow(bool isOpen)
    {
        ShowWindow("option");
        isOptionOpened = isOpen;
    }

    //윈도우 여러 개 떠있을 때 관리하는 기능.
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
