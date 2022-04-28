using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    public float health;
    public float speed;

   

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public float edamage;

    private PlayerController player;
    private Animator anim1;
    private Animator anim;
    private GameObject pl;
    private ScoreManager sman;
    private Rigidbody2D rbe;

    private float stopTime;
    public float startStopTime;

    private void Start()
    {
        anim1 = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>();
        anim = player.GetComponent<Animator>();
        pl = GameObject.FindGameObjectWithTag("Player");
        sman = FindObjectOfType<ScoreManager>();
        rbe = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            sman.score += 1;
        }

        transform.position = Vector2.MoveTowards(transform.position, pl.transform.position, speed * Time.deltaTime);

        //rbe.velocity = new Vector2();
        /*float delta = Mathf.Sign(transform.position.x - pl.transform.position.x)
        Vector2 epos = transform.position;
        epos.x +=  delta * speed * Time.deltaTime;
        transform.position = epos;*/
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            if (timeBtwAttack <= 0)
            {
                anim1.SetBool("isAttack", true);
                timeBtwAttack = startTimeBtwAttack;
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
        else
        {
            anim1.SetBool("isAttack", false);
        }
    }

    
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void EnemyAtack()
    {
        anim.SetTrigger("isAttacked");
        player.health -= edamage;
    }

}
