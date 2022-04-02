using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI���� �����ϴ� Ŭ����
public class ColorManager : MonoBehaviour
{
    [Header("����")]
    [SerializeField] Color positiveColor;
    [SerializeField] Color negativeColor;

    static ColorManager instance;
    public static ColorManager Instance => instance;

    void Awake()
    {
        instance = this;
    }

    public Color MakePositive() => positiveColor; //83EAFF
    public Color MakeNegative() => negativeColor; //FF4912
}
