using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextAdventureManager : MonoBehaviour
{
    public TextMeshProUGUI boardText;
    public TextMeshProUGUI labelText;
    ASCIIWorldManager worldManager;

    // Start is called before the first frame update
    void Start()
    {
        worldManager = new ASCIIWorldManager();

    }



    // Update is called once per frame
    void Update()
    {
        int horiz = Mathf.RoundToInt(Input.GetAxis("Horizontal"));
        int vert = -1*Mathf.RoundToInt(Input.GetAxis("Vertical"));
        Vector2 input=new Vector2(horiz,vert);



        if(Input.GetKeyDown(KeyCode.E)){
            worldManager.interact(labelText);
        }
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            worldManager.MovePlayer(new Vector2(0,1));
        }
        if(Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow)){
            worldManager.MovePlayer(new Vector2(0,-1));
        }
        if(Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.LeftArrow)){
            worldManager.MovePlayer(new Vector2(-1,0));
        }
        if(Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.RightArrow)){
            worldManager.MovePlayer(new Vector2(1,0));
        }


        boardText.text = worldManager.display();
        labelText.text = worldManager.getLabel();
    }
}
