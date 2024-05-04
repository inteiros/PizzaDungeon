using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptMenu : MonoBehaviour
{
    MenuAudio menuAudio;

    void Start()
    {
        menuAudio = GameObject.FindGameObjectWithTag("Audio").GetComponent<MenuAudio>();
    }
    public void StartGame()
    {
        menuAudio.PlayStart();
        SceneManager.LoadSceneAsync(1);
    }
    public void Quit()
    {
        menuAudio.PlayStart();
        Application.Quit();
    }
}
