using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public GameObject arrowprefab;
    public GameObject arrowspawn;
    public GameObject target;
    public GameObject archerbase;
    public float speed = 20.0f;
    private bool canshootagain = true;
    public float archerRange = 10.00f;
    public float angleaccuracy = 30.00f;
    

    private bool onright=false;
   
    

    // Update is called once per frame
    void LateUpdate()
    {   
        //To check if the player is on the right or left using x cordinates
        if(target.transform.position.x <this.transform.position.x)
        {
            Debug.Log("On Left");
            onright = false;

        }
        else//If the player is on the right
        {
            
            if(!onright)//To check if the rotation is not updated already
            {
                archerbase.transform.localEulerAngles = new Vector3(0, 180, 0);//180 is used to flip the y axis to update the target
                Debug.Log("Right");
                onright = true;//It will stop to update the rotation again as this all is in update

            }
        }




        if (target != null)
        {
            //Get the direction from the archer to the player
            Vector2 direction = (target.transform.position - archerbase.transform.position).normalized;

            //Check if the player is in the shooting range of the archer
            if (Vector2.Distance(target.transform.position, archerbase.transform.position) <= archerRange)
            {

                float? angle = RotateBow();
                if (canshootagain && angle != null && Vector3.Angle(direction, archerbase.transform.position) > angleaccuracy)
                    Shoot();
            }
              
         

        }
        else
            return;

        
    }

    void ShootAgain()
    {
        canshootagain = true;
    }

    void Shoot()
    {
        //Instantiate the arrow prefab at spawn position and with the rotation of spawn object(bow)
        GameObject arrow = Instantiate(arrowprefab, arrowspawn.transform.position, arrowspawn.transform.rotation);
        //Add velocity to the arrow on the negative x direction 
        arrow.GetComponent<Rigidbody2D>().velocity = (-1)*speed * this.transform.right;
        //To control the shooting rate
        canshootagain = false;
        Invoke("ShootAgain", 3.5f);
       
        

    }

    float? RotateBow()
    {
        float? angle = CalculateAngle(true);
        if (angle != null)
        {
            //Rotate the archer bow on the calculated angle
            this.transform.localEulerAngles = new Vector3(0,this.transform.rotation.y,360-(float)angle);
        }
        return angle;
    }

    float? CalculateAngle(bool getangle)
    {
        //Calculate the angle to shoot the player using formula of Tan
        Vector2 targetdir = target.transform.position - this.transform.position;//Get the direction to player
        float y = targetdir.y;//Get the y distance to the target player
        targetdir.y = 0;
        float x = targetdir.magnitude;//Get the x distance to the player
        float grvity = 9.81f;//Initialize gravity 
        float speedSqr =speed*speed ;// Formula has square of speed . So it is initialised to make the calculation easy
        float undertheSqr = (speedSqr * speedSqr) - grvity*(grvity * x * x + 2 * y * speedSqr);

        if (undertheSqr >= 0)
        {
            float underroot = Mathf.Sqrt(undertheSqr);
            float angletoshoot = speedSqr - underroot;
            if (getangle)                                     //Multiplied to convert the radian angle to degrees as the Atan2 return value in radians
                return (Mathf.Atan2(angletoshoot, grvity * x) * Mathf.Rad2Deg);
            else
                return null;
        }
        else
            return null;
            
        



    }

}
