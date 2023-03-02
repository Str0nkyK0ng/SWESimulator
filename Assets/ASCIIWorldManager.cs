using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ASCIIWorldManager{

    Vector2 playerLocation;
    string label;
    Player player;
    Board board;

    public string getLabel(){
        return label;
    }
    public void setLabel(string s){
        label=s;
    }
    public string display(){
        return board.getDisplay();
    }
    public ASCIIWorldManager(){
        board = new Board(19,11,this);
        player = new Player(this);
        playerLocation= new Vector2(5,5);
        board.set(playerLocation,player);
        board.set(5,6,new Cake(this));
    }

    public bool MovePlayer(Vector2 dir){
        setLabel("");
        Vector2 desiredLocation = playerLocation+dir;

        Debug.Log("desiredLocation:"+desiredLocation);
        //See if the location is valid
        if(!board.isValidLocation(desiredLocation)){
            Debug.Log("Desired Location Invalid");
            return false;

        }
        
        //See if anything is there
        Entity inDesiredLocation = board.get(desiredLocation);
        if(inDesiredLocation!=null){
            Debug.Log("Desired Location Filled");
            return false;
        }
        else{
            board.set(playerLocation,null);
            playerLocation=desiredLocation;
            board.set(playerLocation,player);
        }
        return true;
    }

    public bool interact(TextMeshProUGUI label){
        bool didInteract = false;
        //Check everything around the player
        Vector2[] dirs = {new Vector2(0,1),new Vector2(1,0),new Vector2(-1,0),new Vector2(0,-1)};
        for(int i=0;i<4;i++){
                Vector2 checkLocation = playerLocation + dirs[i];
                if(board.isValidLocation(checkLocation)){
                    Entity e = board.get(checkLocation);

                    //smart short circut boolean algebra to prevent bad checks
                    didInteract = didInteract || (e!=null && e.interact());

                }
        }
        return didInteract;
    }
}