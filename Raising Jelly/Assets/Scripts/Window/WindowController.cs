using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�˾�â�� �����̴� Ŭ����
public class WindowController : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    //â ON/OFF ���. by����_22.03.03
    public void OpenWindow(bool isOpen)
    {
        if (isOpen)
        {
            anim.SetTrigger("doShow");
        }
        else
        {
            anim.SetTrigger("doHide");
        }
        
    }
}
