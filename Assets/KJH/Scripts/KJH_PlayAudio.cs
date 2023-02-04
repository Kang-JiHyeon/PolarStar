using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ��� �����ϸ� ������� ����ϰ� �ʹ�.
// ��ſ��� ���� �ε����� �ش��ϴ� ����� Ŭ���� �����ϰ� ����Ѵ�.

public class KJH_PlayAudio : MonoBehaviour
{
    public AudioSource source;
    public List<AudioClip> clip = new List<AudioClip>();
    public bool isStartSound = false;

    KJH_ChangeAlpha alpha;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        alpha = GetComponent<KJH_ChangeAlpha>();
    }

    void Update()
    {
        // ������� ���� ���̿��ٰ� ������
        if (isStartSound && !source.isPlaying)
        {
            StarGuide.Instance.go_text.SetActive(false);
            // �ش� ���ڸ��� alpha�� ����
            StopCoroutine(alpha.IeChangeAlpha());
            StartCoroutine(alpha.IeChangeAlpha());
            isStartSound = false;
        }
    }
    public void PlaySound(int index)
    {
        if (!source.isPlaying)
        {
            source.clip = clip[index];
            source.Play();
            isStartSound = true;
        }
    }
}
