using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {



    //cached references
    [SerializeField] AudioClip clipToPlay;
    [SerializeField] GameObject blocksVisualEffects;
    [SerializeField] Sprite[] blockSpritesArray;
    Level gameLevel;
    GameStatus gameState;


    //debugging variables that have been serialized
    [SerializeField] int maxHits;
    [SerializeField] int numberOfTimesHit;



    // cached components
    Sprite spriteToDisplay;
    


    //debugging variables
     int blockSpriteArrayIndex;
  

    // Use this for initialization
	void Start ()
    {
        gameLevel = FindObjectOfType<Level>();
        gameState = FindObjectOfType<GameStatus>();
        numberOfTimesHit = 0;

        if (tag == "Breakable")
        {
            gameLevel.AddBlock();
        }

        
        
	}
	
	// Update is called once per frame
	void Update ()
    {
      
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(clipToPlay, Camera.main.transform.position);
        numberOfTimesHit++;
        if(tag == "Breakable" && numberOfTimesHit >= maxHits)
        {
            DestroyBlock();
        }
        else if (tag == "Breakable")
        {
            DisplayNextBlockSprite();
        }
        else { }
       
    }

    private void DestroyBlock()
    {
        TriggerBlockVFX();
        Destroy(gameObject);
        gameState.IncreaseScore();
        gameLevel.RemoveBlock();
    }

    private void TriggerBlockVFX()
    {
        GameObject blockSparkles = Instantiate(blocksVisualEffects, transform.position, transform.rotation);
        Destroy(blockSparkles, 1.0f);
    }

    private void DisplayNextBlockSprite()
    {
        blockSpriteArrayIndex = numberOfTimesHit - 1;
        GetComponent<SpriteRenderer>().sprite = blockSpritesArray[blockSpriteArrayIndex];     
    }

  


    // now what is going to be done is that every time a break gets destroyed an audio clip will play 
    /// what playclipatpoint does is it instantiates an audiosource in our scene and then disposes of it once the clip has finished playing. If you look
    /// youll notice that it creates a oneshot audio gameobject everytime it collides with the gameobject in quetion. 
    /// blocks are not displaying properly figure out why this is the case. 
}


