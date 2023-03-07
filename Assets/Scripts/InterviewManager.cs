using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InterviewManager : MonoBehaviour
{

    [Header("Interview Panel References")]
    public GameObject interviewPanel;
    public TextMeshProUGUI TMP_question;
    public TextMeshProUGUI TMP_options;

    [Header("Misc")]
    public float responseGraphicDisplayTime = 4f;
    public PortraitDisplay portraitDisplay;

    
    private MultipleChoiceQuestion[] MCQuestions;
    private MultipleChoiceQuestion currentMCQuesiton;
    private int questionIndex = 0;


    private void Start()
    {
        //Text Questions
        MCQuestionOption optionOne = new MCQuestionOption("It’s bullshit.", "I think we're done here.");
        MCQuestionOption optionTwo = new MCQuestionOption("I really resonated with your company vision, which is why I decided to apply. I think data acquisition is fundamental to the future of technology and I’d love to be a part of it!", "Amazing! Glad to hear it");
        MCQuestionOption optionThree = new MCQuestionOption("Nonconsentual data acquisition is immoral.", "I think we're done here.");
        MCQuestionOption optionFour = new MCQuestionOption("What was the question again?", "I think we're done here.");

        MCQuestionOption[] questionOptions = { optionOne, optionTwo, optionThree, optionFour };

        MultipleChoiceQuestion mcQuestion = new MultipleChoiceQuestion("What do you think of our company's vision?", questionOptions);
        MultipleChoiceQuestion mcQuestion2 = new MultipleChoiceQuestion("What do you think of our company's vision?Parttwo", questionOptions);

        MCQuestions = new MultipleChoiceQuestion[]{mcQuestion,mcQuestion2};


        //Init the questions
        currentMCQuesiton = MCQuestions[questionIndex];
        interviewPanel.SetActive(true);
        TMP_options.text = currentMCQuesiton.getDisplayString();
        TMP_question.text = currentMCQuesiton.questionStatement;

        //Init the header
        HeaderManager.updateInterviewHeader(1, questionIndex, MCQuestions.Length);




    }
    void choose(int choice)
    {
        //Display the interviewer's response before moving to the next question
        portraitDisplay.displaySuitPortrait(currentMCQuesiton.getResponse(choice));
        //Start a couroutine to hold everything
        StartCoroutine(holdDisplay());

    }

    public void attemptChoice(string c)
    {
        //Remove any junk from the user's response
        c = c.Replace(")", "");
        c = c.Replace("(", "");
        c = c.Replace(".", "");
        c = c.Replace(" ", "");
        c = c.ToLower();
        int choice;
        switch (c)
        {
            case "a":
                choice = 0;
                break;
            case "b":
                choice = 1;
                break;
            case "c":
                choice = 2;
                break;
            case "d":
                 choice = 3;
                break;
            default:
                return;
        }
        //Actually select the choice
        choose(choice);
    }

    
    void hideInterviewQuestions()
    {
        interviewPanel.SetActive(false);
    }

    void displayInterviewQuestions()
    {
        //Move to next question
        questionIndex++;
        if (questionIndex < MCQuestions.Length)
        {
            currentMCQuesiton = MCQuestions[questionIndex];
            interviewPanel.SetActive(true);
            TMP_options.text = currentMCQuesiton.getDisplayString();
            TMP_question.text = currentMCQuesiton.questionStatement;
            HeaderManager.updateInterviewHeader(1, questionIndex, MCQuestions.Length);
        }
        else
        {
            LoadingManager.instance.LoadScene(1);
        }

    }

    IEnumerator holdDisplay()
    {
        hideInterviewQuestions();
        yield return new WaitForSeconds(responseGraphicDisplayTime);
        portraitDisplay.clearDisplay();
        displayInterviewQuestions();
    }


}
