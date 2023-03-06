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

        headerString += "</mspace>";
        header.text = headerString;

    }
}
