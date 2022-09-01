using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �νĵ� ���ڸ��� ������ �ٲٰ� �ʹ�.
// �ʿ�Ӽ� : �ٲ� ����, �νĵ� ���ڸ��� �ε���

public class KJH_StarColorChange : MonoBehaviour
{
    int index;
    ParticleSystem ps;
    Color targetColor = new Vector4(1, 0.5f, 0, 1);
    Color getColor = new Vector4(0, 1, 0, 1);
    public bool isGetBadge = false;

    public static KJH_StarColorChange instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGetBadge)
        {
            ChangeColor(getColor);
            isGetBadge = false;
        }

        // ����� �����Ǹ� �ش� �ε����� ���ڸ��� ������ �ٲ۴�.
    }

    void ChangeColor(Color color)
    {
        var main = ps.main;
        main.startColor = color;
    }

    // ��� ���� ���ڸ��� ���� �����ϱ�
    public void HttpStarColorChange(GameObject stars)
    {
        for (int i = 0; i < stars.transform.childCount; i++)
        {
            ParticleSystem ps = stars.transform.GetChild(i).GetChild(0).GetComponent<ParticleSystem>();

            ChangeColor(targetColor);
        }
    }

    //// ���� �����ϰ� �ʹ�.
    //public void DrawStarHttp(List<float> ra, List<float> dec, string name)
    //{

    //    for (int i = 0; i < ra.Count; i++)
    //    {
    //        star.transform.parent = go.transform;
    //        // ���� : -> ��׸� -> ��������
    //        ra[i] = ra[i] * -15f * Mathf.PI / 180;

    //        // ���� : ��׸� -> ����
    //        dec[i] = dec[i] * (Mathf.PI / 180);
    //        dec[i] = (Mathf.PI / 2) - dec[i];

    //        var rr = r * Mathf.Sin(dec[i]);
    //        float z = rr * Mathf.Cos(ra[i]);
    //        float x = rr * Mathf.Sin(ra[i]);
    //        float y = r * Mathf.Cos(dec[i]);

    //        star.transform.position = Vector3.zero + new Vector3(x, y, z);
    //        //star.transform.position = new Vector3(x, y, z);
    //    }
    //}

}
