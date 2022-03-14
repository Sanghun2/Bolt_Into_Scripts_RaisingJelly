using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ ���� �����͸� �ٷ�� Ŭ����
public class GameData : MonoBehaviour
{
    [SerializeField] bool[] unlockList; //�رݿ��� ����Ʈ

    static GameData instance;
    public static GameData Instance => instance;

    void Awake()
    {
        instance = this;

        for (int i = 0; i < unlockList.Length; i++)
        {
            unlockList[i] = false; //���߿� ����� ������ �о�ͼ� ����
        }
    }

    #region �ر� ������ ����
    //�ر� ������ ���� �� ��ȯ. by����_22.03.10
    public void SetUnlockData(int index, bool isTrue) => unlockList[index - 1] = isTrue;
    public bool GetUnlockData(int index) => unlockList[index - 1]; //������ �Ű����� �ε����� �׻� ������ 1 �����̹Ƿ� -1 ó��
    #endregion
}
