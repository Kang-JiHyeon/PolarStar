using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KJH_AlphaChange : MonoBehaviour
{
    public static KJH_AlphaChange instance;
    Color curColor = new Color(1, 1, 1, 0);
    Color targetColor = new Color(1, 1, 1, 0.3f);
    public bool isColorChange = false;
    Quaternion originRotation;

    KJH_PlayAudio ap;
    

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        originRotation = transform.rotation;
        transform.forward = Vector3.zero - transform.position;


        // alpha ����
        transform.GetComponent<SpriteRenderer>().color = curColor;
        ap = GetComponent<KJH_PlayAudio>();
    }

    float curTime = 0f;
    // Update is called once per frame
    void Update()
    {
        if (ap.isStartSound)
        {
            curTime += Time.deltaTime;

            if (curTime > ap.source.clip.length)
            {
                ap.source.Stop();
                StarGuide.Instance.S_4Image.enabled = false;
                isColorChange = true;
                ap.isStartSound = false;
            }
        }

        if (isColorChange)
        {
            curColor = Color.Lerp(curColor, targetColor, Time.deltaTime * 0.4f);

            if (curColor.a > 0.25f)
            {
                curColor = targetColor;
                isColorChange = false;
                StarGuide.Instance.guideState = StarGuide.GuideState.state5;
            }

            GetComponent<SpriteRenderer>().color = curColor;
        }

        //if (StarGuide.Instance.guideState == StarGuide.GuideState.state4)
        //{
        //    ap = transform.GetChild(KJH_DrawConstellation.instance.audioIndex).GetComponent<KJH_AudioPlay>();
        //    imageColor = transform.GetChild(KJH_DrawConstellation.instance.audioIndex).GetComponent<SpriteRenderer>().color;
        //    PlusAlpha();
        //}
    }


    // �ڽ� ������Ʈ�� Color�� �����ϰ� �ʹ�.
    // index�� ���޹޾ƾ� �Ѵ�.
    // �ʿ�Ӽ� : ���޹��� �ε����� �ش��ϴ� image, ��Ź��� �� ���� index, 


    //void PlusAlpha()
    //{
    //    //ap = transform.GetChild(KJH_DrawConstellation.instance.audioIndex).GetComponent<KJH_AudioPlay>();
        
        

    //    if (ap.isStartSound)
    //    {
    //        curTime += Time.deltaTime;

    //        if (curTime > ap.source.clip.length)
    //        {
    //            ap.source.Stop();
    //            StarGuide.Instance.S_4Image.enabled = false;
    //            isColorChange = true;
    //        }
    //    }

    //    if (isColorChange)
    //    {
    //        color = Color.Lerp(color, targetColor, Time.deltaTime * 0.4f);

    //        if (color.a > 0.25f)
    //        {
    //            color = targetColor;
    //            StarGuide.Instance.guideState = StarGuide.GuideState.state5;
    //            isColorChange = false;
    //        }

    //        GetComponent<SpriteRenderer>().color = color;
    //    }
    //}
}
