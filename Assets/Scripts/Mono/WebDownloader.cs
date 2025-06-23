using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class WebDownloader : MonoBehaviour
{
    public static WebDownloader inst;
    private void Awake()
    {
        inst = this;
    }

    public void Download(string url)
    {
        StartCoroutine(AlwaysDownloadAndCache(url));
    }

    IEnumerator AlwaysDownloadAndCache(string url)
    {
        string localPath = Path.Combine(Application.persistentDataPath, "data");

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("����ʧ�ܣ�" + request.error);
            }
            else
            {
                string content = request.downloadHandler.text;
                Debug.Log("���سɹ����������£�\n" + content);
                 
                // ����д�뱾���ļ�
                File.WriteAllText(localPath, content);
                Debug.Log("�Ѹ��Ǿ��ļ������浽��" + localPath);
            }
        }
    }
}
