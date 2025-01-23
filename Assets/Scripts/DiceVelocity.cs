using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DiceNumberDetector : MonoBehaviour
{
    static Rigidbody rb;
    public static Vector3 diceVelocity;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        diceVelocity = rb.linearVelocity;    
    }

}
