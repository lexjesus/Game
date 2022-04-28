using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public Enemy enemy;
    private Spawner spawner;
    void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        Instantiate(enemy, transform.position, transform.rotation);
        enemy.health = spawner.enemyHealth;
        enemy.edamage = spawner.enemyDamage;
    }

    
    
}
