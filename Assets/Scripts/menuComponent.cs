using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuComponent : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NewGame()
    {
        PlayerPrefs.SetString("Type", "New Game");
        SceneManager.LoadScene("PossibleMap");
        
    }

    public void Continue()
    {
        PlayerPrefs.SetString("Type", "Continue");
        SceneManager.LoadScene("PossibleMap");
    }

    

    public void Quit()
    {
        Application.Quit();
    }
}
