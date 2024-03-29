﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float healthMax = 100;
    public float health;
    public int worth = 50;

    public GameObject deathEffect;

    private void Start()
    {
        speed = startSpeed;
        health = healthMax;
    }

    public void TakeDamage(float amaunt)
    {
        health -= amaunt;
        if (health <= 0)
        {
            Die();            
        }
    }

    public void Slow (float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
        PlayerStats.Money += worth;
        PlayerStats.KillCounter++;

    }
}
