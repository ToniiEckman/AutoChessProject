using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class ChessPiece : MonoBehaviour,IClickedOn,PieceMover
    {
    public PlayerController player;
    public PlayerController Ronald { get; set; }
    public ChessPiece activeTarget;
    public AudioClip boing;

    //Values for Movement
    private Vector3 StartPos;
    private Vector3 EndPos;
    float height = 5f;
    bool startThrow = false;
    float incrementor = 0;
    private BoardTile TargetBlock;
    

    //Checks if is a hostile peice.
    public bool isEnemy=false;

    //tracks position on chess board
    public BoardTile CurrentBlock { get; set; }
    

    private void Awake()
    {
        gameObject.AddComponent<AudioSource>();
        AudioSource s = GetComponent<AudioSource>();
        s.pitch = 1.8f;
        s.volume = 1.5f;
        s.spatialBlend = 1;
        s.clip = boing;
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
            
            StartPos = new Vector3(CurrentBlock.CurrentX, .5f, CurrentBlock.CurrentZ);
            EndPos = new Vector3(newblock.CurrentX,.5f,newblock.CurrentZ);
            TargetBlock = newblock;
            CurrentBlock.CurrentPiece = null;
            CurrentBlock = TargetBlock;
            CurrentBlock.CurrentPiece = this;
            startThrow = true;
            
            GetComponent<AudioSource>().Play();
            
            
            //float cTime = Time.time * 0.2f;
            //CurrentBlock.CurrentPiece = null;
            //CurrentBlock = newblock;
            //CurrentBlock.CurrentPiece = this;
            
            //  transform.position = new Vector3(CurrentBlock.CurrentX, .5f, CurrentBlock.CurrentZ);

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
    //controles the arc oh how the unit hops
    void Update()
    {
        
        
            if (startThrow)
            {

                incrementor += 0.04f;
                Vector3 currentPos = Vector3.Lerp(StartPos, EndPos, incrementor);
                currentPos.y += height * Mathf.Sin(Mathf.Clamp01(incrementor) * Mathf.PI);
                transform.position = currentPos;
            }
            if (transform.position == EndPos)
            {
                startThrow = false;
                incrementor = 0;
                Vector3 tempPos = StartPos;
                StartPos = transform.position;
                EndPos = tempPos;
                

        }

    }

}
