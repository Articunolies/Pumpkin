using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Restart : MonoBehaviour
{
    public GameObject SceneController;
    ScoreController scoreController;

    void Start() 
    {
        SceneController = GameObject.Find("Score Controller");
        scoreController = SceneController.GetComponent<ScoreController>();
    }

    public void RestartGame()
    {
        // Scene 0 -> MainScene: Main Gameplay Scene
        // Scene 1 -> GameOver: Game Over Scene
        SceneManager.LoadScene(0);
        scoreController.SetScore(0);
    }
}
