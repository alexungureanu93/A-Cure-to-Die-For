using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewPlayer : PhysicsObject
{
    [SerializeField] private float attackDuration;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;
    [SerializeField] private int coinsCollected;
    [SerializeField] private int health;
    [SerializeField] private Text coinText;
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject attackBox;
    [SerializeField] private int attackPower;


    public List<Sprite> playerForms = new List<Sprite>();
    public List<Sprite> inventoryItems = new List<Sprite>();
    public Image inventoryDisplayed;
    private Vector2 healthBarOriginalSize;
    private int inventoryCounter = 0;
    private int maxHealth = 100;
    public bool isInAreaToSwitch { get; set; }


    //singleton instantiation 
    private static NewPlayer instance;
    public static NewPlayer Instance 
    {
        get 
        {
            if (instance == null) instance = GameObject.FindObjectOfType<NewPlayer>();
            return instance;
        }
    }

    public int CoinsCollected { get => coinsCollected; set => coinsCollected = value; }
    public int Health { get => health; set => health = value; }
    public GameObject AttackBox { get => attackBox; set => attackBox = value; }
    public int AttackPower { get => attackPower; set => attackPower = value; }

    // Start is called before the first frame update
    void Start()
    {
        healthBarOriginalSize = healthBar.rectTransform.sizeDelta;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = new Vector2(Input.GetAxis("Horizontal") * horizontalSpeed, 0);
        if(targetVelocity.x<-0.1)
        {
            transform.localScale =new Vector3 (-1, transform.localScale.y);
        }
        else if(targetVelocity.x>0.1) 
        {
            transform.localScale = new Vector3(1 ,transform.localScale.y);
        }
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = verticalSpeed;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            SwitchInventory();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(ActivateAttack());
        }
        if (Input.GetButtonDown("Fire3"))
        {
            SwitchForm();
        }

        Die();
    }

    private void Die()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Menu");
        }
    }
    private IEnumerator ActivateAttack()
    {
        attackBox.SetActive(true);
        yield return new WaitForSeconds(attackDuration);
        attackBox.SetActive(false);
    }

    public void UpdateUI()
    {
        coinText.text = CoinsCollected.ToString();

        float healthBarSize = healthBarOriginalSize.x * ((float)Health / (float)maxHealth);
        healthBar.rectTransform.sizeDelta = new Vector2(healthBarSize, healthBar.rectTransform.sizeDelta.y);
    }

    public void AddInventoryItem(Sprite imageName) 
    {
        inventoryItems.Add(imageName);
    }
    public void RemoveInventoryItem(Sprite imageName)
    {
        inventoryItems.Remove(imageName);
        if (inventoryDisplayed.sprite == imageName)
        {
            inventoryDisplayed.sprite = inventoryItems[0];
        }

    }

    //Switch between living form and ghost form
    private void SwitchForm() 
    {
        if (isInAreaToSwitch)
        {
            ////switch to GhostForm
            if (gameObject.GetComponent<SpriteRenderer>().sprite.name == "Player")
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = playerForms[1];
                verticalSpeed = verticalSpeed * 2;
                StartCoroutine(StopForm());
                return;
            }

            ////Switch to living form
            if (gameObject.GetComponent<SpriteRenderer>().sprite.name == "PlayerGhost")
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = playerForms[0];
                verticalSpeed = verticalSpeed / 2;
                StartCoroutine(StopForm());
                return;
            }
        }
        else 
        {
            return;
        }

    }

    // will disable transformation
    IEnumerator StopForm() 
    {
        isInAreaToSwitch = false;
        yield return new WaitForSeconds(2);
    }
    private void SwitchInventory()
    {
 
        if (inventoryCounter < inventoryItems.Count)
        {
           inventoryDisplayed.sprite = inventoryItems[inventoryCounter];
           inventoryCounter++;
        }
        else
        {
            inventoryCounter = 0;
        }
    }
}


