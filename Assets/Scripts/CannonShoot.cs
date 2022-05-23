using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    public Transform shootpos;
    public GameObject bulletprefab;
    public float timetoshoot = 2.00f;
    public float nextshoot = 3.00f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", timetoshoot, nextshoot);
    }


    private void LateUpdate()
    {
        if(Vector2.Distance(NewPlayer.Instance.transform.position,this.transform.position) <=1.5f)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                Destroy(this.gameObject);
        }
    }

    void Shoot()
    {

        if (Vector2.Distance(NewPlayer.Instance.transform.position, this.transform.position) <= 8.00f)
        {
            GameObject bullet = Instantiate(bulletprefab, shootpos.position, bulletprefab.transform.rotation);

        }
    }


}
