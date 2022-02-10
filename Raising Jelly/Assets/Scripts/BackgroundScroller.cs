using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//배경 스크롤링을 관리하는 클래스
public class BackgroundScroller : MonoBehaviour
{
    [Header("구름")]
    [SerializeField] Transform[] cloud;
    [SerializeField] float speed;
    Vector3 moveVec;

    void Start()
    {
        moveVec = Vector3.right;
    }

    void Update()
    {
        foreach (var obj in cloud)
        {
            obj.Translate(moveVec*speed*Time.deltaTime);
            if (obj.localPosition.x > 9) Reposition(obj);
        }
    }

    void Reposition(Transform obj)
    {
        int randomPos = Random.Range(-21, -18);
        obj.Translate(moveVec*randomPos);
    }
}
