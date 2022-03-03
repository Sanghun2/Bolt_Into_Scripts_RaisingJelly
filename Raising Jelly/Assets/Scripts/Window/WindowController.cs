using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�˾�â�� �����̴� Ŭ����
public class WindowController : MonoBehaviour
{
    Animator anim;
    YieldInstruction waitFor_n_Sec;

    void Awake()
    {
        anim = GetComponent<Animator>();
        waitFor_n_Sec = new WaitForSeconds(0.5f);
    }

    //â �ݴ� ���. by����_22.03.03
    public void CloseWindow()
    {
        anim.SetTrigger("doHide");
        StartCoroutine(DeactivateWindow());
    }

    //n�� �� â�� ��Ȱ��ȭ�ϴ� ���. by����_22.03.03
    IEnumerator DeactivateWindow()
    {
        yield return waitFor_n_Sec;
        gameObject.SetActive(false);
    }
}
