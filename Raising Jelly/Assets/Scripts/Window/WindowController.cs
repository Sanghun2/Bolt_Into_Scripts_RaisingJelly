using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//팝업창을 움직이는 클래스
public class WindowController : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    //창 ON/OFF 기능. by상훈_22.03.03
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
