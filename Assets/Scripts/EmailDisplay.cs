using UnityEngine;
using TMPro;

public class EmailDisplay : MonoBehaviour
{
    public TextMeshProUGUI TMP_LogoDisplay;
    public TextMeshProUGUI TMP_EmailDisplay;
    public float timePerLine = 0.025f;
    public float holdTime = 10f;
    public GameObject[] hiddenObjects;



    public string[] DATAVERSELOGO = {
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
        displayEmail=true;
    }

    void Start(){
        timer=0;
        line=0;
        displayedLogo="";
        desiredEmail = TMP_EmailDisplay.text;
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
