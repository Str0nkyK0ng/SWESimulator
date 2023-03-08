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



        board = new Board(31,11,this);
        player = new Player(this);

        //The player starts in the left center
        playerLocation = new Vector2(1,5);


        //Make a hallway (clear out the center 3 rows)
        for(int c = 1; c < 30; c++)
        {
            board.set(6, c, null);
            board.set(5, c, null);
            board.set(4, c, null);
        }



        board.set(playerLocation,player);
        board.set(9, 9, new Desk(this));


        //These rooms just have workers & desks
        HollowRoom(new Vector2(1,1),new Vector2(5,2));
        board.set(1,3, new Desk(this));
        board.set(2,3, new OfficeWorker(this));

        HollowRoom(new Vector2(7,1),new Vector2(11,2));
        board.set(1,9, new Desk(this));
        board.set(2,9, new OfficeWorker(this));

        HollowRoom(new Vector2(13,1),new Vector2(17,2));
        board.set(1,15, new Desk(this));
        board.set(2,15, new OfficeWorker(this));


        //These are the final two rooms with the desk & snacks, so we'll make sure they're accessible
        HollowRoom(new Vector2(19,1),new Vector2(23,2));
        board.set(1,21, new Snacks(this));
        board.set(3,21,null);

        HollowRoom(new Vector2(25,1),new Vector2(29,2));

        board.set(1,27, new Desk(this));
        board.set(3,27,null);


        //Ohh god this sucks to do

        int bottomRowOffset = 7;

        HollowRoom(new Vector2(1,1+bottomRowOffset),new Vector2(5,2+bottomRowOffset));
        board.set(1+bottomRowOffset,3, new OfficeWorker(this));
        board.set(2+bottomRowOffset,3, new Desk(this));

        HollowRoom(new Vector2(7,1+bottomRowOffset),new Vector2(11,2+bottomRowOffset));
        board.set(1+bottomRowOffset,9, new OfficeWorker(this));
        board.set(2+bottomRowOffset,9, new Desk(this));

        HollowRoom(new Vector2(13,1+bottomRowOffset),new Vector2(17,2+bottomRowOffset));

        board.set(1+bottomRowOffset,15, new OfficeWorker(this));
        board.set(2+bottomRowOffset,15, new Desk(this));

        HollowRoom(new Vector2(19,1+bottomRowOffset),new Vector2(23,2+bottomRowOffset));

        board.set(1+bottomRowOffset,21, new OfficeWorker(this));
        board.set(2+bottomRowOffset,21, new Desk(this));

        HollowRoom(new Vector2(25,1+bottomRowOffset),new Vector2(29,2+bottomRowOffset));
                
        board.set(1+bottomRowOffset,27, new OfficeWorker(this));
        board.set(2+bottomRowOffset,27, new Desk(this));

    }
    
    public void HollowRoom(Vector2 topLeft, Vector2 botRight){
        for(int r=(int)topLeft.y;r<=botRight.y;r++){
            for(int c=(int)topLeft.x;c<=botRight.x;c++){
                board.set(r,c,null);
            }
        }
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