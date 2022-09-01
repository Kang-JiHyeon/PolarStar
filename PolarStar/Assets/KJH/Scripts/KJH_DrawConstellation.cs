using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public struct Pos1

{
    public float ra;   // ����
    public float dec;  // ����
}
public class KJH_DrawConstellation : MonoBehaviour
{
    public GameObject starFactory;
    public GameObject httpStarFactory;
    public List<GameObject> starList = new List<GameObject>();
    public float r; // õ���� ������
    public GameObject temp;

    // ���ڸ� �̸�
    string[] names = { "���ڸ�", "Ȳ���ڸ�", "�ϵ�ĥ��", "ī�ÿ����", "�ϱؼ�" };

    // �� ��ǥ ������ ����Ʈ
    List<List<float>> raList = new List<List<float>>(); // ����
    List<List<float>> decList = new List<List<float>>();// ��

    // ���ڸ�(0)
    List<float> ra0 = new List<float> { 2.5119f, 2.0827f, 1.5553f, 1.5446f };
    List<float> dec0 = new List<float> { 27.2109f, 23.3407f, 20.5505f, 19.2416f };

    // Ȳ���ڸ�(1)
    List<float> ra1 = new List<float> { 5.2742f, 4.4335f, 4.2955f, 5.3858f, 4.3712f, 4.2956f, 4.2647f, 4.2413f, 4.2104f, 4.0155f, 3.2601f };
    List<float> dec1 = new List<float> { 28.3731f, 22.5958f, 19.1349f, 21.0922f, 16.3317f, 15.5516f, 17.5846f, 17.3543f, 15.4056f, 12.3316f, 9.0632f };

    // �ֵ����ڸ�(2)
    List<float> ra2 = new List<float> { 7.4640f, 7.3717f, 7.4547f, 7.2126f, 7.1922f, 6.4632f, 7.0525f, 6.3859f, 7.2706f, 7.3600f, 7.1233f, 6.5415f, 6.4517f, 6.2418f, 6.3017f, 6.1613f, 6.0528f };
    List<float> dec2 = new List<float> { 27.5819f, 26.5045f, 24.2040f, 21.5629f, 16.3002f, 12.5220f, 20.3216f, 16.2250f, 27.4512f, 31.5018f, 30.1228f, 33.5559f, 25.0631f, 22.3007f, 20.1153f, 22.3000f, 23.1542f };

    // ���ڸ�(3)
    List<float> ra3 = new List<float> { 8.4801f, 8.2124f, 8.4433f, 8.4556f, 8.5941f, 8.1742f };
    List<float> dec3 = new List<float> { 28.4042f, 27.0843f, 21.2320f, 18.0423f, 11.4621f, 9.0705f };

    // �����ڸ�(4)
    List<float> ra4 = new List<float> { 9.4706f, 9.5400f, 10.1754f, 10.2111f, 10.0831f, 10.0932f, 11.1523f, 11.5011f, 11.1516f };
    List<float> dec4 = new List<float> { 23.4021f, 25.5410f, 23.1826f, 19.4347f, 16.3918f, 11.5134f, 15.1833f, 14.2656f, 20.2411f };

    // ó���ڸ�(5)
    List<float> ra5 = new List<float> { 14.4722f, 14.0246f, 13.3549f, 12.5643f, 13.0316f, 12.4246f, 13.2621f, 14.1404f, 14.1710f, 14.4414f, 12.2102f, 11.4659f };
    List<float> dec5 = new List<float> { 1.4801f, 1.2617f, -0.4230f, 3.1640f, 10.5028f, -1.3412f, -11.1637f, -10.2236f, -6.0621f, -5.4515f, -0.4722f, 6.2421f };

    // õĪ�ڸ�(6)
    List<float> ra6 = new List<float> { 15.5506f, 15.3646f, 15.1812f, 14.5206f, 15.0522f };
    List<float> dec6 = new List<float> { -16.474f, -14.5149f, -9.2752f, -16.0803f, -25.2212f };

