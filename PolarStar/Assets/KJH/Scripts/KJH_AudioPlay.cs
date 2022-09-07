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
    Transform parent;

    private void Awake()
    {
        if (!instance)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlaySound(int index)
    {
            source = parent.GetChild(index).GetComponent<AudioSource>();

            if (!source.isPlaying)
            {
                print("audio index : " + index);

                if (index > 11)
                {
                    print("����� ����");
                    return;
                }

                source.Play();

                isStartSound = true;
            }
    }

}
