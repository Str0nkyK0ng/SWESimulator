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
    public TextMeshProUGUI interviewHeader,questionStatement, questionDetails;


    void DisplayQuestion(){
        questionStatement.text=activeQuestion.questionStatement;
        questionDetails.text=activeQuestion.questionDetails;
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
            SceneManager.LoadScene(1);
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

        details ="Uncovering hidden data that users hide.";
        q = "The following is our company statement.\nPlease replace any 'a' characters with '@' symbols.";
        ans = "uncoveringhiddend@t@th@tusershide";
        Question thirdQuestion = new Question(q,details,ans);

        details = "@@@@@@@@a@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@";
        q = "Starting from 0, what is the index of the ‘a’ character in the following text?";
        ans = "8";
        Question fourthQuestion = new Question(q, details, ans);

        questionList = new Question[4]{firstQuestion,secondQuestion,thirdQuestion,fourthQuestion};
        questionIndex=0;
        activeQuestion=questionList[questionIndex];
        DisplayQuestion();
        HeaderManager.updateInterviewHeader(2, questionIndex, questionList.Length);
    }
}