    // �����ڸ�(7)
    List<float> ra7 = new List<float> { 16.0644f, 16.0139f, 16.3047f, 16.0012f, 16.0012f, 16.5137f, 16.5323f, 16.5610f, 16.5610f, 17.3856f, 17.4909f, 17.4402f, 17.3508f };
    List<float> dec7 = new List<float> { -19.5159f, -22.4108f, -26.2855f, -26.1044f, -26.1044f, -34.2005f, -38.0513f, -42.2404f, -42.2404f, -43.0048f, -40.0812f, -39.0233f, -37.0716f};

    // �ü��ڸ�(8)
    List<float> ra8 = new List<float> { 17.4858f, 18.0715f, 18.2540f, 18.1909f, 19.0403f, 18.4704f, 18.2226f, 18.2922f, 18.1506f, 18.5640f, 19.0821f, 19.3724f, 20.0403f, 20.0112f, 19.5649f, 19.2451f, 19.2527f, 18.5904f, 19.0602f, 19.1857f, 19.2259f };
    List<float> dec8 = new List<float> { -27.5022f, -30.2526f, -34.2228f, -36.4520f, -29.5052f, -26.5803f, -29.4907f, -25.2433f, -21.0309f, -26.1607f, -27.3815f, -24.4009f, -27.3849f, -35.1256f, -41.4834f, -44.4529f, -40.3427f, -21.0435f, -21.4229f, -18.5443f, -17.4814f };

    // �����ڸ�(9)
    List<float> ra9 = new List<float> { 20.1854f, 20.2203f, 20.4726f, 20.531f, 21.0713f, 21.2758f, 21.233f, 21.4121f, 21.4817f };
    List<float> dec9 = new List<float> { -12.2614f, -14.4246f, -25.1121f, -26.5003f, -17.0832f, -22.1846f, -16.4414f, -16.3333f, -16.0125f };


    // �����ڸ�(10)
    List<float> ra10 = new List<float> { 20.4854f, 21.3245f, 22.0657f, 22.225f, 22.3f, 22.3631f, 22.5348f, 23.1705f, 23.241f, 23.1039f, 22.5551f, 22.5048f, 22.3151f, 22.1802f, 22.074f };
    List<float> dec10 = new List<float> { -9.2443f, -5.2814f, -0.1231f, -1.162f, 0.0549f, 0f, -7.2729f, -8.5748f, -19.5832f, -21.0254f, -15.4157f, -13.2819f, -10.334f, -7.40101f, -13.4532f };

    // ������ڸ�(11)
    List<float> ra11 = new List<float> { 1.0404f, 1.2043f, 1.1459f, 1.3242f, 1.4635f, 2.0313f, 1.5443f, 1.4236f, 1.3122f, 1.0407f, 0.4951f, 0.2146f, 0.0029f, 23.4107f, 23.2907f, 23.182f, 23.2806f, 23.4312f };
    List<float> dec11 = new List<float> { 31.5529f, 27.2255f, 24.421f, 15.2744f, 9.1619f, 2.5226f, 3.18f, 5.361f, 6.154f, 8.0045f, 7.4231f, 8.1859f, 6.5921f, 5.4459f, 6.3014f, 3.2424f, 1.2249f, 1.5419f };


    // �ϵ�ĥ��(12)
    List<float> ra12 = new List<float> { 13.4732f, 13.2355f, 12.5401f, 12.1525f, 11.5349f, 11.0150f, 11.0343f };  // ���� ������ ����
    List<float> dec12 = new List<float> { 49.1848f, 54.5531f, 55.5735f, 57.0157f, 53.4141f, 56.2256f, 61.4503f };

    // ī�ÿ����(13)
    List<float> ra13 = new List<float> { 0.1024f, 0.4148f, 0.5806f, 1.2719f, 1.5603f };  // ���� ������ ����
    List<float> dec13 = new List<float> { 59.1621f, 56.3932f, 60.5010f, 60.2058f, 63.4638f };

