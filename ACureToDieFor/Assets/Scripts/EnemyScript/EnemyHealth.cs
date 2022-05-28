using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]protected int health;
    public int Health { get => health; set => health = value; }




    // Update is called once per frame
    void Update()
    {
        
        if (Health <= 0)
            Die();
    }
    public  void Damage(int damagevalue)
    {
        Health -= damagevalue;
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
