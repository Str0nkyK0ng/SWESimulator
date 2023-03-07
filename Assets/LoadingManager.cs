using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LoadingManager : MonoBehaviour
{
   public static LoadingManager instance;
   string loadingVisual ="";
   int loadingAmount = 0;
   int loadingLength = 7;
   public TextMeshProUGUI loadingLabel;

    public void LoadScene(int index){
        StartCoroutine(WaitingLoadScene(index));
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
    IEnumerator WaitingLoadScene(int index)
    {

        while (loadingAmount!=loadingLength)
        {
            updateLoadingVisual();
            yield return new WaitForSeconds(loadingAmount*0.25f);
        }
        
        AsyncOperation asyncLoad  = SceneManager.LoadSceneAsync(index);
        loadingVisual="";
        loadingAmount=0;
        loadingLabel.text=loadingVisual;

        //Wait till we're loading in to update our camera
        while(!asyncLoad.isDone){
            yield return null;
        }
        GetComponent<Canvas>().worldCamera=FindObjectOfType<Camera>();
    }
    
    void Awake() 
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
}
