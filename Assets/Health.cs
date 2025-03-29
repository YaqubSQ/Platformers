using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    private int health;
    public PlayerInterface playerInterface;
    private void Start()
    {
        health = maxHealth; 
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (playerInterface != null)
        {
            playerInterface.UpdateHealthDisplay(health);
        }

        if (health <= 0)
        {
            this.transform.position = Vector2.zero;
            health = maxHealth;
            playerInterface.UpdateHealthDisplay(health);
        }
    }
}

