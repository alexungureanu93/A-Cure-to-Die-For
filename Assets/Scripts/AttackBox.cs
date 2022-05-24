using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    [SerializeField] private int weaponDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>()) //FindObjectOfType<Enemy>().gameObject)
        {
            collision.gameObject.GetComponent<Enemy>().Health -= weaponDamage + NewPlayer.Instance.AttackPower ;
        }
        //Destroy the gameobjects with tag enemy if the attackbox hit them
        if (collision.gameObject.CompareTag("Enemy"))
            Destroy(collision.gameObject);
    }
}
