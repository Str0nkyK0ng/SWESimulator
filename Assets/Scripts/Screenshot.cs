using UnityEngine;
using System.IO;

public class Screenshot : MonoBehaviour
{
    public KeyCode screenshotKey;

    public void TakeScreenshot()
    {
        //If we don't have a screenshot directory, create one
        if(!Directory.Exists("./Screenshots/"))
            Directory.CreateDirectory("./Screenshots/");

        //Take the screenshot
        ScreenCapture.CaptureScreenshot("./Screenshots/" + System.DateTime.Now + ".png", 1);

    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.F1)){
            TakeScreenshot();
        }
    }
}