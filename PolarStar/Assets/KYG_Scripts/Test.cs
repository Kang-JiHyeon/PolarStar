using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Vector3 yVelocity = Vector3.zero;
    float gravity = -10;
    public Transform target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. �߷��� ������ ������ ���Ѵ�.
        Vector3 dir = (transform.position - target.position).normalized;


        // 2. ���� ��ġ���� �߷� �������� �̵��Ѵ�.
        transform.position += dir * gravity * Time.deltaTime;

        // 3. ���� �� ������ �߷��� �ݴ� �������� �ٲ۴�.
        transform.up = dir * -1;

        
    }
}
