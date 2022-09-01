using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ī�ÿ���� ������ : Caph, Shedir, Navi, Ruchbah, Segin

public class Cassiopeia : MonoBehaviour
{
    public GameObject[] stars = new GameObject[5];   // ���� ��
    float[] ra = new float[] { 0.1024f, 0.4148f, 0.5806f, 1.2719f, 1.5603f };  // ���� ������ ����
    float[] dec = new float[] { 59.1621f, 56.3932f, 60.5010f, 60.2058f, 63.4638f };
    // ���� ������ ����

    public float r; // õ���� ������

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

    // ��ǥ ����
    /*    void SphereToCartesian(float ra, float dec)
        {
            dec = (Mathf.PI / 2) - dec;
            var rr = r * Mathf.Sin(dec);
            z = rr * Mathf.Cos(ra);
            x = rr * Mathf.Sin(ra);
            y = rr * Mathf.Cos(dec);

            print(dec);
            print(x);
        }*/

    // ������ǥ�� ������ǥ��
    void DrawStar()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            // ���� : -> ��׸� -> ��������
            ra[i] = ra[i] * -15f * Mathf.PI / 180;

            // ���� : ��׸� -> ����
            dec[i] = dec[i] * Mathf.PI / 180;
            dec[i] = (Mathf.PI / 2) - dec[i];

            var rr = r * Mathf.Sin(dec[i]);
            z = rr * Mathf.Cos(ra[i]);
            x = rr * Mathf.Sin(ra[i]);
            y = r * Mathf.Cos(dec[i]);

            stars[i].transform.position = new Vector3(x, y, z);


        }

    }
}
