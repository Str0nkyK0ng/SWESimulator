using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine.SceneManagement;
public class PortraitDisplay : MonoBehaviour
{

    public TextMeshProUGUI TMP_portraitDisplay;
    public TextMeshProUGUI TMP_portraitCaption;
    public float timePerLine = 0.025f;
    public float holdTime = 4f;


    //Private internal things to hold all our data
    private float timer=0;
    private int line=100;
    private string displayed="";
    private string portraitCaption = "";
    private string[] suitPortrait = 
        {"................................................................"
        ,"................................................................"
        ,"................................................................"
        ,"................................................................"
        ,"...........................:-===-:.............................."
        ,"..........................*%%%%%%%#-............................"
        ,".........................+#=---=*#%@:..........................."
        ,".........................*---::-==*+............................"
        ,".........................:-:--:===+-............................"
        ,"..........................::::-=-=:............................."
        ,"...........................:---===:............................."
        ,"........................:-+.:--==:*+-:.........................."
        ,"..................:=+*#%%%%::=+=:-%%%%%*+=-....................."
        ,".................:#%%%%%%%%=.=+-:#%%%%%%%%%-...................."
        ,"................:#%%%%%%%%%+.++=+%%%%%%%%%%%-..................."
        ,"...............:#%%%%%%%%%%*:++=#%%%%%%%%%%%%-.................."
        ,"...............*%%%%%%%%%%%%=++*%%%%%%%%%%%%%%-................."
        ,".............:#%%%@@+#%%%%%%%++%%%%%%%@@%%%%%%#:................"
        ,"............:#%%%%%:.=%%%%#%%#*%%@@%%%@%:=%%%%%%:..............."
        ,"............%%%%%%+-:-%##****##@@%%%@@@-..=%%%%%*..............."
        ,"...........:#%%%%%%+:-----==+==+*#%@@@%.:=+%%%%%%+.............."
        ,".............:-+*#%+==+=---=-------+**#%%%%%%%%%%=.............."
        ,"...................:=@%%%%%%+==+**++=++%%%%#+=-:................"
        ,"....................*%%%%%%%%%%%%@@@@@@*-:......................"
        ,"...................:%%%%%%%%%#%%%%%%%%%+........................"
        ,"...................=%%%%%%%%#*%%%%%%%%%%........................"
        ,"...................#%%%%%%%@%%%%%%%%%%%#........................"};

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer>=timePerLine && line<suitPortrait.Length){
            displayed+=suitPortrait[line]+'\n';
            timer=0;
            line++;
            TMP_portraitDisplay.text = displayed;
        }
        //Once we're at the final line at the caption to the portrait
        if (line == suitPortrait.Length)
        {
            TMP_portraitCaption.text = portraitCaption;
            line++;
        }

    }



    public void displaySuitPortrait(string caption)
    {
        timer=0;
        line=0;
        displayed="";
        portraitCaption = caption;

        //Reset the displays
        TMP_portraitCaption.text = "";
        TMP_portraitDisplay.text = "";
    }
    public void clearDisplay()
    {
        //Reset the displays
        TMP_portraitCaption.text = "";
        TMP_portraitDisplay.text = "";

    }

}
