using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Text 위치 스크롤
public class KJH_Scroll : MonoBehaviour
{
    RectTransform tr_info;
    Text text_info;
    public List<string> infos = new List<string>();
    public float speed = 1f;
    public bool isMove = false;

    // Start is called before the first frame update
    void Start()
    {
        tr_info = GetComponent<RectTransform>();
        text_info = GetComponent<Text>();

        tr_info.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMove)
            tr_info.localPosition += Vector3.up * speed * Time.deltaTime;
    }

    public void SetInfoText(int index)
    {
        tr_info.localPosition = Vector3.zero;
        text_info.text = infos[index];
        isMove = true;
    }
}
