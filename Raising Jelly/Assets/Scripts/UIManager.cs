using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//화면에 보이는 UI를 관리하는 클래스
public class UIManager : MonoBehaviour
{
    [SerializeField] Text goldText;
    [SerializeField] Text jellatineText;

    //갖고 있는 재화를 표시하는 기능. by상훈_22.02.14
    public void SetGoldText(int gold)
    {
        goldText.text = gold.ToString();
    }
    public void SetjellatineText(int jellatine)
    {
        jellatineText.text = jellatine.ToString();
    }
}
