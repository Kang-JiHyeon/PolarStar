using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    //�ʿ�Ӽ� : ȸ���ӵ�
    public float rotSpeed = 205;



    //�츮�� ���� ������ ��������
    float mx;
    float my;

    public bool bUseHorizontal = true;
    public bool bUseVertical = true;
    // Start is called before the first frame update
    void Start()
    {

        //������ �� ����ڰ� ������ ���� ������ ����
        if (bUseHorizontal)
            mx = transform.eulerAngles.y;
        if (bUseVertical)
            my = -transform.eulerAngles.x;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //������� ���콺 �Է¿� ���� ��ü�� �����¿�� ȸ����Ű�� �ʹ�.
        //1. ������� �Է¿� ����
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        mx += h * rotSpeed * Time.deltaTime;
        my += v * rotSpeed * Time.deltaTime;
        //-60~ 60 ���� ���� ���Ѱɱ�
        //x�� -> pitch, y�� -> Yaw, z�� -> Roll

        //float test = Vector3.Dot(Vector3.up, transform.up);
        //my = Mathf.Clamp(my, -60, 60);
        //transform.rotation *= Quaternion.AngleAxis(-v * rotSpeed * Time.deltaTime, transform.right);
        //transform.rotation *= Quaternion.AngleAxis(h * rotSpeed * Time.deltaTime, transform.up);

        //2. ������ �ʿ��ϴ�.
        Vector3 dir = new Vector3(-my, mx, 0);

        //3. ȸ���ϰ� �ʹ�.
        transform.eulerAngles = dir;

    }
    
    
}
