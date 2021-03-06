﻿using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float health = 100;

    public int enemyWorth = 50;

    void Start()
    {
        speed = startSpeed;
        health *= (float)(1 + 0.1f * PlayerStats.Rounds);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        PlayerStats.Money += enemyWorth;

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

}
