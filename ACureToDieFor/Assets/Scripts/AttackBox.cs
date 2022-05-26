using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    [SerializeField] private int weaponDamage;


    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>()) //FindObjectOfType<Enemy>().gameObject)
        {
            collision.gameObject.GetComponent<Enemy>().Health -= weaponDamage + NewPlayer.Instance.AttackPower ;
        }
        if(collision.gameObject.GetComponent<EnemyHealth>())
        {
            collision.gameObject.GetComponent<EnemyHealth>().Health -= weaponDamage + NewPlayer.Instance.AttackPower;
        }
    }
}
