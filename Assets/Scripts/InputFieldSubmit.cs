using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputFieldSubmit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Always select the input field when we start
        FindObjectOfType<TMP_InputField>().Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
