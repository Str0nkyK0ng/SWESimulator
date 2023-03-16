using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    public int workdayNumber = 0;
    private static StateManager instance;

    public static StateManager getInstance(){
        return instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        instance=this;
    }
    public void NextDay(){
        workdayNumber++;
    }
    public int getDay(){
        return workdayNumber;
    }
}
