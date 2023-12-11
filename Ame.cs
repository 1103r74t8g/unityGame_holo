using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ame : Emeny, Interactable
{
    public Transform target;
    public float Chase;
    
    public float Attack;
    public Transform HomePosition;
    

    private bool isMoving;
    private Animator animator;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    public void Interact()
    {
        Debug.Log("hoiiii");
    }
    void Start()
    {
        currentState = EmenyState.idle;
        rb = GetComponent<Rigidbody2D>();
        
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
        animator.SetBool("isMoving", isMoving);
    }

    void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= Chase && Vector3.Distance(target.position, transform.position) > Attack)
        {
            
            isMoving = true;
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, MoveSpeed * Time.deltaTime);
            changeAnimation(temp - transform.position);
            rb.MovePosition(temp);
                
        }
        else
        {
            isMoving = false;
        }
        
        if (Vector3.Distance(target.position, transform.position) <= Attack)
        {
            isMoving = false;
            

        }
        
    }
    
    private void MoveFloat(Vector2 move)
    {
        animator.SetFloat("moveX", move.x);
        animator.SetFloat("moveY", move.y);
    }
    private void changeAnimation(Vector2 direction)
    {
        if(Mathf.Abs(direction.x)> Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                MoveFloat(Vector2.right);
            }
            else
            {
                MoveFloat(Vector2.left);
            }
        }
        if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                MoveFloat(Vector2.up);
            }
            else
            {
                MoveFloat(Vector2.down);
            }
        }
    }
}
