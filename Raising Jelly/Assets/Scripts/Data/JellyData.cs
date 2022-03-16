using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JellyData
{
    public int id;
    public int level;
    public float exp;
    public int maxExp;

    public JellyData(int id, int level, float exp)
    {
        this.id = id;
        this.level = level;
        this.exp = exp;
    }
}
