using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//사운드를 관리하는 클래스
public class SoundManager : MonoBehaviour
{
    [Header("사운드 클립")]
    [SerializeField] AudioClip bgmClip; //#1
    [SerializeField] AudioClip buttonClip;
    [SerializeField] AudioClip buyClip;
    [SerializeField] AudioClip clearClip; //#4
    [SerializeField] AudioClip fallClip;
    [SerializeField] AudioClip growClip;
    [SerializeField] AudioClip pauseInClip;
    [SerializeField] AudioClip pauseOutClip;
    [SerializeField] AudioClip sellClip;
    [SerializeField] AudioClip touchClip;
    [SerializeField] AudioClip unlockClip; //#11

    [Header("사운드 플레이어")][Space(15f)]
    [SerializeField] AudioSource bgmPlayer;
    [SerializeField] AudioSource sfxPlayer;

    static SoundManager instance;
    public static SoundManager Instance => instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        PlayBgmSound();
    }

    //#1. bgm 재생(나중에 브금관리를 위해 따로 함수로 관리). by상훈_22.03.26
    public void PlayBgmSound()
    {
        bgmPlayer.clip = bgmClip;
        bgmPlayer.Play();
    }
    //#2. 버튼 사운드 재생
    public void PlayButtonSound()
    {
        sfxPlayer.clip = buttonClip;
        sfxPlayer.Play();
    }
    //#3. 구매 사운드 재생
    public void PlayBuySound()
    {
        sfxPlayer.clip = buyClip;
        sfxPlayer.Play();
    }
    //#4. 클리어 사운드 재생
    public void PlayClearSound()
    {
        sfxPlayer.clip = clearClip;
        sfxPlayer.Play();
    }
    //#5. 실패 사운드 재생
    public void PlayFailSound()
    {
        sfxPlayer.clip = fallClip;
        sfxPlayer.Play();
    }
    //#6. 성장 사운드 재생
    public void PlayGrowSound()
    {
        sfxPlayer.clip = growClip;
        sfxPlayer.Play();
    }
    //#7. 일시정지 사운드 재생
    public void PlayPauseInSound()
    {
        sfxPlayer.clip = pauseInClip;
        sfxPlayer.Play();
    }
    //#8. 일시정지 해제 사운드 재생
    public void PlayPauseOutSound()
    {
        sfxPlayer.clip = pauseOutClip;
        sfxPlayer.Play();
    }
    //#9. 판매 사운드 재생
    public void PlaySellSound()
    {
        sfxPlayer.clip = sellClip;
        sfxPlayer.Play();
    }
    //#10. 버튼 사운드 재생
    public void PlayTouchSound()
    {
        sfxPlayer.clip = touchClip;
        sfxPlayer.Play();
    }
    //#11. 버튼 사운드 재생
    public void PlayUnlockSound()
    {
        sfxPlayer.clip = unlockClip;
        sfxPlayer.Play();
    }

    #region 데이터관리
    public AudioSource BgmPlayer => bgmPlayer;
    public AudioSource SfxPlayer => sfxPlayer;
    #endregion
}
