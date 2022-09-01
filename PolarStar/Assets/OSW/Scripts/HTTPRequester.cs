using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class Constellation
{
    public string name;
    public int index;
}

public enum RequestType
{
    POST,
    GET,
    PUT,
    DELETE
}

public class HTTPRequester 
{
    // url
    public string url;
    // ��û Ÿ�� (GET, POST, PUT, DELETE)
    public RequestType requestType;

    // Post Data
    public string postData; // (body)

    // ������ ���� �� ȣ������ �Լ�(Action)
    // Action : �Լ��� ���� �� �ִ� �ڷ���
    // ��ȯ �ڷ��� void, �Ű����� ���� �Լ��� ���� �� �ִ�
    public Action<DownloadHandler> onComplete;

}
