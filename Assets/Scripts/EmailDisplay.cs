using UnityEngine;
using TMPro;

public class EmailDisplay : MonoBehaviour
{
    public TextMeshProUGUI TMP_LogoDisplay;
    public TextMeshProUGUI TMP_EmailDisplay;
    public float timePerLine = 0.025f;
    private float holdTime = 9;
    public GameObject[] hiddenObjects;

    public int currentEmail=0;
    private string[] emails = {
            //The first email, after you finish round one
            "Hi Candidate,\n \nWe'd like to move forward with the next round of interviews. A hiring manager will reach out to schedule the next round.\n\nBest,\nJeremy",
            //Second email, after you finish round two
            "Hi Candidate,\n \nWe'd like to hire you. The salary is $100,000 annually.\nUse 'WASD' to move around the office and 'E' to interact with objects.\n\nWelcome to the DataVerse,\nJeremy",

            //First Workday
            "Hi Employee,\n \nFor your first task we'd like you to find a specific group of users for us. More instructions to come soon. \n \n - Jeremy",
            "Hi Employee,\n \nOutstanding work today! Happy to have you on the team.\nTomorrow we'll teach you how to use the '>' character. \n \n - Jeremy",

            //Second workday
            "Hi Employee,\n \nGood morning! Today we're going to be using the '>' character.\nBest of luck!\n \n - Jeremy",
            "Hi Employee,\n \nGreat work! See you tomorrow :) \n \n - Jeremy",

            //Third workday
            "Hi Employee,\n \nGood morning! Today we're going to be getting data for some targeted advertising. \nBest of luck!\n \n - Jeremy",
            "Hi Employee,\n \nGreat work! Tomorrow is quite an important day. Congress is rolling out some new laws and needs our help! \n \n - Jeremy",

            //Third Workday
            "Hi Employee,\n \nCongress has asked for some data, your job is to help them get it!\n \n - Jeremy",
            "Hi Employee,\n \nGood work. That data will help us detain those queer criminals ASAP.\nAs a bonus for your hard work, a $25,000 bonus will be sent to you.\n \n - Jeremy",
    };


