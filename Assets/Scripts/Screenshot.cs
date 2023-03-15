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
        ScreenCapture.CaptureScreenshot("./Screenshots/" + (int)Random.Range(0,1000) + ".png");

    }

    void Update(){
        if(Input.GetKeyDown(screenshotKey)){
            TakeScreenshot();
        }
    }
}