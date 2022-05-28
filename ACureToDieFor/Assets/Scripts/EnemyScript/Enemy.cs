using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PhysicsObject
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float rayCastLenght;
    [SerializeField] private Vector2 rayCastOffest;
    [SerializeField] private LayerMask rayCastLayerMask;
    [SerializeField] private int enemyCollisiondamage;
    
    private int maxHealth = 100;
    private int direction=1;
    private RaycastHit2D rightLedgeRayCastHit;
    private RaycastHit2D leftLedgeRayCastHit;
    private RaycastHit2D rightWallRayCastHit;
    private RaycastHit2D leftWallRayCastHit;

    public int EnemyCollisiondamage { get => enemyCollisiondamage; set => enemyCollisiondamage = value; }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = new Vector2(horizontalSpeed *direction, 0);

        //check right ledge
        rightLedgeRayCastHit = Physics2D.Raycast(new Vector2(transform.position.x + rayCastOffest.x, transform.position.y+rayCastOffest.y),Vector2.down, rayCastLenght);
        Debug.DrawRay(new Vector2(transform.position.x + rayCastOffest.x, transform.position.y + rayCastOffest.y), Vector2.down * rayCastLenght, Color.red);
        if (rightLedgeRayCastHit.collider == null) 
        {
            direction = -1;
        }
        else 
        {
            Debug.Log("Iam touching :" + rightLedgeRayCastHit.collider.gameObject);
        }
        rightWallRayCastHit = Physics2D.Raycast(new Vector2(transform.position.x , transform.position.y + rayCastOffest.y), Vector2.right, rayCastLenght,rayCastLayerMask);
        if (rightWallRayCastHit.collider != null)
        {
            direction = -1;
        }

        leftWallRayCastHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + rayCastOffest.y), Vector2.left, rayCastLenght, rayCastLayerMask);
        if (leftWallRayCastHit.collider != null)
        {
            direction = 1;

        }

        //check left ledge
        leftLedgeRayCastHit = Physics2D.Raycast(new Vector2(transform.position.x - rayCastOffest.x, transform.position.y + rayCastOffest.y), Vector2.down, rayCastLenght);
        Debug.DrawRay(new Vector2(transform.position.x - rayCastOffest.x, transform.position.y + rayCastOffest.y), Vector2.down * rayCastLenght, Color.red);
        if (leftLedgeRayCastHit.collider == null)
        {
            direction = 1;

        }

       
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == NewPlayer.Instance.gameObject)
        {
            PlayerHurt(EnemyCollisiondamage);
        }
    }

    private static void PlayerHurt(int damage)
    {
        NewPlayer.Instance.Health -= damage;
        NewPlayer.Instance.UpdateUI();
    }
}
