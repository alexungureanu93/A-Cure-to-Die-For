using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    public Transform shootpos;
    public GameObject bulletprefab;
    public float timetoshoot = 2.00f;
    public float nextshoot = 3.00f;
    public float range = 8.0f;
    public float killrange = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", timetoshoot, nextshoot);
    }


    private void LateUpdate()
    {
        if(Vector2.Distance(NewPlayer.Instance.transform.position,this.transform.position) <=killrange)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                Destroy(this.gameObject);
        }
    }

    void Shoot()
    {   
        

       if (Vector2.Distance(NewPlayer.Instance.transform.position, this.transform.position) <= range)
        {
            GameObject bullet = Instantiate(bulletprefab, shootpos.position, bulletprefab.transform.rotation);

        }
    }


}
