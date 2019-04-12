using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<BoardMap> boards;

    public delegate void CombatDelegate();
    public static event CombatDelegate combatEvent;

    private bool combatphase = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            combatphase = !combatphase;
        }
        if(combatphase && combatEvent != null)
        {
            combatEvent();
        }
    }

}
