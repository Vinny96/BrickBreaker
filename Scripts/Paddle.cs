using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    // variables
    [SerializeField] float cameraFullWidth;
    [SerializeField] float cameraFullHeight;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    float mousePosInUnitsX;
    float mousePosInUnitsY;
    float clampedXPos; // this variable will store the clamped xPosition of the mouse
    //vectors
    Vector2 PaddlePos;

    // state variables
    GameStatus stateOfGame;

    // Use this for initialization
    void Start()
    {
        PaddlePos = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        MovePaddle();
        GetMousePosXInUnits();
        GetMousePosYInUnits();
    }

    // methods
    private void GetMousePosXInUnits()
    {
        mousePosInUnitsX = (Input.mousePosition.x / Screen.width * cameraFullWidth);
        Debug.Log(mousePosInUnitsX);
    }

    private void GetMousePosYInUnits()
    {
        mousePosInUnitsY = (Input.mousePosition.y / Screen.height * cameraFullHeight);
        Debug.Log(mousePosInUnitsY);
    }

    private void MovePaddle()
    {
        mousePosInUnitsX = (Input.mousePosition.x / Screen.width * cameraFullWidth);
        clampedXPos = Mathf.Clamp(AutoPlayOnOrOff(), minX, maxX);
        PaddlePos = new Vector2(clampedXPos, transform.position.y);
        transform.position = PaddlePos;
    }

    private float AutoPlayOnOrOff()
    {
       if(FindObjectOfType<GameStatus>().isAutoPlayon())
       {
            return FindObjectOfType<Ball>().transform.position.x;
       }
        else
        {
            return mousePosInUnitsX = (Input.mousePosition.x / Screen.width * cameraFullWidth);
        }
    }
}


    // notes
    //  the Z propety value of the transform component kept reverting back to zero even though it was set at -4.45. 

    // how I solved the above issue is to set the background z property to a posiitive number higher than zero. This solved the issue so the paddle is still
    // going back to zero but since the background is behind the paddle as its z value is higher than zero, we can see the paddle. 
    
    // this is how we can check if the isAutoPlayOn turned on
    // if(findObjectOfType<GameStatus>().IsAutoPlayOn()
