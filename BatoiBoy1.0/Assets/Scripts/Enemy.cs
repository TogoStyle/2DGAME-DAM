using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isRunnig",true );
    }
    
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        {
            
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void Takedamage(int damage)
    {
        health -= damage;
        
    }
}
