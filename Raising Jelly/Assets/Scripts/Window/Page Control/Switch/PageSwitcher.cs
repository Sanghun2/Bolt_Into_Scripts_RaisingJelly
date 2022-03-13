using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ �ȿ��� ������ �̵��� �����ϴ� Ŭ����
public class PageSwitcher : MonoBehaviour
{
    static int index;

    [Header("�Ŵ���")]
    [SerializeField] PageRenewer pageRenewer;

    void Awake()
    {
        index = 1;
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
    }

    //���� �������� �̵�. by����_22.03.09
    public void PageUp()
    {
        if (index == JellyManager.HowManyJelly()) return;

        //�̵� �� �ε����� ���� ���� ���ΰ�ħ
        index += 1;
        pageRenewer.RenewPage(index);
    }
    #endregion

    #region ���� ����
    public int GetIndex() => index;
    #endregion
}
