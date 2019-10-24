using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    GameSession gameSession;
    Ball ball;

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int life = gameSession.SetLife(gameSession.GetLife() - 1);
        if (life < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            ball.LockBallToPaddle();
        }
    }
}
