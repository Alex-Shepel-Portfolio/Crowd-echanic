using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health { get; private set; } = 100f;
    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
