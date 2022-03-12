using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ ���¸� �����ϴ� Ŭ����
public class JellyManager : MonoBehaviour
{
    [Header("������ ���� ������")]
    public List<string> jellyNameList = new List<string>();
    public List<int> requiredJellatineList = new List<int>();
    public List<Sprite> jellyImageList = new List<Sprite>();
    static int numOfJelly;

    [Header("������ �ִϸ��̼� ��Ʈ�ѷ�")][Space(15f)]
    [Tooltip("������ ũ�⸦ �����ϴ� �ִϸ��̼� ��Ʈ�ѷ���.")]
    [SerializeField] RuntimeAnimatorController[] controller;
    int maxExpPerLevel => 30;

    public static JellyManager instance;

    void Awake()
    {
        instance = this;
        numOfJelly = jellyNameList.Count;
    }

    #region ���� ���� ����
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

    #endregion

    #region ���� ���� ����
    //������ �ʿ��� ����ġ�� ��ȯ�ϴ� �Լ�. by����_22.02.21
    public int MaxExpPerLevel() => maxExpPerLevel;
    //��ü ������ ���� ��ȯ�ϴ� �Լ�. by����_22.03.10
    public static int HowManyJelly() => numOfJelly;
    //Ư�� ���� �رݿ� �ʿ��� �� ��ȯ. by����_22.03.10
    public int ReqiredJellatine(int index) => requiredJellatineList[index - 1];
    #endregion
}
