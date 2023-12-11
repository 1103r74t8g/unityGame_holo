using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class room2Move : MonoBehaviour
{
    
    
    
    public Vector3 des;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = des;
            
            
        }
    }

}
