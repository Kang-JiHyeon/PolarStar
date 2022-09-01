using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� ���� ���� ��ġ�� ���� ũ��� ���� �����ϰ� �ʹ�.
public class KJH_Star : MonoBehaviour
{
    public float radio = 300f;
    public float starAmount = 100f;
    public GameObject starFactory;


    // Start is called before the first frame update
    void Start()
    {
        float randSize = Random.Range(1f, 5f);

        for (int i = 0; i < starAmount; i++)
        {
            GameObject star = Instantiate(starFactory);

            star.transform.position = Random.onUnitSphere * radio;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
