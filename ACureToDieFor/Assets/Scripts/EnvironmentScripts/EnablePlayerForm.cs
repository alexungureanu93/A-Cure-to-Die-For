using UnityEngine;

public class EnablePlayerForm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Will set the ability for the player to transform
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == NewPlayer.Instance.gameObject)
        {
            NewPlayer.Instance.isInAreaToSwitch = true;
        }
    }
}
