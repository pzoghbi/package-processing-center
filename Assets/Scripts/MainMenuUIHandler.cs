using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIHandler : MonoBehaviour
{
    public void LoadGame() {
        SceneManager.LoadScene("Game Scene");
    }
    
    public void LoadMenu() {
        SceneManager.LoadScene("Main Menu");
    }
}
