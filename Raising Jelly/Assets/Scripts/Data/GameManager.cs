using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("위치값")]
    [SerializeField] Vector3[] pointList;

    [Header("설정값 조정")]
    [Space(15f)]
    [SerializeField] Slider sfxController;
    [SerializeField] Slider bgmController;
    public float sfxValue;
    public float bgmValue;

    [Header("매니저")]
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
        //설정값 대입
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
        //사운드 반영
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

    //설정 저장. by상훈_22.03.28
    public void SavePref()
    {
        PlayerPrefs.SetFloat("sfxValue", sfxValue);
        PlayerPrefs.SetFloat("bgmValue", bgmValue);
        PlayerPrefs.Save();
    }

    //게임종료. by상훈_22.03.28
    public void QuitGame()
    {
        isQuitting = true;
    }

    //게임시작 상태 변경 및 확인. by상훈_22.03.16
    public void StartGame(bool isStarted) => this.isStarted = isStarted;
    public bool IsStarted() => isStarted;
    //이동 제한을 결정할 위치의 벡터값을 반환하는 기능. by상훈_22.02.13
    public Vector3 GetPositon(int num) => pointList[num];
}
