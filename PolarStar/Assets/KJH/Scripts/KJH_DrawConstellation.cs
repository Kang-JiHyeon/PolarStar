using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Pos1
{
    public float ra;   // ����
    public float dec;  // ����
}
public class KJH_DrawConstellation : MonoBehaviour
{
    public GameObject starFactory;
    public List<GameObject> starList = new List<GameObject>();
    public float r; // õ���� ������
    public GameObject temp;

    // ���ڸ� �̸�
    string[] names = { "�ϵ�ĥ��", "ī�ÿ����", "�ϱؼ�" };

    // �� ��ǥ ������ ����Ʈ
    List<List<float>> raList = new List<List<float>>();// ����
    List<List<float>> decList = new List<List<float>>();// ��

    // �ϵ�ĥ��
    List<float> ra12 = new List<float> { 13.4732f, 13.2355f, 12.5401f, 12.1525f, 11.5349f, 11.0150f, 11.0343f };  // ���� ������ ����
    List<float> dec12 = new List<float> { 49.1848f, 54.5531f, 55.5735f, 57.0157f, 53.4141f, 56.2256f, 61.4503f };

    // ī�ÿ����
    List<float> ra13 = new List<float> { 0.1024f, 0.4148f, 0.5806f, 1.2719f, 1.5603f };  // ���� ������ ����
    List<float> dec13 = new List<float> { 59.1621f, 56.3932f, 60.5010f, 60.2058f, 63.4638f };

    // �ϱؼ�
    List<float> ra14 = new List<float> { 2.3151f };
    List<float> dec14 = new List<float> { 89.2114f };


    // Start is called before the first frame update
    void Start()
    {
        raList.Add(ra12);
        raList.Add(ra13);
        raList.Add(ra14);

        decList.Add(dec12);
        decList.Add(dec13);
        decList.Add(dec14);

        for (int i = 0; i < raList.Count; i++)
        {
            DrawStar(raList[i], decList[i], i); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void DrawStar(List<float> ra, List<float> dec, int index)
    {
        GameObject go = Instantiate(temp);
        go.name = names[index];

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
}
