using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        int selectedCharacter = int.Parse(EventSystem.current.currentSelectedGameObject.name);
        GameManager.instance.charIndex = selectedCharacter;
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
