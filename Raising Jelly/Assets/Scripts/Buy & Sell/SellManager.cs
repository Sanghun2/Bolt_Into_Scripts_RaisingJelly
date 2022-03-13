using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellManager : MonoBehaviour
{
    bool isSell;

    [Header("��������")]
    [SerializeField] int[] jellyPrice;

    public static SellManager instance;

    void Awake()
    {
        instance = this;
    }

    //��ġ�� �ǸŹ�ư ���� ���� �� ����. by����_22.02.26
    public void GetInToButton()
    {
        isSell = true;
    }

    //��ġ�� �ǸŹ�ư���� ������ �� ����. by����_22.02.26
    public void GetOutFromButton()
    {
        isSell = false;
    }

    //�ǸŰ��� ���� ��ȯ�ϴ� ���. by����_22.02.26
    public bool IsSellable() => isSell;

    //�������� ��ȯ�ϴ� ���. by����_22.02.26
    public int GetJellyPrice(int id) => jellyPrice[id];
}
