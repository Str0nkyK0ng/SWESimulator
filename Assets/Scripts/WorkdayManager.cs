using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Workday{
    private int currentTask=0;
    public Question[] tasks;
    public Workday(Question[] t){
        tasks=t;
        currentTask=0;
    }

    public int numTasks(){
        return tasks.Length;
    }
    public Question[] questions(){
        return tasks;
    }
    public bool isWorkdayComplete(){
        return  currentTask==tasks.Length;
    }
    public Question getQuestion(){
        return tasks[currentTask];
    }
    public void completeQuestion(){
        currentTask++;
    }
}

public class WorkdayManager : MonoBehaviour
{
    
    public Question activeQuestion;
    public Workday currentWorkday;
    public GameObject inputArea;

    public Workday[] workdays;
    private int dayNumber = 0;

    public TextMeshProUGUI questionStatement, questionDetails;


    void DisplayQuestion(){
        questionStatement.text="\""+activeQuestion.questionStatement+"\"";
        questionDetails.text=activeQuestion.questionDetails;
        inputArea.SetActive(true);
    }
    void HideDisplay(){
        questionStatement.text="";
        inputArea.SetActive(false);
        questionDetails.text="";
    }

    public void AttemptAnswer(string ans){
        //Remove any spaces or ,s
        ans = ans.Replace(" ", "");
        ans = ans.Replace(",","");
        ans = ans.Replace(".","");
        ans = ans.ToLower();
        Debug.Log("Simple Guess:"+ans);
        if(activeQuestion.response==ans)
            CorrectAnswer();
        else
            WrongAnswer();
    }

    void CorrectAnswer(){
        //Complete the question we're on
        currentWorkday.completeQuestion();
        //If we're not done with this workday, get the next question
        if(!currentWorkday.isWorkdayComplete()){
            activeQuestion = currentWorkday.getQuestion();
            DisplayQuestion();
            Debug.Log("Correct!");
        }
        //once the user has done all the questions for the workday, go on to the next day questions,
        else
        {
            NextDay();
        }
        // 123456789101112131415
    }
    public void NextDay(){



        HeaderManager.hideHeader();
        HideDisplay();

        if(StateManager.getInstance().getDay() == workdays.Length-1){
            LoadingManager.instance.emailTransition(0);
            return;
        }
        
        //Move us back to the office
        LoadingManager.instance.emailTransition(3);
        StateManager.getInstance().NextDay();
    }
    
    void Update(){
        if(Input.GetKeyDown(KeyCode.Equals))
            CorrectAnswer();
    }
    void WrongAnswer(){
        Debug.Log("Incorrect!");
    }
    // Start is called before the first frame update
    void Start()
    {

        //DAY ONE
        string q = "We'll start off easy, find every tall user.";
        string details = "Use the \"find\" command with the keyword \"tall\" to find them all.";
        string ans = "findtall";
        Question firstQuestion = new Question(q,details,ans);

        q ="Now find every short user.";
        details = "";
        ans = "findshort";
        Question secondQuestion = new Question(q,details,ans);


        Workday DayOne = new Workday(new Question[2]{firstQuestion,secondQuestion});
        
        //DAY TWO
        q = "Find me the address of every short user.";
        details = "After finding a group of users, add the '>' character and the word 'address' to get a list of their addresses.";
        ans = "findshort>address";
        firstQuestion = new Question(q,details,ans);

        q = "Nice work, now can you do find the address of every tall user?";
        details = "";
        ans = "findtall>address";

        q = "Finally, can you get the SSNs for our tall users?";
        details = "After finding a group of users, add the '>' character and the phrase 'SSN' to get a list of their SSNs";
        ans = "findtall>ssn";
        secondQuestion = new Question(q,details,ans);

        Workday DayTwo = new Workday(new Question[2]{firstQuestion,secondQuestion});


        //DAY Three
        q = "The online marketplace FOREST needs a list of every 'single' user we have.";
        details = "Use the \"find\" command with the keyword \"single\".";
        ans = "findsingle";
        firstQuestion = new Question(q,details,ans);

        q ="They'd also like the addresses of these 'single' users.";
        details = "";
        ans = "findsingle>address";
        secondQuestion = new Question(q,details,ans);

        Workday DayThree = new Workday(new Question[2]{firstQuestion,secondQuestion});


        //DAY Four
        q = "Bill 2869 has just outlawed same-sex relationships. As such, please get us a list of every 'queer' user we have. ";
        details = "Use the \"find\" command with the keyword \"queer\".";
        ans = "findqueer";
        firstQuestion = new Question(q,details,ans);

        q ="Congress has also asked for a list of their addresses so they can begin to inform the Police. Please get such a list.";
        details = "Use the '>' command to get addresses";
        ans = "findqueer>address";
        secondQuestion = new Question(q,details,ans);

        q = "Finally, tell us their SSNs";
        details = "Use the '>' command to get SSNs";
        ans = "findqueer>ssn";
        Question thirdQuestion = new Question(q,details,ans);

        Workday DayFour = new Workday(new Question[3]{firstQuestion,secondQuestion,thirdQuestion});





        //Initing a bunch of things
        dayNumber=StateManager.getInstance().getDay();
        workdays = new Workday[4]{DayOne,DayTwo,DayThree,DayFour};
        currentWorkday = workdays[dayNumber];
        activeQuestion = currentWorkday.getQuestion();

        //Display everything and we should be ready to go!
        DisplayQuestion();
        HeaderManager.updateWorkdayHeader(dayNumber);
    }

}
