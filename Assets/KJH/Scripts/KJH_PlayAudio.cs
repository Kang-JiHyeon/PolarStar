using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 통신 성공하면 오디오를 출력하고 싶다.
// 통신에서 받은 인덱스에 해당하는 오디오 클립을 지정하고 재생한다.

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
        // 오디오가 실행 중이였다가 끝나면
        if (isStartSound && !source.isPlaying)
        {
            StarGuide.Instance.go_text.SetActive(false);
            // 해당 별자리의 alpha값 변경
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
