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

    #region ��ġ��ǥ ������ �ٷ�� ���
    public static Vector2 GetTouchPos() => touchPos;
    public static Vector3 GetTouchPos_3() => touchPos;
    #endregion
}