    private string[] DATAVERSELOGO = {
    "<mspace=3>DDDDDDDDDDDDD                  AAA         TTTTTTTTTTTTTTTTTTTTTTT         AAA   VVVVVVVV           VVVVVVVVEEEEEEEEEEEEEEEEEEEEEERRRRRRRRRRRRRRRRR      SSSSSSSSSSSSSSS EEEEEEEEEEEEEEEEEEEEEE",
    "D::::::::::::DDD              A:::A        T:::::::::::::::::::::T        A:::A  V::::::V           V::::::VE::::::::::::::::::::ER::::::::::::::::R   SS:::::::::::::::SE::::::::::::::::::::E",
    "D:::::::::::::::DD           A:::::A       T:::::::::::::::::::::T       A:::::A V::::::V           V::::::VE::::::::::::::::::::ER::::::RRRRRR:::::R S:::::SSSSSS::::::SE::::::::::::::::::::E",
    "DDD:::::DDDDD:::::D         A:::::::A      T:::::TT:::::::TT:::::T      A:::::::AV::::::V           V::::::VEE::::::EEEEEEEEE::::ERR:::::R     R:::::RS:::::S     SSSSSSSEE::::::EEEEEEEEE::::E",
    "  D:::::D    D:::::D       A:::::::::A     TTTTTT  T:::::T  TTTTTT     A:::::::::AV:::::V           V:::::V   E:::::E       EEEEEE  R::::R     R:::::RS:::::S              E:::::E       EEEEEE",
    "  D:::::D     D:::::D     A:::::A:::::A            T:::::T            A:::::A:::::AV:::::V         V:::::V    E:::::E               R::::R     R:::::RS:::::S              E:::::E             ",
    "  D:::::D     D:::::D    A:::::A A:::::A           T:::::T           A:::::A A:::::AV:::::V       V:::::V     E::::::EEEEEEEEEE     R::::RRRRRR:::::R  S::::SSSS           E::::::EEEEEEEEEE   ",
    "  D:::::D     D:::::D   A:::::A   A:::::A          T:::::T          A:::::A   A:::::AV:::::V     V:::::V      E:::::::::::::::E     R:::::::::::::RR    SS::::::SSSSS      E:::::::::::::::E   ",
    "  D:::::D     D:::::D  A:::::A     A:::::A         T:::::T         A:::::A     A:::::AV:::::V   V:::::V       E:::::::::::::::E     R::::RRRRRR:::::R     SSS::::::::SS    E:::::::::::::::E   ",
    "  D:::::D     D:::::D A:::::AAAAAAAAA:::::A        T:::::T        A:::::AAAAAAAAA:::::AV:::::V V:::::V        E::::::EEEEEEEEEE     R::::R     R:::::R       SSSSSS::::S   E::::::EEEEEEEEEE   ",
    "  D:::::D     D:::::DA:::::::::::::::::::::A       T:::::T       A:::::::::::::::::::::AV:::::V:::::V         E:::::E               R::::R     R:::::R            S:::::S  E:::::E             ",
    "  D:::::D    D:::::DA:::::AAAAAAAAAAAAA:::::A      T:::::T      A:::::AAAAAAAAAAAAA:::::AV:::::::::V          E:::::E       EEEEEE  R::::R     R:::::R            S:::::S  E:::::E       EEEEEE",
    "DDD:::::DDDDD:::::DA:::::A             A:::::A   TT:::::::TT   A:::::A             A:::::AV:::::::V         EE::::::EEEEEEEE:::::ERR:::::R     R:::::RSSSSSSS     S:::::SEE::::::EEEEEEEE:::::E",
    "D:::::::::::::::DDA:::::A               A:::::A  T:::::::::T  A:::::A               A:::::AV:::::V          E::::::::::::::::::::ER::::::R     R:::::RS::::::SSSSSS:::::SE::::::::::::::::::::E",
    "D::::::::::::DDD A:::::A                 A:::::A T:::::::::T A:::::A                 A:::::AV:::V           E::::::::::::::::::::ER::::::R     R:::::RS:::::::::::::::SS E::::::::::::::::::::E",
    "DDDDDDDDDDDDD   AAAAAAA                   AAAAAAATTTTTTTTTTTAAAAAAA                   AAAAAAAVVV            EEEEEEEEEEEEEEEEEEEEEERRRRRRRR     RRRRRRR SSSSSSSSSSSSSSS   EEEEEEEEEEEEEEEEEEEEEE",
    };                                                                                                                       
                                                                                                                                                                                                
                                                                                                                                                                                                
                                                                                                                                                                                               
                                                                                                                                                                                               
                                                                                                                                                                                               
                                                                                                                                                                                               

    //Private internal things to hold all our data
    private float timer=0;
    private int line=10000000;
    private string displayedLogo="";
    private string desiredEmail = "";

    public bool displayEmail=false;
    
    // Update is called once per frame
    void Update()
    {
        //Only display when we're ready
        if(!displayEmail)
            return;

        timer+=Time.deltaTime;
        //When it's time to update the logo
        if(timer>=timePerLine){
            //When there's more of the actual logo to render
            if(line<DATAVERSELOGO.Length){
                displayedLogo+=DATAVERSELOGO[line]+'\n';
                timer=0;
                line++;
                TMP_LogoDisplay.text = displayedLogo;
                return;
            }
            //Once we're at the final line at the caption to the portrait
            if (line == DATAVERSELOGO.Length)
            {
                TMP_EmailDisplay.text = desiredEmail;
                line++;
                timer=0;
                return;
            }
        }
    }

    public float TotalTime(){
        return holdTime + timePerLine*(DATAVERSELOGO.Length+2);
    }
    public void display(){
        if(currentEmail<emails.Length)
            desiredEmail = emails[currentEmail];
        displayEmail=true;
        currentEmail++;
    }

    void Start(){
        timer=0;
        line=0;
        displayedLogo="";
        desiredEmail = emails[currentEmail];
        TMP_EmailDisplay.text = "";
        TMP_LogoDisplay.text = "";
    }

    public void clearDisplay()
    {
        //Reset the displays
        displayedLogo="";
        TMP_EmailDisplay.text = "";
        TMP_LogoDisplay.text = "";
        displayEmail=false;
        line=0;
    }

}
