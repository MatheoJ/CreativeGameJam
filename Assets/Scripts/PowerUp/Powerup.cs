using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public PoweupEffect poweupEffect;
    
    public float timeBeforeDestroy = 20.0f;
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // Destroy the parent of the object as well
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            
            Destroy(gameObject);
            poweupEffect.Apply(collision.gameObject);
        }
       
    }

    private void Update()
    {
        StartCoroutine(PowerupGone());
    }

    private IEnumerator PowerupGone()
    {
        yield return new WaitForSeconds(timeBeforeDestroy);
        
        // Destroy the parent of the object as well
        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }
        
        Destroy(gameObject);
    }

}
