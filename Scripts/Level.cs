using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    /// <summary>
    /// What needs to be done in order for the game to proceed to the next level
    /// 1) Its need to be able to add blocks to the begining
    /// 2) It needs to be able to remove a block
    /// 3) It needs to be able to move on to the next level the moment the blocks reach zero
    /// </summary>


    //variables
    [SerializeField] int numberOfBlocks; // for debugging purposes as we can see how many blocks are present wehn we first start the game, and how many blocks are left when the next level loads
    int currentSceneIndex;


    private void Update()
    {
        if (numberOfBlocks == 0)
            LoadNextLevel();
    }


    // methods
    public int AddBlock()
    {
        numberOfBlocks++;
        return numberOfBlocks;
    }
    
    public int RemoveBlock()
    {
        numberOfBlocks--;
        return numberOfBlocks;
    }

    public void LoadNextLevel()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (numberOfBlocks == 0)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else { }
    }
}
