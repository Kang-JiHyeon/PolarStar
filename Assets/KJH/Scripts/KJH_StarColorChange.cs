using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �νĵ� ���ڸ��� ������ �ٲٰ� �ʹ�.
// �ʿ�Ӽ� : �ٲ� ����, �νĵ� ���ڸ��� �ε���

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


    // ��� ���� ���ڸ��� ���� �����ϱ�
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
