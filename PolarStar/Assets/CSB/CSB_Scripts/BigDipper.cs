using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ϵ�ĥ�� �׸���
// ���� �� : Alkaid, Mizar, Alioth, Megrez, Phecda, Dubhe, Merak
// -> ���� ���� �迭�� ������Ƥ���....? ������ ��ġ�� ����
// 
// �ʿ��� ���� ���� : ����, ����, �Ѻ��� ���
// �����, ������, x, y, z��

public class BigDipper : MonoBehaviour
{
    List<GameObject> starList = new List<GameObject>();
    // GameObject[] stars = new GameObject[];   // ���� ��
    float[] ra = new float[] { 13.4732f, 13.2355f, 12.5401f, 12.1525f, 11.5349f, 11.0150f, 11.0343f };  // ���� ������ ����
    float[] dec = new float[] { 49.1848f, 54.5531f, 55.5735f, 57.0157f, 53.4141f, 56.2256f, 61.4503f };
        // ���� ������ ����

    public float r; // õ���� ������

    //float ra = 13.4732f;    // ����
    //float dec = 49.1848f;   // ����

    // ��ȯ�� ���� ��ǥ
    float x;
    float y;
    float z;

    void Start()
    {
        for(int i = 0; i< transform.childCount; i++)
        {
            starList.Add(transform.GetChild(i).gameObject);
        }
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

    // ���� ��������
    //float deg2rad = 0.017453f;

    // ������ǥ�� ������ǥ��
    void DrawStar()
    {
        for(int i = 0; i < starList.Count; i++)
        {
            // ���� : -> ��׸� -> ��������
            ra[i] = ra[i] * -15f * Mathf.PI / 180;

            // ���� : ��׸� -> ����
            dec[i] = dec[i] * (Mathf.PI / 180);
            dec[i] = (Mathf.PI / 2) - dec[i];

            var rr = r * Mathf.Sin(dec[i]);
            z = rr * Mathf.Cos(ra[i]);
            x = rr * Mathf.Sin(ra[i]);
            y = r * Mathf.Cos(dec[i]);

            starList[i].transform.position = new Vector3(x, y, z);


        }
        // ���� : -> ��׸� -> ��������
        //ra = ra * -15f * Mathf.PI/180;
        
        // ���� : ��׸� -> ����
        //dec = (Mathf.PI / 2) - dec;
        //dec = dec * Mathf.PI / 180;

        //var rr = r * Mathf.Sin(dec);
        //z = rr * Mathf.Cos(ra);
        //x = rr * Mathf.Sin(ra);
        //y = r * Mathf.Cos(dec);

    }

    // 
}
