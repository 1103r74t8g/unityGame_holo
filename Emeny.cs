using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EmenyState
{
    idle,
    walk,
    attack,
    stagger
}

public class Emeny : MonoBehaviour
{
    public EmenyState currentState;
    public int health;
    public int baseAtack;
    public string emenyName;
    public float MoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
