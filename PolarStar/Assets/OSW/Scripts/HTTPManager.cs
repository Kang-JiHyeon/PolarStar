using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class HTTPManager : MonoBehaviour
{
    public static HTTPManager instance;

    private void Awake()
    {
        // ���࿡ instacne�� null�̶��
        if(instance == null)
        {
            // instance�� ���� �ְڴ�.
            instance = this;
            // ���� ��ȯ�� �ǵ� ���� �ı����� �ʰ� �ϰڴ�.
            DontDestroyOnLoad(gameObject);
        }
        // �׷��� ������
        else
        {
            // ���� �ı��ϰڴ�.
            Destroy(gameObject);
        }
        
    }
    
    // �������� ��û
    // url(posts/1), GET
    public void SendRequest(HTTPRequester requester)
    {
        StartCoroutine(Send(requester));
    }

    IEnumerator Send(HTTPRequester requester)
    {
        UnityWebRequest webRequest = null;
        // requestType�� ���� ȣ������� �Ѵ�.
        switch (requester.requestType)
        {
            case RequestType.POST:
                webRequest = UnityWebRequest.Post(requester.url, requester.postData);
                byte[] data = Encoding.UTF8.GetBytes(requester.postData);
                webRequest.uploadHandler = new UploadHandlerRaw(data);
                webRequest.SetRequestHeader("Content-Type", "application/json");

                break;
            case RequestType.GET:
                webRequest = UnityWebRequest.Get(requester.url);
                break;
            case RequestType.PUT:
                webRequest = UnityWebRequest.Put(requester.url, requester.postData);
                webRequest.SetRequestHeader("Content-Type", "application/json");
                break;
            case RequestType.DELETE:
                webRequest = UnityWebRequest.Delete(requester.url);
                break;
        }
        // ������ ��û�� ������ ������ �ö����� ��ٸ���.
        yield return webRequest.SendWebRequest();

        // ���࿡ ������ �����ߴٸ�
        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            // �Ϸ�Ǿ��ٰ� requester, onComplete�� ����
            print(webRequest.downloadHandler.text);

            requester.onComplete(webRequest.downloadHandler);
        }
        // �׷����ʴٸ�
        else
        {
            // ������� ����... ��
            print("��� ����" + webRequest.result + "\n" + webRequest.error);
        }
        yield return null;
    }
}
