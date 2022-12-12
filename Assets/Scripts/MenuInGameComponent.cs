using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInGameComponent : MonoBehaviour
{
    bool menuOpened = false;
    [SerializeField] Canvas menu;
    [SerializeField] Canvas skill;
    [SerializeField] Canvas validation;
    PlayerControls control;
    LoadGameComponent gameManager;
    void Awake()
    {
        control = new PlayerControls();
        control.PlayersControls.Enable();
        control.PlayersControls.Menu.performed += Menu_performed;
        control.PlayersControls.Skill.performed += Skill_performed;
        menu.gameObject.SetActive(false);
        skill.gameObject.SetActive(false);
        gameManager = GetComponent<LoadGameComponent>();
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
    public void OpenValidation()
    {
        validation.gameObject.SetActive(true);
    }
    public void CloseValidation()
    {
        validation.gameObject.SetActive(false);
    }
    public void SaveGame()
    {
        CloseValidation();
        gameManager.SaveGame();
    }
}
