using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject Earth;
    //�ʿ�Ӽ� : �̵��ӵ�
    public float speed = 5;

    //�ʿ�Ӽ� Character Controller
    CharacterController cc;

    //�ʿ�Ӽ� : �߷�
    public float gravityPower = 10;

    public Vector3 gravity = Vector3.zero;

    //�ʿ�Ӽ� : �����ӵ�
    public Vector3 gravityDir;

    //�ʿ�Ӽ� : �����Ŀ�
    public float jumpPower = 5;

    int jumpCount = 0;
    public int maxJumpCount = 2;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        gravityDir = (Earth.transform.position - transform.position).normalized;
        gravity += gravityPower * gravityDir * Time.deltaTime;
        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();
        dir = Camera.main.transform.TransformDirection(dir);
        transform.up = -gravityDir;
        if (cc.collisionFlags == CollisionFlags.Below)
        {
            gravityDir = Vector3.zero;
            jumpCount = 0;
        }
        else
        {
            //yVelocity +=  gravity * Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumpCount)
        {
            //yVelocity = jumpPower;
            jumpCount++;
        }
        cc.Move(dir * speed * Time.deltaTime + gravity);
    }
}
