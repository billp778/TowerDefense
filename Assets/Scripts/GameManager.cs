﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool GameIsOver = false;

    public GameObject gameOverUI;

    void Start()
    {
        GameIsOver = false;
    }

    void Update()
    {

        if (GameIsOver)
        {
            return;
        }

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        //lives vid 10 marks~
        GameIsOver = true;

        gameOverUI.SetActive(true);
    }
}
