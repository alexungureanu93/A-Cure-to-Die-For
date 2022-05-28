using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    [SerializeField] private int weaponDamage;


    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int damagevalue = weaponDamage + NewPlayer.Instance.AttackPower;
        if(collision.gameObject.GetComponent<EnemyHealth>())
        {
            collision.gameObject.GetComponent<EnemyHealth>().Damage(damagevalue);
        }
    }
}
