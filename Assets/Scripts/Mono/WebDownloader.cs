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
                Debug.LogError("下载失败：" + request.error);
            }
            else
            {
                string content = request.downloadHandler.text;
                Debug.Log("下载成功，内容如下：\n" + content);
                 
                // 覆盖写入本地文件
                File.WriteAllText(localPath, content);
                Debug.Log("已覆盖旧文件，保存到：" + localPath);
            }
        }
    }
}
