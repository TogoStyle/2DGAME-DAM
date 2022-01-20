using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int currentHealth;
    public float speed;
    public Animator animator;
    public int maxHealth = 20;

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isRunnig",true );

        currentHealth = maxHealth;
    }
    
    void Update()
    {
        
            transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void Takedamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            // Destroy(gameObject);
            Die();
        }
        
    }
    public void Die()
    {
         // animator.SetBool("isDead", true);
        //
        // GetComponent<Collider2D>().enabled = false;
        // this.enabled = false;
        // // Instantiate(deathEffect, transform.position, Quaternion.identity);
         Destroy(gameObject);
    }
    
}
