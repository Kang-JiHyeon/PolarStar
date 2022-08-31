using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// * ���˺�
// ���� �ð����� �밢�� �Ʒ��� �������� �ʹ�.
// 2. �밢�� �Ʒ� �������� �̵��Ѵ�.
// 2-1. �÷��̾��� �������� �������� �ʵ��� ���� ����

public class KJH_ShootingStar : MonoBehaviour
{
    
    public float fallSpeed = 5f;
    Vector3 fallDir;

    public float removeTime = 3f;
    float currentTime = 0f;
    float randX, randY;
    // Start is called before the first frame update
    void Start()
    {
        randX = Random.Range(-90f, 90f);
        randY = Random.Range(-20f, -30f);
    }

    // Update is called once per frame
    void Update()
    {
        // �����ð��� ������ �������� �ʹ�.
        currentTime += Time.deltaTime;

        if(currentTime > removeTime)
        {
            Destroy(gameObject);
        }

        // x��ǥ�� ���� ��ǥ�� �����Ѵ�.
        fallDir.x = randX;
        fallDir.y = randY;

        // ������ �������� �����Ѵ�.
        transform.position += fallDir.normalized * fallSpeed * Time.deltaTime;
    }

    //// �� ���ͻ����� ���� ��ȯ
    //public static float GetAngle(Vector3 vStart, Vector3 vEnd)
    //{
    //    Vector3 v = vEnd - vStart;

    //    return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
    //}
}
