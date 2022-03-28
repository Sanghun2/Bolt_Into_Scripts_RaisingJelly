using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���带 �����ϴ� Ŭ����
public class SoundManager : MonoBehaviour
{
    [Header("���� Ŭ��")]
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

    [Header("���� �÷��̾�")][Space(15f)]
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

    //#1. bgm ���(���߿� ��ݰ����� ���� ���� �Լ��� ����). by����_22.03.26
    public void PlayBgmSound()
    {
        bgmPlayer.clip = bgmClip;
        bgmPlayer.Play();
    }
    //#2. ��ư ���� ���
    public void PlayButtonSound()
    {
        sfxPlayer.clip = buttonClip;
        sfxPlayer.Play();
    }
    //#3. ���� ���� ���
    public void PlayBuySound()
    {
        sfxPlayer.clip = buyClip;
        sfxPlayer.Play();
    }
    //#4. Ŭ���� ���� ���
    public void PlayClearSound()
    {
        sfxPlayer.clip = clearClip;
        sfxPlayer.Play();
    }
    //#5. ���� ���� ���
    public void PlayFailSound()
    {
        sfxPlayer.clip = fallClip;
        sfxPlayer.Play();
    }
    //#6. ���� ���� ���
    public void PlayGrowSound()
    {
        sfxPlayer.clip = growClip;
        sfxPlayer.Play();
    }
    //#7. �Ͻ����� ���� ���
    public void PlayPauseInSound()
    {
        sfxPlayer.clip = pauseInClip;
        sfxPlayer.Play();
    }
    //#8. �Ͻ����� ���� ���� ���
    public void PlayPauseOutSound()
    {
        sfxPlayer.clip = pauseOutClip;
        sfxPlayer.Play();
    }
    //#9. �Ǹ� ���� ���
    public void PlaySellSound()
    {
        sfxPlayer.clip = sellClip;
        sfxPlayer.Play();
    }
    //#10. ��ư ���� ���
    public void PlayTouchSound()
    {
        sfxPlayer.clip = touchClip;
        sfxPlayer.Play();
    }
    //#11. ��ư ���� ���
    public void PlayUnlockSound()
    {
        sfxPlayer.clip = unlockClip;
        sfxPlayer.Play();
    }

    #region �����Ͱ���
    public AudioSource BgmPlayer => bgmPlayer;
    public AudioSource SfxPlayer => sfxPlayer;
    #endregion
}
