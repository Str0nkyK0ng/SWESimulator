//How we represent a choice
public class MCQuestionOption
{
    public string option;
    public string optionResponse;
    public MCQuestionOption(string o, string or)
    {
        option = o;
        optionResponse = or;
    }
}

//How we represent a multiple choice question 
public class MultipleChoiceQuestion
{
    public string questionStatement;
    public MCQuestionOption[] questionOptions;
    public string[] prefixes = { "a) ", "b) ", "c) ", "d) " };
    public MultipleChoiceQuestion(string s, MCQuestionOption[] options)
    {
        questionStatement = s;
        questionOptions = options;
    }
    public string getResponse(int opt)
    {
        return questionOptions[opt].optionResponse;
    }

    public string getDisplayString()
    {
        string displayString = "";

        //Display the options
        for(int x = 0; x < 4; x++)
        {
            displayString += prefixes[x] + questionOptions[x].option + '\n';
        }
        return displayString;
    }
}


public class Question
{
    public string questionStatement;
    public string questionDetails;
    public string response;
    public Question(string s, string d, string r)
    {
        questionStatement = s;
        questionDetails = d;
        response = r;
    }
}

