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
            print("���˺� ����");

            GameObject star = Instantiate(starFactory);
            transform.forward = player.forward;
            star.transform.forward = transform.forward;

            //// ���˺� ��ġ ����
            //// ȭ�� ��ǥ ��������
            //// ������Ʈ�� ���� ������ǥ�� ��ũ�� ��ǥ�� ��ȯ --> ȭ�� �� ��ǥ
            //Vector3 spacePos = Camera.main.WorldToScreenPoint(star.transform.position);

            //// ȭ�� �� ���� ��ǥ
            //float posX = Random.Range(0, Screen.width);
            //float posY = Random.Range(Screen.height / 2, Screen.height);

            //// ��ũ�� �� ���� ��ǥ�� �� ��ġ ����
            //star.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(posX, posY, spacePos.z));


            // 2. atan ����ؼ� �þ߰� �ȿ� ���˺� �����ǵ���!!

            //Vector3 dir = transform.position - player.transform.position;
            //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            //float angle = Random.Range(0f, 60f);
            //angle = 40f;
            //print(angle);
            
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
