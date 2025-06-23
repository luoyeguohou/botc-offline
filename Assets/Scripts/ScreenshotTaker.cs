using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotTaker : MonoBehaviour
{
    public int superSize = 1; // 倍率（1 = 当前分辨率，2 = 两倍分辨率）

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            string path = Application.dataPath + "/Screenshot_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            ScreenCapture.CaptureScreenshot(path, superSize);
            Debug.Log("Screenshot saved to: " + path);
        }
    }
}