    // �ϱؼ�(14)
    List<float> ra14 = new List<float> { 2.3151f };
    List<float> dec14 = new List<float> { 89.2114f };


    // Start is called before the first frame update
    void Start()
    {
        // ����
        raList.Add(ra0);
        raList.Add(ra1);
        raList.Add(ra2);
        raList.Add(ra3);
        raList.Add(ra4);
        raList.Add(ra5);
        raList.Add(ra6);
        raList.Add(ra7);
        raList.Add(ra8);
        raList.Add(ra9);
        raList.Add(ra10);
        raList.Add(ra11);
        raList.Add(ra12);
        raList.Add(ra13);
        raList.Add(ra14);

        // ����
        decList.Add(dec0);
        decList.Add(dec1);
        decList.Add(dec2);
        decList.Add(dec3);
        decList.Add(dec4);
        decList.Add(dec5);
        decList.Add(dec6);
        decList.Add(dec7);
        decList.Add(dec8);
        decList.Add(dec9);
        decList.Add(dec10);
        decList.Add(dec11);
        decList.Add(dec12);
        decList.Add(dec13);
        decList.Add(dec14);



        for (int i = 0; i < raList.Count; i++)
        {
            DrawStarAll(raList[i], decList[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            HTTPRequester hTTPRequester = new HTTPRequester();

            hTTPRequester.url = "https://92c9-175-223-17-145.jp.ngrok.io/get_location";
            hTTPRequester.requestType = RequestType.GET;
            hTTPRequester.onComplete = CallBack;

            HTTPManager.instance.SendRequest(hTTPRequester);

        }
    }

    void CallBack(DownloadHandler downloadHandler)
    {
        Constellation co = JsonUtility.FromJson<Constellation>(downloadHandler.text);
        print(co.name);
        print(co.index);

        DrawStarHttp(raList[co.index], decList[co.index], co.name);

    }

    // ���ڸ� �׸���
    public void DrawStarAll(List<float> ra, List<float> dec)
    {
        GameObject go = Instantiate(temp);

        for (int i = 0; i < ra.Count; i++)
        {
            GameObject star = Instantiate(starFactory);
            star.transform.parent = go.transform;
            // ���� : -> ��׸� -> ��������
            ra[i] = ra[i] * -15f * Mathf.PI / 180;

            // ���� : ��׸� -> ����
            dec[i] = dec[i] * (Mathf.PI / 180);
            dec[i] = (Mathf.PI / 2) - dec[i];

            var rr = r * Mathf.Sin(dec[i]);
            float z = rr * Mathf.Cos(ra[i]);
            float x = rr * Mathf.Sin(ra[i]);
            float y = r * Mathf.Cos(dec[i]);

            // starList[i].transform.position = Vector3.zero + new Vector3(x, y, z);
            star.transform.position = new Vector3(x, y, z);
        }
    }

    // ���ڸ� �׸���
    public void DrawStarHttp(List<float> ra, List<float> dec, string name)
    {
        GameObject go = Instantiate(temp);
        go.transform.position = Vector3.zero;
        go.name = name;

        for (int i = 0; i < ra.Count; i++)
        {
            GameObject star = Instantiate(httpStarFactory);
            star.transform.parent = go.transform;
            // ���� : -> ��׸� -> ��������
            ra[i] = ra[i] * -15f * Mathf.PI / 180;

            // ���� : ��׸� -> ����
            dec[i] = dec[i] * (Mathf.PI / 180);
            dec[i] = (Mathf.PI / 2) - dec[i];

            var rr = r * Mathf.Sin(dec[i]);
            float z = rr * Mathf.Cos(ra[i]);
            float x = rr * Mathf.Sin(ra[i]);
            float y = r * Mathf.Cos(dec[i]);

            star.transform.position = Vector3.zero + new Vector3(x, y, z);
            //star.transform.position = new Vector3(x, y, z);
        }
    }
}
