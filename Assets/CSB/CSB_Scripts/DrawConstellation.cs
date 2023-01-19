using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Pos
{
    public float ra;   // ����
    public float dec;  // ����
}
public class DrawConstellation : MonoBehaviour
{
    public GameObject starFactory;

    public List<GameObject> starList = new List<GameObject>();
    
    //public List<Pos> posList = new List<Pos>();    // ��ǥ Ŭ������ ���� ����Ʈ

    // GameObject[] stars = new GameObject[];   // ���� ��
    // public float[] ra = new float[] { 13.4732f, 13.2355f, 12.5401f, 12.1525f, 11.5349f, 11.0150f, 11.0343f };  // ���� ������ ����
    // public float[] dec = new float[] { 49.1848f, 54.5531f, 55.5735f, 57.0157f, 53.4141f, 56.2256f, 61.4503f };
    // ���� ������ ����

    public float r; // õ���� ������


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawStar(float[] ra, float[] dec)
    {
        for (int i = 0; i < ra.Length; i++)
        {
            GameObject star = Instantiate(starFactory);

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
