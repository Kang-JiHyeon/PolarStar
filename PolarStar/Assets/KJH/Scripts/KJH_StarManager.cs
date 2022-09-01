using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� �ð����� ���˺��� �����ϰ� �ʹ�.
// ȭ�� �ȿ��� �������� ��ġ�� �����ϰ� �ʹ�.
public class KJH_StarManager : MonoBehaviour
{
    public GameObject starFactory;
    public float createTime = 5f;
    float currentTime = 0f;
    Transform player;
    public float angle = 45f;
    public float a = 50f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > createTime)
        {
            // ���˺� ����

            GameObject star = Instantiate(starFactory);
            transform.forward = player.forward;
            star.transform.forward = transform.forward;
            
            float angle = Random.Range(-10, 10);
            float y = Random.Range(5f, 20f);

            
            float posX = a * Mathf.Tan(angle);

            star.transform.position = transform.right * posX + transform.up * y + transform.forward * a;

            // ���� ���� �ȿ����� ���˺��� �����ǰ� �ʹ�.     
            // ������ �� �� ��ġ�� �˰� �ʹ�.

            currentTime = 0f;
        }
    }
}
