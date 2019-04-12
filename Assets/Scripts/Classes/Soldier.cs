using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : BaseClass,IUnit
{
    
    private float elapsedTime = 0;
    private void Start()
    {
        
        GameManager.combatEvent += Combat;

    }
    private void OnDisable()
    {
        GameManager.combatEvent -= Combat;
    }
    private void Update()
    {
        if (health < 0)
            Destroy(gameObject);
    }

    // Update is called once per frame

         
    public new void Combat()
    {
        
        BoardTile[,] currentBoard = this.GetComponent<ChessPiece>().CurrentBlock.CurrentBoard;
        if (!Winner(currentBoard, this.GetComponent<ChessPiece>()))
        {
            if (Time.time > elapsedTime)
            {

                if (Target != null)
                {


                    //checks if target is in range
                    List<BoardTile> temp = InRange(currentBoard, this.GetComponent<ChessPiece>().CurrentBlock, Target.CurrentBlock, Ability1.range);
                    if (temp.Contains(this.GetComponent<ChessPiece>().CurrentBlock))
                    {
                        transform.LookAt(Target.transform.position);
                        this.GetComponent<AnimController>().PlayAttack();
                        Ability1.TriggerAbility(Target.CurrentBlock);
                    }
                    else
                    {
                        
                        //first pathfind finds closest tile within range of target
                        BoardTile temp2 = Pathfinding(currentBoard, this.GetComponent<ChessPiece>().CurrentBlock, Target.CurrentBlock, Ability1.range);
                        //next pathfinding finds closest tile within move range
                        this.GetComponent<ChessPiece>().MovePiece(Pathfinding(currentBoard, temp2, this.GetComponent<ChessPiece>().CurrentBlock, move));
                        Target = FindTarget(currentBoard, this.GetComponent<ChessPiece>(), false).CurrentPiece;
                    }
                }
                else
                {

                    Target = FindTarget(currentBoard, this.GetComponent<ChessPiece>(), false).CurrentPiece;


                }





                elapsedTime = Time.time + speed;
            }
        }
    }
 

    public void TakeDamge(float value)
    {
        health += value;
    }
}
