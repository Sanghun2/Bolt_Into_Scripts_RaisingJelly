using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ȭ�鿡 ���̴� UI�� �����ϴ� Ŭ����
public class UIManager : MonoBehaviour
{
    [SerializeField] Text goldText;
    [SerializeField] Text jellatineText;

    //���� �ִ� ��ȭ�� ǥ���ϴ� ���. by����_22.02.14
    public void SetGoldText(int gold)
    {
        goldText.text = gold.ToString();
    }
    public void SetjellatineText(int jellatine)
    {
        jellatineText.text = jellatine.ToString();
    }
}
