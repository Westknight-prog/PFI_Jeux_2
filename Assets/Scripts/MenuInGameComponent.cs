using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInGameComponent : MonoBehaviour
{
    bool menuOpened = false;
    [SerializeField] Canvas menu;
    [SerializeField] Canvas skill;
    PlayerControls control;
    void Awake()
    {
        control = new PlayerControls();
        control.PlayersControls.Enable();
        control.PlayersControls.Menu.performed += Menu_performed;
        control.PlayersControls.Skill.performed += Skill_performed;
        menu.gameObject.SetActive(false);
        skill.gameObject.SetActive(false);
    }

    private void Skill_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (skill.gameObject.activeSelf)
        {
            skill.gameObject.SetActive(false);
        }
        else
        {
            skill.gameObject.SetActive(true);
        }
    }

    private void Menu_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (menu.gameObject.activeSelf)
        {
            Resume();
        }
        else
        {
            StopGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Resume()
    {
        Time.timeScale = 1;
        menu.gameObject.SetActive(false);
    }
    public void StopGame()
    {
        Time.timeScale = 0;
        menu.gameObject.SetActive(true);
    }
    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
