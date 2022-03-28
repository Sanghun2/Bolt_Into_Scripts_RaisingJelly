using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("��ġ��")]
    [SerializeField] Vector3[] pointList;

    [Header("������ ����")]
    [Space(15f)]
    [SerializeField] Slider sfxController;
    [SerializeField] Slider bgmController;
    public float sfxValue;
    public float bgmValue;

    [Header("�Ŵ���")]
    [Space(15f)]
    [SerializeField] SoundManager soundManager;

    bool isStarted;
    public float quitTime;
    bool isQuitting;

    static GameManager instance; 
    public static GameManager Instance => instance;

    void Awake()
    {
        Application.targetFrameRate = 45;

        instance = this;

        sfxValue = 0.5f;
        bgmValue = 0.5f;
    }

    void Start()
    {
        //������ ����
        if (PlayerPrefs.HasKey("sfxValue"))
        {
            sfxValue = PlayerPrefs.GetFloat("sfxValue");
            sfxController.value = sfxValue;
        }
        if (PlayerPrefs.HasKey("bgmValue"))
        {
            bgmValue = PlayerPrefs.GetFloat("bgmValue");
            bgmController.value = bgmValue;
        }
    }

    void Update()
    {
        //���� �ݿ�
        sfxValue = sfxController.value;
        bgmValue = bgmController.value;
        soundManager.SfxPlayer.volume = sfxValue;
        soundManager.BgmPlayer.volume = bgmValue;

        if (isQuitting)
        {
            quitTime += Time.unscaledDeltaTime;

            if(quitTime >= 0.5f)
            {
                Application.Quit();
            }
        }
    }

    //���� ����. by����_22.03.28
    public void SavePref()
    {
        PlayerPrefs.SetFloat("sfxValue", sfxValue);
        PlayerPrefs.SetFloat("bgmValue", bgmValue);
        PlayerPrefs.Save();
    }

    //��������. by����_22.03.28
    public void QuitGame()
    {
        isQuitting = true;
    }

    //���ӽ��� ���� ���� �� Ȯ��. by����_22.03.16
    public void StartGame(bool isStarted) => this.isStarted = isStarted;
    public bool IsStarted() => isStarted;
    //�̵� ������ ������ ��ġ�� ���Ͱ��� ��ȯ�ϴ� ���. by����_22.02.13
    public Vector3 GetPositon(int num) => pointList[num];
}
