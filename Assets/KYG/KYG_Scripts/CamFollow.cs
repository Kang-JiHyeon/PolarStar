using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    //Campos �� ����ٴϰ� �ʹ�.
    //�ʿ�Ӽ� : campos, �ӵ�

    public Transform campos;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Campos�� ����ٴϰ� �ʹ�.
        transform.position = Vector3.Lerp(transform.position, campos.position, speed * Time.deltaTime);
        //ȸ��
        transform.rotation = Quaternion.Lerp(transform.rotation, campos.rotation, speed * Time.deltaTime);
    }
}
