using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    public float speed = 6.00f;
    private float lifetime = 3.00f;
    public int damage = 40;

    


    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.left * Time.deltaTime * speed);
        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == NewPlayer.Instance.gameObject)
        {
            NewPlayer.Instance.Health-= damage;
            Destroy(this.gameObject);
            NewPlayer.Instance.UpdateUI();
        }
    }
}
