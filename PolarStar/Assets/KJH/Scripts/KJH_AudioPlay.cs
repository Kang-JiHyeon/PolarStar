using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��� �����ϸ� ������� ����ϰ� �ʹ�.
public class KJH_AudioPlay : MonoBehaviour
{
    public AudioSource source;
    public bool isStartSound = false;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (KJH_DrawConstellation.instance.isSuccess)
        {
            if (!source.isPlaying)
            {
                print("���ڸ� �ó����� �÷���");
                source.Play();
                isStartSound = true;                
            }
        }
    }
}
