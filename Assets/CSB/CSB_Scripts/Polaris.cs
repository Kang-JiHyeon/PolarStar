using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ϱؼ� ��ǥ�� ��..!!
public class Polaris : MonoBehaviour
{
    public float r; // õ���� ������

    float ra = 2.3151f;
    float dec = 89.2114f;

    // ��ȯ�� ���� ��ǥ
    float x;
    float y;
    float z;

    void Start()
    {
        DrawStar();
    }

    void Update()
    {
        
    }

    void DrawStar()
    {
        
        // ���� : -> ��׸� -> ��������
        ra = ra * -15f * Mathf.PI / 180;

        // ���� : ��׸� -> ����
        dec = dec * Mathf.PI / 180;
        dec = (Mathf.PI / 2) - dec;

        var rr = r * Mathf.Sin(dec);
        z = rr * Mathf.Cos(ra);
        x = rr * Mathf.Sin(ra);
        y = r * Mathf.Cos(dec);

        
        transform.position = new Vector3(x, y, z);


        

    }
}
