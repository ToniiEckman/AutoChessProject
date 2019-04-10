using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class BoardTile:MonoBehaviour,IClickedOn
{
    //coordinates of the tile
    public int CurrentX { get; set; }
    public int CurrentZ { get; set; }
    public ChessPiece CurrentPiece { set; get; }
    public Color BaseColor = UnityEngine.Color.black;
    public Color AccentColor = UnityEngine.Color.white;
    public BoardTile[,] CurrentBoard;
    public List<BoardTile> NeighborNodes = new List<BoardTile>();

    

    public bool setPiece(ChessPiece newPiece)
    {
        //checks if tile already has a piece in it
        if (CurrentPiece == null)
        {
            CurrentPiece = newPiece;
            return true;
        }
        //returns error if space is full
        else
        {
            Debug.Log("ATTENTION: Space already has chess piece in it");
            return false;
        }
    }
    //returns what piece is currently on the tile
    public ChessPiece getPiece()
    {
        
        if(CurrentPiece != null)
        {
            return CurrentPiece;
        }
        else
        {
            return null;
        }
    }
    //Not sure why this is here but whatever
    public void setPosition(int x,int z)
    {
        CurrentX = x;
        CurrentZ = z;
    }

    //whenever the player clicks on a tile
    public void ClickedOn(PlayerController controller)
    {
        
        //checks to see if the player has any chess pieces selected
        if(controller.selected != null && controller.selected.GetComponent<ChessPiece>() != null)
        {
            controller.selected.GetComponent<ChessPiece>().MovePiece(this);
            controller.selected = null;
           
        }
    }
    
}