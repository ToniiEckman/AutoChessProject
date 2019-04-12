using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetFinder : MonoBehaviour
{
    //finds closest possible target
    public BoardTile FindTarget(BoardTile[,] map, ChessPiece caster,bool ally)
    {
        ChessPiece currentTarget = null;
        float currentTargetDistance = 0;
        List<ChessPiece> Targets = new List<ChessPiece>();

        //loop will find all available chess pieces to target
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (!ally)
                {
                    if (map[i, j].CurrentPiece != caster && map[i, j].CurrentPiece != null && caster.isEnemy != map[i, j].CurrentPiece.isEnemy)
                    {

                        Targets.Add(map[i, j].CurrentPiece);
                    }
                }
                else
                {
                    if (map[i, j].CurrentPiece != caster && map[i, j].CurrentPiece != null && caster.isEnemy == map[i, j].CurrentPiece.isEnemy)
                    {

                        Targets.Add(map[i, j].CurrentPiece);
                    }
                }
            }

        }
        
        //will determine closest piece
        foreach(ChessPiece x in Targets)
        {
            float Distance = Mathf.Sqrt(Mathf.Pow((caster.CurrentBlock.CurrentX - x.CurrentBlock.CurrentX), 2) + Mathf.Pow((caster.CurrentBlock.CurrentZ - x.CurrentBlock.CurrentZ), 2));

            if (currentTarget == null)
            {
                currentTarget = x;
                currentTargetDistance = Distance;
            }
            else
            {
                if (Distance < currentTargetDistance)
                {
                    currentTarget = x;
                    currentTargetDistance = Distance;
                }
            }
        }
        return currentTarget.CurrentBlock;
    }

    public BoardTile Pathfinding(BoardTile[,] map,BoardTile casterLocation,BoardTile targetLocation,int range)
    {
        
        BoardTile currentTarget = null;
        float currentTargetDistance = 0;
        //finds all possible tiles within range of target
        List<BoardTile> possible = new List<BoardTile>();
        int casterX = casterLocation.CurrentX;
        int casterZ = casterLocation.CurrentZ;

        int targetX = targetLocation.CurrentX;
        int targetZ = targetLocation.CurrentZ;

        for (int i = targetX - range;i <= targetX + range; i++)
        {
            if (i >=0 && i <8)
            {
                for (int j = targetZ - range; j <= targetZ + range; i++)
                {
                    if(j >= 0 && j < 8)
                    {
                        if (map[i, j] != targetLocation)
                        {
                            possible.Add(map[i, j]);
                        }
                    }
                }
            }

        }
        foreach (BoardTile x in possible)
        {
            float Distance = Mathf.Sqrt(Mathf.Pow((casterX - targetX), 2) + Mathf.Pow((casterZ - targetZ), 2));

            if (currentTarget == null)
            {
                currentTarget = x;
                currentTargetDistance = Distance;
            }
            else
            {
                if (Distance < currentTargetDistance)
                {
                    currentTarget = x;
                    currentTargetDistance = Distance;
                }
            }
        }
        return currentTarget;
        

    }

}
