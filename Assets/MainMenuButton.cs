using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenuButton : MonoBehaviour
{
    public PortraitDisplay portraitDisplay;
    public CanvasGroup menuElements;
    public void StartGame(){
        menuElements.alpha=0;
        StartCoroutine(holdDisplay());
    }
    public void Portfolio(){
        Application.OpenURL("https://aidanmstrong.com");
    }
    public void Quit(){
        Application.Quit();
    }

    public void AddText(TextMeshProUGUI label){
        label.text=">"+label.text+"<";
    }
    public void RemoveText(TextMeshProUGUI label){
        label.text=label.text.Substring(1,label.text.Length-2);
    }


    IEnumerator holdDisplay()
    {
        portraitDisplay.displayPortrait(PORTRAIT.Player,"This is you. You'll be interviewing at Dataverse Analytics.");
        yield return new WaitForSeconds(5);


        portraitDisplay.clearDisplay();
        portraitDisplay.displayPortrait(PORTRAIT.Suit,"This is Jeremy. He'll be conducting the interview today.");
        yield return new WaitForSeconds(5);


        portraitDisplay.changeCaption("\"There will be two rounds of interviews. One will assess your personality, and the other will assess your technical skills.\"");
        yield return new WaitForSeconds(5);

        portraitDisplay.changeCaption("\"Lets begin.\"");
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("RoundOne");

    }

}
