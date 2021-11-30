using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject GameOverUI;
    public Animator transitionanim;
    bool GameHasEnded = false;
    public float RestartDelay = 3f;
    public void EndGame()
    {
        if (GameHasEnded == false)
        {
            GameHasEnded = true;
            GameOverUI.SetActive(true);
            Invoke("Restart", RestartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

