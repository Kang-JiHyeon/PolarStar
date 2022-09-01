using System;
using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.UI;

public class WebcamHandler : MonoBehaviour
{

    // ī�޶� ȭ���� ǥ���� ���� ������Ʈ
    // ����Ƽ Inspector���� �����Ǿ�� ��
    // ����! Renderer ���۳�Ʈ�� �����ؾ� ��
    public GameObject objectTarget = null;

    // ī�޶� �Է��� ���� WebCamTexture
    protected WebCamTexture textureWebCam = null;

    public RawImage resultTexture;

    public RawImage rawImage;

    Renderer render;
    void Start()
    {
        rawImage.enabled = false;
        
        //StartCoroutine(GetTexture());
        // ���� ��� ������ ī�޶��� ����Ʈ
        WebCamDevice[] devices = WebCamTexture.devices;

        // ����� ī�޶� ����
        // ���� ó�� �˻��Ǵ� �ĸ� ī�޶� ���
        int selectedCameraIndex = -1;
        for (int i = 0; i < devices.Length; i++)
        {
            // ��� ������ ī�޶� �α�
            Debug.Log("Available Webcam: " + devices[i].name + ((devices[i].isFrontFacing) ? "(Front)" : "(Back)"));

            // �ĸ� ī�޶����� üũ
            if (devices[i].isFrontFacing == true)
            {
                // �ش� ī�޶� ����
                selectedCameraIndex = i;
                break;
            }
        }

        // WebCamTexture ����
        if (selectedCameraIndex >= 0)
        {
            // ���õ� ī�޶� ���� ���ο� WebCamTexture�� ����
            textureWebCam = new WebCamTexture(devices[selectedCameraIndex].name);
            textureWebCam.Play();

            // ���ϴ� FPS�� ����
            if (textureWebCam != null)
            {
                textureWebCam.requestedFPS = 60;
            }
        }

        // objectTarget���� ī�޶� ǥ�õǵ��� ����
        if (textureWebCam != null)
        {
            // objectTarget�� ���Ե� Renderer
            render = objectTarget.GetComponent<Renderer>();

            // �ش� Renderer�� mainTexture�� WebCamTexture�� ����
            render.material.mainTexture = textureWebCam;

            //GetTextureInfo();
            //Texture2D myTex = (Texture2D)render.material.mainTexture;
            //byte[] texData = myTex.GetRawTextureData();
            //string texString = Encoding.UTF8.GetString(texData);

            //// �����͸� �޾��� ��
            //myTex.LoadRawTextureData(texData);
            //myTex.Apply();
        }
    }

    void OnDestroy()
    {
        // WebCamTexture ���ҽ� ��ȯ
        if (textureWebCam != null)
        {
            textureWebCam.Stop();
            WebCamTexture.Destroy(textureWebCam);
            textureWebCam = null;
        }
    }

    // Play ��ư�� ������ ��
    // ����! ����Ƽ Inspector���� ��ư ���� �ʿ�
    public void OnPlayButtonClick()
    {
        // ī�޶� ���� ����
        if (textureWebCam != null)
        {
            textureWebCam.Play();
        }
    }

    // Stop ��ư�� ������ ��
    // ����! ����Ƽ Inspector���� ��ư ���� �ʿ�
    public void OnStopButtonClick()
    {
        // ī�޶� ���� ����
        if (textureWebCam != null)
        {
            textureWebCam.Stop();
        }
    }

    public byte [] GetTextureInfo()
    {
        if (textureWebCam != null)
        {
            Texture mainTexture = render.material.mainTexture;
            Texture2D texture2D = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);

            RenderTexture currentRT = RenderTexture.active;

            RenderTexture renderTexture = new RenderTexture(mainTexture.width, mainTexture.height, 32);
            Graphics.Blit(mainTexture, renderTexture);

            RenderTexture.active = renderTexture;
            texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            texture2D.Apply();

            RenderTexture.active = currentRT;

            //byte[] texData = texture2D.GetRawTextureData();
            //string texString = Encoding.UTF8.GetString(texData);

            //File.WriteAllBytes(Application.dataPath + "/test.png", texture2D.EncodeToPNG());

            return texture2D.EncodeToPNG();
        }
        return null;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            HTTPRequester hTTPRequester = new HTTPRequester();
            hTTPRequester.url = "https://a1f2-110-70-51-37.jp.ngrok.io/get_picture";
            //hTTPRequester.url = URL.instance.sendImage;
            hTTPRequester.requestType = RequestType.POST;
            hTTPRequester.postData = "aa";// GetTextureInfo();
            hTTPRequester.postArray = GetTextureInfo();
            hTTPRequester.onComplete = CallBack; 


            HTTPManager.instance.SendRequest(hTTPRequester);

            StartCoroutine(GetTexture());
        }
    }

    void CallBack(DownloadHandler downloadHandler)
    {
        /*
        //Constellation co = JsonUtility.FromJson<Constellation>(downloadHandler.text);
        //string data = downloadHandler.text.Substring("bytearray".Length);
        byte[] stringData = Convert.FromBase64String(downloadHandler.text);
        //byte[] data = Encoding.UTF8.GetBytes(downloadHandler.text);
        print($"byte Length: {stringData}"); 
        Texture2D tex = new Texture2D(1, 1, TextureFormat.RGBA32, false);
        //tex.LoadImage(stringData);
        tex.LoadRawTextureData(stringData);
        tex.Apply();
        resultTexture.material.mainTexture = (Texture)tex;

        Rect rect = new Rect(0, 0, tex.width, tex.height);
        //img.sprite = Sprite.Create(tex, rect, new Vector2(0.5f, 0.5f));
        byte[] d = tex.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/test.png", d);
        */
    }

    IEnumerator GetTexture()
    {
        
        yield return new WaitForSeconds(7.0f);

        rawImage.enabled = true;

        Uri address = new Uri("https://a1f2-110-70-51-37.jp.ngrok.io/static/image/result.jpg");
        //Uri address = new Uri(URL.instance.receiveImage);
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(address);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            resultTexture.texture = myTexture;
        }
    }
}
