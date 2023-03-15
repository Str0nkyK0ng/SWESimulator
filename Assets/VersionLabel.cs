using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// using 

public class VersionLabel : MonoBehaviour
{
    void Start(){
        GetComponent<TextMeshProUGUI>().text = "V "+Application.version;
    }

}
