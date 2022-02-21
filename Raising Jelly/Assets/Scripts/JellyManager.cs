using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ ���¸� �����ϴ� Ŭ����
public class JellyManager : MonoBehaviour
{
    [SerializeField] RuntimeAnimatorController[] controller;
    int maxExpPerLevel => 30;

    public static JellyManager instance;

    void Awake()
    {
        instance = this;
    }

    //���� ������ ���. by����_22.02.21
    public void LevelUp(Jelly jelly)
    {
        //3�϶��� ������X
        if (jelly.CurLevel() == 3) return;

        //3�� �ƴ϶�� ������
        jelly.SetLevel(jelly.CurLevel() + 1);
        //����ġ �ʱ�ȭ
        jelly.SetExp(0);
        //�ʿ� ����ġ ����
        jelly.SetMaxExp(jelly.CurLevel()*maxExpPerLevel);
        //������ ������ ����
        jelly.SetController(ChangeController(jelly.CurLevel()));
    }

    //������ ��Ʈ�ѷ��� �����ϴ� ���. by����_22.02.21
    public RuntimeAnimatorController ChangeController(int level) => controller[level-1];

    //������ �ʿ��� ����ġ�� ��ȯ�ϴ� �Լ�. by����_22.02.21
    public int MaxExpPerLevel() => maxExpPerLevel;
}