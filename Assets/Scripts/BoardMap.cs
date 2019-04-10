using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoardMap : MonoBehaviour {

    // Use this for initialization

    //array holding BoardTile instances
    private BoardTile[,] TrackedTiles = new BoardTile[8, 8];
    public List<GameObject> boardTilePrefabs;
    public PlayerController player;
    public PlayerController Ronald { get; set; }
    public int banana { get; set; }

    //make this a list of pieces
    public GameObject TempPiece;
    public GameObject TempPiece2;

    private void Update()
    {
        
    }

    private void Awake()
    {
        
        
        ConstructBoard();
        SpawnPieces(TempPiece,TrackedTiles[0,1]);
        SpawnPieces(TempPiece2,TrackedTiles[5,7]);
        TrackedTiles[5, 7].getPiece().toggleFriendly();

    }

    public void setPlayer(PlayerController daddy)
    {
        player = daddy;
    }
    //Changes Color
    bool toggle = false;
    //constructs the player board
    private void ConstructBoard()
    {

        for (int i = 0; i < 8; i++)
        {

            for (int j = 0; j < 8; j++)
            {
                //goes throup double arraw and spawns a tile prefab for the grid
                GameObject go = Instantiate(boardTilePrefabs[0], new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                go.transform.SetParent(transform);
                go.transform.position = new Vector3(transform.position.x + i, 0, transform.position.z + j);


                TrackedTiles[i, j] = go.GetComponent<BoardTile>();

                TrackedTiles[i, j].setPosition(i, j);
                TrackedTiles[i, j].CurrentBoard = TrackedTiles;


                if (toggle)
                {

                    TrackedTiles[i, j].GetComponent<Renderer>().material.color = TrackedTiles[i, j].BaseColor;
                    toggle = !toggle;
                }
                else
                {

                    TrackedTiles[i, j].GetComponent<Renderer>().material.color = TrackedTiles[i, j].AccentColor;
                    toggle = !toggle;
                }


            }
            toggle = !toggle;
        }
        //Node Construction
        for (int i = 0; i < 8; i++)
        {

            for (int j = 0; j < 8; j++)
            {
                //up node
                if(j + 1 < 8)
                    TrackedTiles[i, j].NeighborNodes.Add(TrackedTiles[i,j+1]);
                //down node
                if (j - 1 >= 0)
                    TrackedTiles[i, j].NeighborNodes.Add(TrackedTiles[i, j - 1]);
                //left node
                if (i - 1 >= 0)
                    TrackedTiles[i, j].NeighborNodes.Add(TrackedTiles[i - 1, j]);
                //right node
                if (i + 1 < 8)
                    TrackedTiles[i, j].NeighborNodes.Add(TrackedTiles[i + 1, j]);
            }
        }
    }

    //spawn some pieces
    public void SpawnPieces(GameObject piece,BoardTile tile)
    {
        
        GameObject go = Instantiate(piece, new Vector3(tile.CurrentX, 1.5f, tile.CurrentZ), Quaternion.identity);
        
        go.transform.SetParent(transform);
        tile.CurrentPiece = go.GetComponent<ChessPiece>();
        go.GetComponent<ChessPiece>().CurrentBlock = tile;
        go.GetComponent<ChessPiece>().setPlayer(player);

    }
}
