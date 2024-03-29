using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Board{
    Entity[][] entityGrid;
    int cols;
    int rows;
    public Board(int c, int r, ASCIIWorldManager world){
        
        cols=c;
        rows=r;

        //initalize the board
        entityGrid = new Entity[rows][];
        for(int i=0;i<rows;i++){
            entityGrid[i] = new Entity[cols];
            for(int j=0;j<cols;j++){

                //Default to making a wall everywhere
                Wall newWall = new Wall(world);
                entityGrid[i][j] = newWall;


            }
        }
    }
    public void set(int r, int c, Entity e){
        if(c<0 || c>cols)
            throw new System.IndexOutOfRangeException();
        if(r<0 || r>cols)
            throw new System.IndexOutOfRangeException();
        entityGrid[r][c]=e;
    }
    public void set(Vector2 pos, Entity e){
        if(isValidLocation(pos))
            entityGrid[(int)pos.y][(int)pos.x] = e;
    }

    public void clearBox(Vector2 topLeft, Vector2 bottomRight)
    {
        for(int r = (int)topLeft.y; r < (int)bottomRight.y; r++)
        {
            for (int c = (int)topLeft.x; c < (int)bottomRight.x; c++)
            {
                entityGrid[r][c] = null;
            }

        }
    }
    
    public Entity get(int r, int c){
        return entityGrid[r][c];
    }
    public Entity get(Vector2 pos){
        return entityGrid[(int)pos.y][(int)pos.x];
    }

    public bool isValidLocation(Vector2 pos){
        int r = (int)pos.y;
        int c = (int)pos.x;
        if(r<0 || c<0 || r>rows-1 || c > cols-1)
            return false;
        return true;
    }

    public bool isValidLocation(int r, int c){
        if(r<0 || c<0 || r>rows-1 || c > cols-1)
            return false;
        return true;
    }


    public string getDisplay(){
        string display = "<mspace=0.01>";
        for(int i=0;i<rows;i++){
            for(int j=0;j<cols;j++){
                Entity e = get(i,j);
                if(e==null)
                    display+='.';
                else
                    display+=e.displayChar;
            }
            display+='\n';
        }
        return display;
    }
}