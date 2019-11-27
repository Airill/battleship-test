using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{

   [SerializeField] int speed;
   [SerializeField] int minSpeed;
   [SerializeField] int maxSpeed;
   [SerializeField] int angularVelocity;
   [SerializeField] int acceleration;
                    Rigidbody planeRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        planeRigidbody = GetComponent<Rigidbody>();
        minSpeed = 800;
        takeoff();
    }

    private void takeoff() {
        planeRigidbody.velocity = transform.up * minSpeed / 500;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
