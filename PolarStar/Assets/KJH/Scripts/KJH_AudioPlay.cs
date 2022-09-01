using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ��� �����ϸ� ������� ����ϰ� �ʹ�.
// ��ſ��� ���� �ε����� �ڽ� ������Ʈ�� ������ ����� �ҽ��� �÷����Ѵ�.

public class KJH_AudioPlay : MonoBehaviour
{
    public static KJH_AudioPlay instance;
    public AudioSource source;
    public bool isStartSound = false;

    private void Awake()
    {
        if(!instance)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlaySound(int index)
    {
        //if (KJH_DrawConstellation.instance.isSuccess)
        //{
            //if (!source.isPlaying)
            //{
                print(index);

                if (index > 11)
                {
                    print("����� ����");
                    return;
                }

                source = transform.GetChild(index).GetComponent<AudioSource>();
                source.Play();

                isStartSound = true;
            //}
        //}
    }

}
