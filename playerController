using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{

    public Transform target;
    public Transform[] enemies;
    private bool isMoving;

    private bool canMove;
    public float distance;
    private Animator animator;
    private Renderer characterRenderer;
    public float speed;
    private Rigidbody2D rb;
    private Vector3 change;


    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy").Select(e => e.transform).ToArray();
        rb = GetComponent<Rigidbody2D>();
        characterRenderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
        canMove = true;
    }
    void CheckDistance()
    {
        if (Vector3.Distance(FindNearestEnemy().position, transform.position) <= distance)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }
    }
    void FixedUpdate()
    {
        CheckDistance();
        if (canMove == true)
        {
            
            change = Vector3.zero;
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");

            if (change != Vector3.zero)
            {
                isMoving = true;
                MoveCharacter();
                animator.SetFloat("moveX", change.x);
                animator.SetFloat("moveY", change.y);
            }
            else
            {
                isMoving = false;
            }
            
        }
        if(canMove == false)
        {
            FaceToEnemy();
            isMoving = false;
        }

        animator.SetBool("isMoving", isMoving);
        animator.SetBool("canMove", canMove);
    }
    void MoveCharacter()
    {
        
         rb.MovePosition(transform.position + change.normalized * speed * Time.fixedDeltaTime );

    }
    void FaceToEnemy()
    {
        if (enemies.Length > 0)
        {
            Transform nearestEnemy = FindNearestEnemy();

            Vector3 directionToEnemy = (nearestEnemy.position - transform.position).normalized;
            animator.SetFloat("faceX", directionToEnemy.x);
            animator.SetFloat("faceY", directionToEnemy.y);
            if (directionToEnemy.y < 0)
            {
                characterRenderer.sortingOrder--;

            }
        }
    }
    Transform FindNearestEnemy()
    {
        Transform nearestEnemy = null;
        float minDistance = float.MaxValue;

        foreach (Transform enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(enemy.position, transform.position);
            if (distanceToEnemy < minDistance)
            {
                minDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }
}
