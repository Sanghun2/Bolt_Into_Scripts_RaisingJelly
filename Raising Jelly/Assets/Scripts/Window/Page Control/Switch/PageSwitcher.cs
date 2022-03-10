using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//윈도우 안에서 페이지 이동을 관리하는 클래스
public class PageSwitcher : MonoBehaviour
{
    static int index;

    [Header("매니저")]
    [SerializeField] PageRenewer pageRenewer;

    void Awake()
    {
        index = 1;
    }

    void Start()
    {
        pageRenewer.RenewPage(index);
    }

    #region 페이지 이동 함수
    //이전 페이지로 이동하는 기능. by상훈_22.03.09
    public void PageDown()
    {
        if (index == 1) return;
        //이전 페이지로 이동
        index -= 1;
        //이동 후 인덱스에 따라 정보 새로고침
        pageRenewer.RenewPage(index);
    }

    //다음 페이지로 이동하는 기능. by상훈_22.03.09
    public void PageUp()
    {
        if (index == JellyManager.HowManyJelly()) return;
        //다음 페이지로 이동
        index += 1;
        //이동 후 인덱스에 따라 정보 새로고침
        pageRenewer.RenewPage(index);
    }
    #endregion
}
