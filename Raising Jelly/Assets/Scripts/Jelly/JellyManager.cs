using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������� ���¸� �����ϴ� Ŭ����
public class JellyManager : MonoBehaviour
{
    [Header("���� ������")]
    public List<string> jellyNameList = new List<string>();
    public List<Sprite> jellyImageList = new List<Sprite>();
    public float[] shadowPos;
    static int numOfJelly;

    [Header("���� ����")]
    [Space(15f)]
    [Tooltip("���� ������")]
    [SerializeField] GameObject jellyPrefab;
    [Tooltip("�����Ǵ� ��ġ")]
    [SerializeField] Transform spawnPoint;

    [Header("������ ���� ����Ʈ")]
    [Space(15f)]
    List<GameObject> jellyList = new List<GameObject>();

    [Header("������ �ִϸ��̼� ��Ʈ�ѷ�")][Space(15f)]
    [Tooltip("������ ũ�⸦ �����ϴ� �ִϸ��̼� ��Ʈ�ѷ���.")]
    [SerializeField] RuntimeAnimatorController[] controller;
    int maxExpPerLevel => 30;

    static JellyManager instance;
    public static JellyManager Instance => instance;

    void Awake()
    {
        instance = this;
        numOfJelly = jellyNameList.Count;
    }

    #region ���� ����
    //���� ������ ���. by����_22.02.21
    public void LevelUp(Jelly jelly)
    {
        //3�϶��� ������X
        if (jelly.CurLevel == 3) return;

        //3�� �ƴ϶�� ������
        jelly.SetLevel(jelly.CurLevel + 1);
        //����ġ �ʱ�ȭ
        jelly.SetExp(0);
        //�ʿ� ����ġ ����
        jelly.SetMaxExp(jelly.CurLevel*maxExpPerLevel);
        //������ ������ ����
        jelly.SetController(ChangeController(jelly.CurLevel));
    }

    //������ ��Ʈ�ѷ��� �����ϴ� ���. by����_22.02.21
    public RuntimeAnimatorController ChangeController(int level) => controller[level-1];

    #endregion

    #region ���� ����
    //��������. by����_22.03.14
    public void CreateJelly(int id)
    {
        GameObject jelly = Instantiate(jellyPrefab, spawnPoint);
        Jelly jellyInfo = jelly.GetComponent<Jelly>();
        Animator jellyAnim = jelly.GetComponent<Animator>();
        SpriteRenderer jellySprite = jelly.GetComponent<SpriteRenderer>();
        jellyInfo.SetID(id);
        jellyInfo.SetLevel(1);
        jellyInfo.SetExp(0);
        jellyInfo.SetMaxExp(jellyInfo.CurLevel * maxExpPerLevel);

        jellyAnim.runtimeAnimatorController = controller[jellyInfo.CurLevel - 1];
        jellySprite.sprite = jellyImageList[id];

        AddJellyToList(jelly);
        GameData.Instance.SaveJellyAll(jellyList);
    }

    //������ ���� ����Ʈ�� �߰�. by����_22.03.16
    public void AddJellyToList(GameObject jellyObj)
    {
        jellyList.Add(jellyObj);
    }

    //�Ǹŵ� ���� ����Ʈ���� ����. by����_22.03.16
    public void RemoveJellyFromList(GameObject jellyObj)
    {
        jellyList.Remove(jellyObj);
    }
    #endregion

    #region ���� ����
    //������ �ʿ��� ����ġ�� ��ȯ�ϴ� �Լ�. by����_22.02.21
    public int MaxExpPerLevel() => maxExpPerLevel;
    //��ü ������ ���� ��ȯ�ϴ� �Լ�. by����_22.03.10
    public static int HowManyJelly() => numOfJelly;
    //Ư�� ���� �رݿ� �ʿ��� �� ��ȯ. by����_22.03.10
    public int ReqiredJellatine(int index) => BuyManager.Instance.requiredJellatineList[index - 1];
    public int ReqiredGold(int index) => BuyManager.Instance.requiredGoldList[index - 1];
    
    //���� �׸����� ������ ��ȯ. by����_22.03.14
    public float GetShadowPos(int id){
        switch (id)
        {
            case 0:
                return shadowPos[0];
            case 3:
                return shadowPos[1];
            case 6:
                return shadowPos[2];
            case 10:
            case 11:
            default:
                return shadowPos[3];
        }
    }

    //���� ���� ����Ʈ ��ȯ. by����_22.03.16
    public List<GameObject> GetJellyList() => jellyList;
    //���� ���� �� ��ȯ
    public int CurJellyCount => jellyList.Count;
    #endregion
}
