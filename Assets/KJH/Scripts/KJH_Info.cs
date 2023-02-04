using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KJH_Info : MonoBehaviour
{
    RectTransform tr_info;
    Text text_info;
    public float speed = 1f;
    public List<string> infos = new List<string>();

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
        tr_info.localPosition += Vector3.up * speed * Time.deltaTime;
    }

    public void Init()
    {
        tr_info.localPosition = Vector3.zero;
        text_info.text = infos[KJH_DrawConstellation.instance.coIndex];
    }
}
