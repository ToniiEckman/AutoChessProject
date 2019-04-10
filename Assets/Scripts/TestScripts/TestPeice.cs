using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPeice : ChessPiece{

    private void Update()
    {
        if(isEnemy)
        {
            this.GetComponent<Renderer>().material.color = UnityEngine.Color.red;

            
        }
    }

}
