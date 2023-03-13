using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeaderManager : MonoBehaviour
{

    private static TextMeshProUGUI header;
    private void Start()
    {
        header = GetComponent<TextMeshProUGUI>();
    }
    public static void hideHeader(){
        header.text = "";
    }
    
    public static void updateWorkdayHeader(int dayNum){
        string roundText="";
        switch(dayNum){
            case 0:
                roundText="ONE";
                break;
            case 1:
                roundText="TWO";
                break;
            case 2:
                roundText="THREE";
                break;
        }
        string headerString = "<mspace=23>#######################\n#######DAY "+roundText+"#######\n#######################\n";
        header.text = headerString;

    }

    public static void updateInterviewHeader(int roundNumber, int index, int total)
    {
        string roundText = roundNumber == 1 ? "ONE" : "TWO";
        string headerString = "<mspace=23>#######################\n#######ROUND "+roundText+"#######\n#######################\n";

        
        for (int x = 0; x < total; x++)
        {
            if (x <= index)
            {
                headerString += "■";
            }
            else
            {
                headerString += "□";
            }
        }


        if(roundNumber==3)
        {
            headerString = "<mspace=23>#######################\n#######FIRST DAY#######\n#######################\n";
        }
        
        headerString += "</mspace>";
        header.text = headerString;

    }
}
