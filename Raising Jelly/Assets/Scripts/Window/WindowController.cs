using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//팝업창을 움직이는 클래스
public class WindowController : MonoBehaviour
{
    Animator anim;
    YieldInstruction waitFor_n_Sec;

    void Awake()
    {
        anim = GetComponent<Animator>();
        waitFor_n_Sec = new WaitForSeconds(0.5f);
    }

    //창 닫는 기능. by상훈_22.03.03
    public void CloseWindow()
    {
        anim.SetTrigger("doHide");
        StartCoroutine(DeactivateWindow());
    }

    //n초 후 창을 비활성화하는 기능. by상훈_22.03.03
    IEnumerator DeactivateWindow()
    {
        yield return waitFor_n_Sec;
        gameObject.SetActive(false);
    }
}
