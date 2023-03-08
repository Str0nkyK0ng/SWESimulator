using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class QuestionManager : MonoBehaviour
{
    
    public Question activeQuestion;
    public Question[] questionList;
    public int questionIndex=0;
    public TextMeshProUGUI questionStatement, questionDetails;


    void DisplayQuestion(){
        questionStatement.text=activeQuestion.questionStatement;
        questionDetails.text=activeQuestion.questionDetails;
    }
    void HideDisplay(){
        questionStatement.text="";
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
        questionIndex++;
        if(questionIndex<questionList.Length){
            activeQuestion=questionList[questionIndex];
            DisplayQuestion();
            Debug.Log("Correct!");
            HeaderManager.updateInterviewHeader(2, questionIndex, questionList.Length);
        }
        else
        {
            HeaderManager.hideHeader();
            HideDisplay();
            LoadingManager.instance.WaitingForEmailLoadScene(3);
        }
    }
    void WrongAnswer(){
        Debug.Log("Incorrect!");
    }
    // Start is called before the first frame update
    void Start()
    {
        string details = "\"name\": \"John Doe\",\n  \"age\": \"33\",\n  \"gender\": \"male\",\n  \"dob\": \"Nov 11th, 2001\",\n  \"citizenship-status\": \"undocumented\",\n  \"relationship-status\": \"single\",\n  \"religious-affiliation\": \"Christian\",\n  \"parents\": “deceased”,\n  \"sexuality\": \"bisexual\",\n  \"Income\": \"$43,214\"";
        string q = "Here's the data we have on one of our users, can you tell us what their relationship status is?";
        string ans = "single";
        Question firstQuestion = new Question(q,details,ans);


        details ="12, 5, 2, 14, 1, 11, 9, 10, 8, 7, 3, 15, 13, 6, 4";
        q = "Order the following numbers 1-15";
        ans = "123456789101112131415";
        Question secondQuestion = new Question(q,details,ans);

        details ="3, 7, 13, 6, 11, 10, 14, 2, 12, 9, 1, 8, 5, 15, 4";
        q = "Now, do it again for these numbers";
        ans = "123456789101112131415";
        Question thirdQuestion = new Question(q,details,ans);

        details ="Uncovering hidden data that users hide.";
        q = "The following is our company statement.\nPlease replace any 'a' characters with '@' symbols.";
        ans = "uncoveringhiddend@t@th@tusershide";
        Question fourthQuestion = new Question(q,details,ans);

        details = "@@@@@@@@a@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@";
        q = "How many '@' symbols are before the ‘a’ character in the following text?";
        ans = "8";
        Question fifthQuestion = new Question(q, details, ans);

        questionList = new Question[5]{firstQuestion,secondQuestion,thirdQuestion,fourthQuestion,fifthQuestion};
        questionIndex=0;
        activeQuestion=questionList[questionIndex];
        DisplayQuestion();
        HeaderManager.updateInterviewHeader(2, questionIndex, questionList.Length);
    }
}
