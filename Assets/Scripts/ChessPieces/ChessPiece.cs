using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class ChessPiece : MonoBehaviour,IClickedOn,PieceMover
    {
    public PlayerController player;
    public PlayerController Ronald { get; set; }
    public ChessPiece activeTarget;

    //Checks if is a hostile peice.
    public bool isEnemy=false;

    //tracks position on chess board
    public BoardTile CurrentBlock { get; set; }

    private void Awake()
    {
     
    }

    public void ClickedOn(PlayerController controller)
    {
        //will tell player to select this piece
        controller.SetSelected();
    }
    //moves to designated coordinates and if passed a player will have that player unselect this piece.
    public void MovePiece(BoardTile newblock)
    {
        
        if (newblock.CurrentPiece != null)
        {
            Debug.Log("spot is taken");
        }
        else
        {
            CurrentBlock.CurrentPiece = null;
            CurrentBlock = newblock;
            CurrentBlock.CurrentPiece = this;
            transform.position = new Vector3(CurrentBlock.CurrentX, .5f, CurrentBlock.CurrentZ);
            
        }
    }

    public void toggleFriendly()
    {
        isEnemy = !isEnemy;
    }

    public void setPlayer(PlayerController daddy)
    {
        player = daddy;
    }

    

}
