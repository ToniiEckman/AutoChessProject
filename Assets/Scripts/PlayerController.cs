using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour {

    public GameObject currentlyLookingAt;
    public GameObject selected;
    public GameObject board;
    public Camera myCamera;
    public int StartingX;
    public int StartingY;

    Camera playerview;
    private void Awake()
    {
        
        spawnBoard();
        playerview = Instantiate(myCamera);
        playerview.transform.SetParent(transform);
        playerview.transform.position = new Vector3(playerview.transform.position.x + StartingX, playerview.transform.position.y, playerview.transform.position.z + StartingY);

        
        
        
    }
    //Returns whatever cursor is pointing at
    public GameObject PointingAt()
    {
        Ray ray = playerview.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject go = hitInfo.collider.gameObject;
            if (go != null)
            {
                return go;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }


    }
    //selects whatever the player is clicking on
    public void PlayerSelect()
    {
        if (Input.GetMouseButtonDown(0) && currentlyLookingAt != null)
        {
            if (currentlyLookingAt.GetComponent<IClickedOn>() != null)
            {
                currentlyLookingAt.GetComponent<IClickedOn>().ClickedOn(this);
            }
        }
    }
    //assigns whatever is selected
    public void SetSelected()
    {
        selected = currentlyLookingAt;
    }

    private void spawnBoard()
    {
        GameObject go = Instantiate(board,new Vector3(StartingX,0,StartingY),Quaternion.identity);
        
        go.GetComponent<BoardMap>().player = this;
        go.transform.SetParent(transform);

        go.GetComponent<BoardMap>().banana = 1;

        
    }


}
