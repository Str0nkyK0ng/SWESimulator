using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LoadingManager : MonoBehaviour
{

   public EmailDisplay emailDisplay;
   public static LoadingManager instance;
   string loadingVisual ="";
   bool loadingScreenComplete = false;
   int loadingAmount = 0;
   int loadingLength = 7;
   public TextMeshProUGUI loadingLabel;



//    Aight I hate doing this but this will work
    [HideInInspector]
    public const int ScanLineSize = 6528;

    public void WaitingForEmailLoadScene(int index){
        StartCoroutine(WaitingLoadScene(index));
    }

    public void LoadScene(int index){
        SceneManager.LoadScene(index);
    }
    
    public void emailTransition(int index){
        emailDisplay.clearDisplay();
        StartCoroutine(EmailOnlyLoadScene(index));
    }

    public float emailGraphicOnly(){
        emailDisplay.clearDisplay();
        StartCoroutine(EmailGraphicOnly());
        return emailDisplay.TotalTime();
    }

    void updateLoadingVisual(){
        loadingVisual="WAITING FOR FOLLOW-UP EMAIL\n";
        for(int x=0;x<loadingAmount;x++){
            loadingVisual+='■';
        }
        for(int x=loadingAmount;x<loadingLength;x++){
            loadingVisual+='□';
        }
        loadingLabel.text=loadingVisual;
        loadingAmount++;
         
    }
    void hideLoadingVisual(){
        loadingLabel.text="";
    }


    IEnumerator EmailOnlyLoadScene(int index){
        //Show the loading email graphic & wait
        emailDisplay.display();
        yield return new WaitForSeconds(emailDisplay.TotalTime());
        emailDisplay.clearDisplay();
        AsyncOperation asyncLoad  = SceneManager.LoadSceneAsync(index);
    }

    IEnumerator EmailGraphicOnly(){
        //Show the loading email graphic & wait
        emailDisplay.display();
        yield return new WaitForSeconds(emailDisplay.TotalTime());
        emailDisplay.clearDisplay();
    }

    IEnumerator WaitingLoadScene(int index)
    {
        //Show the loading email graphic
        if(!loadingScreenComplete){
            while (loadingAmount!=loadingLength+1)
            {
                updateLoadingVisual();
                yield return new WaitForSeconds(loadingAmount*0.25f);
            }
            loadingScreenComplete=true;
            hideLoadingVisual();
        }

        //Show the loading email graphic & wait
        emailDisplay.display();
        yield return new WaitForSeconds(emailDisplay.TotalTime());
        AsyncOperation asyncLoad  = SceneManager.LoadSceneAsync(index);

        //Reset the visuals of the loading scene
        loadingVisual="";
        loadingAmount=0;
        loadingLabel.text=loadingVisual;
        emailDisplay.clearDisplay();
        loadingScreenComplete=false;

        //Wait till we're loading in to update our camera
        while(!asyncLoad.isDone){
            yield return null;
        }
        
        //Make sure we connect to the camera in the new scene
        GetComponent<Canvas>().worldCamera=FindObjectOfType<Camera>();
    }
    
    void Awake() 
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    void Update(){
    }
}
