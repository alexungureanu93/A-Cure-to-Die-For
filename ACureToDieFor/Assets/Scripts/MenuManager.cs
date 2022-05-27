using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public Animation levelanimation;
    

    public void StartGame()
    {
        SceneManager.LoadScene(1);
       levelanimation.Play();
    }
}
