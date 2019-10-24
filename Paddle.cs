using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minPosX = 1f;
    [SerializeField] float maxPosX = 15f;

    // Cached variables
    GameSession myGameStatus;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        myGameStatus = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y)
        {
            x = Mathf.Clamp(GetXPos(), minPosX, maxPosX)
        };
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (myGameStatus.IsAutoplayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
