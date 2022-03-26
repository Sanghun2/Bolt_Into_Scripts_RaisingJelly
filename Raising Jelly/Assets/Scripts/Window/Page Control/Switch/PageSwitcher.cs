using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ �ȿ��� ������ �̵��� �����ϴ� Ŭ����
public class PageSwitcher : MonoBehaviour
{
    static int index;

    private static PageSwitcher instance;
    public static PageSwitcher Instance => instance;

    [Header("�Ŵ���")]
    [SerializeField] PageRenewer pageRenewer;
    [SerializeField] SoundManager soundManager;

    void Awake()
    {
        index = 1;
        instance = this;
    }

    void Start()
    {
        pageRenewer.RenewPage(index);
    }

    #region ������ �̵� �Լ�
    //���� �������� �̵�. by����_22.03.09
    public void PageDown()
    {
        if (index == 1) return;

        //�̵� �� �ε����� ���� ���� ���ΰ�ħ
        index -= 1;
        pageRenewer.RenewPage(index);
        soundManager.PlayButtonSound();
    }

    //���� �������� �̵�. by����_22.03.09
    public void PageUp()
    {
        if (index == JellyManager.HowManyJelly()) return;

        //�̵� �� �ε����� ���� ���� ���ΰ�ħ
        index += 1;
        pageRenewer.RenewPage(index);
        soundManager.PlayButtonSound();
    }
    #endregion

    #region ���� ����
    public int GetIndex() => index;
    #endregion
}
