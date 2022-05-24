using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update

    private float lifetime = 3.00f;
    public int damage = 20;




    // Update is called once per frame
    void FixedUpdate()
    {
        
        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
            Destroy(this.gameObject);
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        //Check if the arrow collided with the player if it had ,than deal damage to the player 
        if (collision.gameObject == NewPlayer.Instance.gameObject)
        {
            NewPlayer.Instance.Health -= damage;
            Destroy(this.gameObject);
            NewPlayer.Instance.UpdateUI();
        }
        //If the arrow collided with anything else than destroy the arrow object
        else
            Destroy(this.gameObject);
    }
}
