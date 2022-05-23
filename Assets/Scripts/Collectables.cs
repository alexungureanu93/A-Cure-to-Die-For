using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collectables : MonoBehaviour
{
 
    enum ItemType { Coin,Health,Ammo,Inventory}
    [SerializeField] private ItemType itemType;
    [SerializeField] private Sprite inventoryImageName;
    // Start is called before the first frame update
    void Start()
    {
        

        //if (itemType == ItemType.Coin)
        //{
        //    Debug.Log("is coin");
        //}
        //else if (itemType == ItemType.Health)
        //{
        //    Debug.Log("is health");
        //}
        //else if (itemType == ItemType.Health)
        //{ 
        //    Debug.Log("is ammmo");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == NewPlayer.Instance.gameObject)
        {

            if (itemType == ItemType.Coin)
            {
                NewPlayer.Instance.CoinsCollected += 1;
            }
            else if (itemType == ItemType.Health)
            {
                if (NewPlayer.Instance.Health < 100)
                {
                    NewPlayer.Instance.Health += 10;
                }
            }
            else if (itemType == ItemType.Ammo)
            {
                Debug.Log("is ammmo");
            }

            else if (itemType == ItemType.Inventory)
            {
                NewPlayer.Instance.AddInventoryItem(inventoryImageName);

            }
            NewPlayer.Instance.UpdateUI();
            Destroy(gameObject);
        }
    }
}
