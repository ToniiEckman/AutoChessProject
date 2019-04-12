using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Script : PlayerController {
    

    

    // Update is called once per frame
    private void Update()
    {
        currentlyLookingAt = PointingAt();
        PlayerSelect();
        

    }


}
