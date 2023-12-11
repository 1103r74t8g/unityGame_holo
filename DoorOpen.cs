using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class DoorOpen : MonoBehaviour
{
    private Animator animator;
    public bool Open = false;

    public Vector3 des;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Open", Open);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Open = true;
            if (animator != null)
            {
                animator.SetBool("Open", Open);
            }
            

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Open = false;
    }
    
}
