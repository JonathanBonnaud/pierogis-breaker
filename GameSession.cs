using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int life = 3;
    [SerializeField] GameObject[] hearts;
    [SerializeField] bool autoplay = false;

    //state variables
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int gameSessionCount = FindObjectsOfType<GameSession>().Length;
        if (gameSessionCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    internal bool IsAutoplayEnabled()
    {
        return autoplay;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        ShowLife();
    }

    private void ShowLife()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < life)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlock;
        scoreText.text = currentScore.ToString();
    }

    public void DestroyItself()
    {
        Destroy(gameObject);
    }

    public int GetLife()
    {
        return life;
    }

    public int SetLife(int newLife)
    {
        life = newLife;
        return life;
    }
}
