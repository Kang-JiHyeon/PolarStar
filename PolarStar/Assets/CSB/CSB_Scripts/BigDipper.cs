using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ϵ�ĥ�� �׸���
// ���� �� : Alkaid, Mizar, Alioth, Megrez, Phecda, Dubhe, Merak
// -> ���� ���� �迭�� ������Ƥ���....? ������ ��ġ�� ����
// 
// �ʿ��� ���� ���� : ����, ����, �Ѻ��� ���
// �����, ������, x, y, z��

public class BigDipper : DrawConstellation
{
    // List<Pos> list = new List<Pos>();
    // List<GameObject> starList = new List<GameObject>();
    // GameObject[] stars = new GameObject[];   // ���� ��
    // Pos pos = new Pos();

    float[] ra1 = new float[] { 13.4732f, 13.2355f, 12.5401f, 12.1525f, 11.5349f, 11.0150f, 11.0343f };  // ���� ������ ����
    float[] dec1 = new float[] { 49.1848f, 54.5531f, 55.5735f, 57.0157f, 53.4141f, 56.2256f, 61.4503f };
    // ���� ������ ����


    void Start()
    {
        /*        for(int i = 0; i< transform.childCount; i++)
                {
                    starList.Add(transform.GetChild(i).gameObject);
                }
                DrawStar();*/

        // �θ� start �Լ� ����
        // base.Start();

        // ���� ������Ʈ ����
        // for (int i = 0; i < ra1.Length; i++)
        // {
        //GameObject starPos = Instantiate(starFactory);
        //starList.Add(starPos);
        //}

        base.DrawStar(ra1, dec1);

        //list = RestructData(ra1, dec1);


    }

    // ����, �浵 �迭�� �ϳ��� ����Ʈ�� ��ȯ�ϴ� �Լ�
    List<Pos> RestructData(float[] d1, float[] d2)
    {
        List<Pos> datas = new List<Pos>();

        for (int i = 0; i < d1.Length; i++)
        {
            Pos myPos = new Pos();
            myPos.ra = d1[i];
            myPos.dec = d2[i];
            datas.Add(myPos);
        }

        return datas;
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
    /*void DrawStar()
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

    }*/

    // 
}
