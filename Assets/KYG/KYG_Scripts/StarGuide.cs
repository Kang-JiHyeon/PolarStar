using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarGuide : MonoBehaviour
{
    public enum GuideState
    {
        Idle,
        guideStart,
        state1,
        state2,
        state3,
        state4,
        state5
    }
    //public string startText = "ȯ���մϴ�!!";
    //public string S_1Text = "1�� Ű�� ���� ã����� ���ڸ��� �����ּ���!";
    //public string S_2Text = "���� �ν� ��...";
    //public string S_3Text = "���ڸ��� ã�ҽ��ϴ�! ���� ��� �ϴ��� �ٶ󺸼���!";
    //public string S_4Text = "����� ��� ��...";
    //public string S_5Text = "2�� Ű�� ���� ���ڸ��� ������ ������!";
    public Image GuideBar;
    //public Text guideText;
    public Image startImage;
    public Image S_1Image;
    public Image S_2Image;
    public Image S_3Image;
    public Image S_4Image;
    public Image S_5Image;
    public GuideState guideState;

    public WebcamHandler web;
    public RawImage rawImage;

    // �̱������� ���
    public static StarGuide Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        guideState = GuideState.guideStart;
        startImage.enabled = false;
        S_1Image.enabled = false;
        S_2Image.enabled = false;
        S_3Image.enabled = false;
        S_4Image.enabled = false;
        S_5Image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine();
    }

    private void StateMachine()
    {
        switch (guideState)
        {
            case GuideState.Idle:
                Idle();
                break;
            case GuideState.guideStart:
                guideStart();
                break;
            case GuideState.state1:
                state1();
                break;
            case GuideState.state2:
                state2();
                break;
            case GuideState.state3:
                state3();
                break;
            case GuideState.state4:
                state4();
                break;
            case GuideState.state5:
                state5();
                break;
        }
    }

    private void Idle()
    {
        
    }

    float currentTime = 0;
    float guideStartTime = 5f;
    private void guideStart()
    {
        startImage.enabled = true;
        //StartCoroutine("FadeOut");
        //guideText.text = startText;
        currentTime += Time.deltaTime;
        if (currentTime > guideStartTime)
        {
            //StopAllCoroutines();
            //StartCoroutine("FadeIn");
            startImage.enabled = false;
            guideState = GuideState.state1;
            currentTime = 0;
        }
    }

    // 1���� ������
    private void state1()
    {
        //currentTime += Time.deltaTime;
        S_1Image.enabled = true;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // ���
            KJH_DrawConstellation.instance.Http();
        }
    }

    // �����ν� ��
    private void state2()
    {
        S_1Image.enabled = false;
        S_2Image.enabled = true;
        //guideText.text = S_2Text;
        //guideState = GuideState.state3;
    }

    // ���ڸ��� ��
    float audioDelayTime = 3f;
    private void state3()
    {
        S_2Image.enabled = false;
        S_3Image.enabled = true;
        //guideText.text = S_3Text;
        //guideState = GuideState.state4;

        currentTime += Time.deltaTime;
        if (currentTime > audioDelayTime)
        {
            S_3Image.enabled = false;
            guideState = GuideState.state4;
            KJH_AudioPlay.instance.PlaySound(KJH_DrawConstellation.instance.audioIndex);
            currentTime = 0;
        }
    }

    // ����� ��� ��
    private void state4()
    {
        S_4Image.enabled = true;

        //guideText.text = S_4Text;
        // ����� ������ ���� ����
        // --> ����� ������ �̹��� �Ž� �ٲ����
        //if (AlphaChange.instance.isColorChange)
        //{
        //    //S_4Image.enabled = false;
        //    guideState = GuideState.state5;
        //}

    }
    // 2��Ű�� ������ ������ ���� �� �־�
    private void state5()
    {
        S_5Image.enabled = true;
        //guideText.text = S_5Text;
        // 2�� Ű�� ������ idle ���·� ����
        if (web.isDownAlpha2)
        {
            S_5Image.enabled = false;

            //currentTime += Time.deltaTime;

            //if (currentTime > 4f)
            //{
            //    web.isDownAlpha2 = false;
            //    rawImage.enabled = false;
            //    guideState = GuideState.state1;

            //    currentTime = 0f;

            //}
        }
    }
}