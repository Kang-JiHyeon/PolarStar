using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public string startText = "ȯ���մϴ�!!";
    public string S_1Text = "1�� Ű�� ���� ã����� ���ڸ��� �����ּ���!";
    public string S_2Text = "���� �ν� ��...";
    public string S_3Text = "���ڸ��� ã�ҽ��ϴ�! ���� ��� �ϴ��� �ٶ󺸼���!";
    public string S_4Text = "����� ��� ��...";
    public string S_5Text = "2�� Ű�� ���� ���ڸ��� ������ ������!";
    public Image GuideBar;
    public Text guideText;
    public GuideState guideState;

    public WebcamHandler web;


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
        //StartCoroutine("FadeOut");
        guideText.text = startText;
        currentTime += Time.deltaTime;
        if (currentTime > guideStartTime)
        {
            //StopAllCoroutines();
            //StartCoroutine("FadeIn");
            guideState = GuideState.state1;
            currentTime = 0;
        }
    }

    private void state1()
    {
        //currentTime += Time.deltaTime;

        //if(currentTime > 2f)
        //{
        //guideState = GuideState.state2;
        //}
        // StartCoroutine("FadeOut");
        guideText.text = S_1Text;
        //StartCoroutine("FadeIn");
    }

    private void state2()
    {
        guideText.text = S_2Text;
        //guideState = GuideState.state3;
    }

    float audioDelayTime = 3f;
    private void state3()
    {
        guideText.text = S_3Text;
        //guideState = GuideState.state4;

        currentTime += Time.deltaTime;
        if (currentTime > audioDelayTime)
        {
            guideState = GuideState.state4;
            currentTime = 0;
        }
    }

    // ����� ��� ��
    private void state4()
    {
        guideText.text = S_4Text;
        // ����� ������ ���� ����
        // --> ����� ������ �̹��� �Ž� �ٲ����
        if (AlphaChange.instance.isColorChange)
        {
            guideState = GuideState.state5;
        }

    }

    private void state5()
    {
        guideText.text = S_5Text;
        // 2�� Ű�� ������ idle ���·� ����
        if (web.isDownAlpha2)
        {
            guideState = GuideState.Idle;
        }
    }

    public IEnumerator FadeOut()
    {
        for (float i = 0; i <= 0.5f; i += Time.deltaTime / 7)
        {
            GuideBar.color = new Color(0, 0, 0, i);
            guideText.color = new Color(1, 1, 1, 2 * i);
            yield return null;
        }
    }
    public IEnumerator FadeIn()
    {
        for (float i = 0.5f; i >= 0; i -= Time.deltaTime / 7)
        {
            GuideBar.color = new Color(0, 0, 0, i);
            guideText.color = new Color(1, 1, 1, 2 * i);
            yield return null;
        }
    }
}