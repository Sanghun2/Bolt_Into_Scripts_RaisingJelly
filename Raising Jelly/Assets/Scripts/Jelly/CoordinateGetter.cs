using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateGetter : MonoBehaviour
{
    static Vector2 touchPos;

    void Update()
    {
        touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    #region 터치좌표 정보를 다루는 기능
    public static Vector2 GetTouchPos() => touchPos;
    public static Vector3 GetTouchPos_3() => touchPos;
    #endregion
}
