using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {

    // config params
    [SerializeField] TextMeshProUGUI scoreField;
    [SerializeField] int pointsPerBlock;
    [Range(0.1f, 10.0f)] [SerializeField] float gameTime;
    int score;

    // game state
    [SerializeField] bool IsAutoPlayOn;

    //debugging
    [SerializeField] int currentScore; // serialized for debugging purposes


    // this code runs before anything else 
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }


    }



    // Use this for initialization
    void Start()
    {
        scoreField.text = "0";
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameTime;
    }


    // methods 
    public int IncreaseScore()
    {
        score = score + pointsPerBlock;
        currentScore = score;
        scoreField.text = score.ToString();
        return currentScore;

    }

    public int ResetScore()
    {
        score = 0;
        currentScore = score;
        scoreField.text = score.ToString();
        return score;
    }

    public bool isAutoPlayon()
    {
        return IsAutoPlayOn;
    }
}
