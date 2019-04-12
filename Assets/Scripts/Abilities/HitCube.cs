using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCube : MonoBehaviour
{
    public int damage;
    
    
    private void OnTriggerEnter(Collider target)

    {
        
        if(target.GetComponent<IUnit>() != null)
        {
            
            target.GetComponent<IUnit>().TakeDamge(damage);
            
            
        }
    }

    private void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * 5f;

    }
}
