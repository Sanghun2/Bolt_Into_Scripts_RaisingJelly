using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//윈도우 안에서 페이지 이동을 관리하는 클래스
public class PageSwitcher : MonoBehaviour
{
    static int index;

    private static PageSwitcher instance;
    public static PageSwitcher Instance => instance;

    [Header("매니저")]
    [SerializeField] PageRenewer pageRenewer;

    void Awake()
    {
        index = 1;
        instance = this;
    }

    void Start()
    {
        pageRenewer.RenewPage(index);
    }

    #region 페이지 이동 함수
    //이전 페이지로 이동. by상훈_22.03.09
    public void PageDown()
    {
        if (index == 1) return;

        //이동 후 인덱스에 따라 정보 새로고침
        index -= 1;
        pageRenewer.RenewPage(index);
    }

    //다음 페이지로 이동. by상훈_22.03.09
    public void PageUp()
    {
        if (index == JellyManager.HowManyJelly()) return;

        //이동 후 인덱스에 따라 정보 새로고침
        index += 1;
        pageRenewer.RenewPage(index);
    }
    #endregion

    #region 정보 관리
    public int GetIndex() => index;
    #endregion
}
