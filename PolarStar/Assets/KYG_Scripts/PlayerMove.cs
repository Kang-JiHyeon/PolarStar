using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject Earth;
    //�ʿ�Ӽ� : �̵��ӵ�
    public float speed = 5;

    //�ʿ�Ӽ� Character Controller
    Rigidbody rb;

    //�ʿ�Ӽ� : �߷�
    public float gravityPower = 10;

    public Vector3 gravity = Vector3.zero;

    //�ʿ�Ӽ� : �����ӵ�
    public Vector3 gravityDir;

    public Vector3 yVelocity = Vector3.zero;

    //�ʿ�Ӽ� : �����Ŀ�
    public float jumpPower = 5;

    int jumpCount = 0;
    public int maxJumpCount = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    public float h;
    public float v;
    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        gravityDir = (Earth.transform.position - transform.position).normalized;
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hitInfo;
        int layer = 1 << gameObject.layer;
        if (Physics.Raycast(ray, out hitInfo, 1.1f, ~layer))
        {
            yVelocity = Vector3.zero;
            jumpCount = 0;
        }
        else
        {
            //yVelocity +=  gravity * Time.deltaTime;
            gravity = gravityPower * gravityDir;
            yVelocity += gravity * Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumpCount)
        {
            yVelocity = jumpPower * transform.up;
            jumpCount++;
        }

        // �̵��� ���ⱸ�ϱ�
        //Vector3 dir = new Vector3(h, 0, v);
        //dir.Normalize();
        Vector3 dir = transform.forward * v + transform.right * h;// transform.TransformDirection(dir);
        dir = Camera.main.transform.TransformDirection(dir);
        dir.Normalize();
        transform.up = -gravityDir;

        // �� �������� �̵�
        dir += yVelocity;
        // up ���� �����ֱ�
        rb.velocity = dir * speed;

        // �߷�����
        //rb.velocity = dir;

    }

    private void OnDrawGizmos()
    {
        gravityDir = (Earth.transform.position - transform.position).normalized;

        Debug.DrawLine(transform.position, transform.position + gravityDir * 5, Color.red);

    }
}
