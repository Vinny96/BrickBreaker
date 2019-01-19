using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    // variables
    [SerializeField] Paddle gamePaddle;
    [SerializeField] float launchX;
    [SerializeField] float launchY;

    // vectors
    Vector2 gamePaddlePos;
    Vector2 ballPos;
    Vector2 paddleToBallVector;
    Vector2 velocityTweak;
    float randomFactor;


    //cached components
    Rigidbody2D myRigidBody2D;
    
    
    
    // cached references
    [SerializeField] AudioClip []gameAudioClips;
    AudioClip clip;
    AudioSource gameAudio;

    // debuggging variables
    [SerializeField] Vector2 ballsVelocity;
    
    
   
    // state
    bool gameHasStarted;

    
    
    // Use this for initialization
	void Start ()
    {
        gameHasStarted = false;
        ballPos = new Vector2(transform.position.x, transform.position.y);
        gamePaddlePos = new Vector2(gamePaddle.transform.position.x, gamePaddle.transform.position.y);
        paddleToBallVector = ballPos - gamePaddlePos;
        gameAudio = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        ballsVelocity = myRigidBody2D.velocity;

        if (gameHasStarted == false)
        {
            LockBallToPaddle();
            LaunchBall();
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetRandomAudioToPlay();
        ChangeVelocity();
    }

    private void LockBallToPaddle()
    {
        gamePaddlePos = new Vector2(gamePaddle.transform.position.x, gamePaddle.transform.position.y);
        transform.position = gamePaddlePos + paddleToBallVector;
        
    }

    private void LaunchBall()
    {
        if(Input.GetMouseButtonDown(0))
        {
            gameHasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(launchX, launchY);
        }
        
    }

    private void GetRandomAudioToPlay()
    {
        clip = gameAudioClips[Random.Range(0, gameAudioClips.Length)];
        gameAudio.PlayOneShot(clip);
        
    }

    private void ChangeVelocity()
    {
        randomFactor = Random.Range(-0.33f, 0.63f);
        velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        myRigidBody2D.velocity += velocityTweak;

    }

   
    
        

    /// How I solved the problem of the ball locking to the paddle 
    /// Remember that we only need to retrieve the differential between the ball and the paddle once 
    /// so we retrieve the position of the ball once and initalize it in start method method 
    /// we retrieve the position of the gamePaddle as the following code will need a value to work with, to calculate the differential
    /// we then initialize paddleToBallVector as ballPos - gamePaddlePos
    /// in the Lock method we state again what gamePaddlePos is as now it is going to retreieve the position of the gamePaddle every frame compared to just once in the start method
    /// we then tell unity that the position of the ball is gamePaddlePos + paddleToBallVector as the gamePaddle is going to be constantly moving and we want the Ball to move along withh it .
    
    // we need to create code that will allow an autoplay feature. 



   


}





