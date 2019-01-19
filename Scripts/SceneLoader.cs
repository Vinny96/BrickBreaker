using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    // variables
    int currentSceneIndex;
    GameStatus gameState;



    // this is used for initialization
    private void Start()
    {
        gameState = FindObjectOfType<GameStatus>();
    }


    // methods
    public void LoadNextScene()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        gameState.ResetScore();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
        




}
