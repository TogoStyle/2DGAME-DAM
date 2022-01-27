using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Character : MonoBehaviour
{

    public float Speed = 0.0f;
    public float lateralMovement = 4.0f;
    public float jumpMovement = 400.0f;

   
    
    public Transform groundCheck;
    private Animator animator;
    private Rigidbody2D rigidbody2d;
    public bool grounded = true;
    float movementButton = 0.0f; 
    
    public AudioClip salto;
    private AudioSource audioSource;
    
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    private Animator playerAnim;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator> ();
        rigidbody2d = GetComponent<Rigidbody2D> ();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        // grounded = Physics2D.Linecast(transform.position,
        //     groundCheck.position,
        //     LayerMask.GetMask("Ground"));
        //
        // if (grounded && Input.GetButtonDown("Jump"))
        // {
        //     rigidbody2d.AddForce(Vector2.up * jumpMovement);
        //     audioSource.Play();
        // }
        //
        // if (grounded)
        //     animator.SetTrigger("Grounded");
        // else
        //     animator.SetTrigger("Jump");
        // Speed = lateralMovement * Input.GetAxis("Horizontal");
        // transform.Translate(Vector2.right * Speed * Time.deltaTime);
        // animator.SetFloat("Speed", Mathf.Abs(Speed));
        // if (Speed < 0)
        //     transform.localScale = new Vector3(-5, 5, 5);
        // else
        //     transform.localScale = new Vector3(5, 5, 5);

    
        grounded = Physics2D.Linecast(transform.position,
            groundCheck.position,
            LayerMask.GetMask("Ground"));
        if (grounded)
            animator.SetTrigger("Grounded");
        else
            animator.SetTrigger("Jump");
        
        Speed = lateralMovement * movementButton;

        transform.Translate(Vector2.right * Speed * Time.deltaTime);
        
        animator.SetFloat("Speed", Mathf.Abs(Speed));
        
        if (Speed < 0)
            transform.localScale = new Vector3(-5, 5, 5);
        else
            transform.localScale = new Vector3(5, 5, 5);
        
       
    }

   


    void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("zoom"))
                GameObject.Find("MainVirtual").GetComponent<CinemachineVirtualCamera>().enabled = false;
        }
        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("zoom"))
                GameObject.Find("MainVirtual").GetComponent<CinemachineVirtualCamera>().enabled = true;
        }
        
        void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("mobilePlattform"))
        transform.SetParent (other.transform);
        }
        void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("mobilePlattform"))
        transform.SetParent (null);
        }
        
        public void Jump()
        {
            if (grounded)
                rigidbody2d.AddForce(Vector2.up * jumpMovement);
        }
        public void Move(float amount)
        {
            movementButton = amount;
        }
        
        

}
