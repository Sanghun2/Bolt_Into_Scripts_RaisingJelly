using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellManager : MonoBehaviour
{
    bool isSell;

    [Header("젤리가격")]
    [SerializeField] int[] jellyPrice;

    public static SellManager instance;

    void Awake()
    {
        instance = this;
    }

    //터치가 판매버튼 위에 들어갔을 때 실행. by상훈_22.02.26
    public void GetInToButton()
    {
        isSell = true;
    }

    //터치가 판매버튼에서 나왔을 때 실행. by상훈_22.02.26
    public void GetOutFromButton()
    {
        isSell = false;
    }

    //판매가능 상태 반환하는 기능. by상훈_22.02.26
    public bool IsSellable() => isSell;

    //젤리가격 반환하는 기능. by상훈_22.02.26
    public int GetJellyPrice(int id) => jellyPrice[id];
}
