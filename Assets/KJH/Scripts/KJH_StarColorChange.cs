using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 인식된 별자리의 색상을 바꾸고 싶다.
// 필요속성 : 바꿀 색상, 인식된 별자리의 인덱스

public class KJH_StarColorChange : MonoBehaviour
{
    int index;
    Color targetColor = new Vector4(1, 0.5f, 0, 1);
    Color getColor = new Vector4(0, 1, 0, 1);
    public bool isGetBadge = false;

    public static KJH_StarColorChange instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    // 통신 받은 별자리의 색상 변경하기
    public void HttpStarColorChange(GameObject stars)
    {
        for (int i = 0; i < stars.transform.childCount; i++)
        {
            ParticleSystem ps = stars.transform.GetChild(i).GetChild(0).GetComponent<ParticleSystem>();
            var main = ps.main;
            main.startColor = targetColor;
        }
    }
}
