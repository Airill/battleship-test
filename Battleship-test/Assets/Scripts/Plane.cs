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
   [SerializeField] float sqrRadius;
    int rotateSpeed;
    Rigidbody planeRigidbody;
    Transform planeTransform;
    Transform carrierTransform;

   [SerializeField] GameObject carrier;
    Rigidbody carrierRigidbody;
    bool patrol = false;

    Vector3 toCarrier;


    // Start is called before the first frame update
    void Start()
    {
        planeRigidbody = GetComponent<Rigidbody>();
        carrierRigidbody = carrier.GetComponent<Rigidbody>();
        minSpeed = 500;
        takeoff();
        sqrRadius = 4f;
        rotateSpeed = 100;

        carrierTransform = carrier.GetComponent<Transform>();

    }

    private void takeoff() {
        planeRigidbody.velocity = transform.up * minSpeed / 500;
    }

    // Update is called once per frame
    void Update()
    {

        //  Debug.Log(toCarrier.sqrMagnitude);
        // toCarrier = carrierTransform.position - transform.position;
        
        float dist = Vector3.Distance(carrierTransform.position, transform.position);
        Debug.Log(carrierTransform.position);
        Debug.Log(transform.position);
        Debug.Log(dist);
        if (dist > sqrRadius)
        {
            patrol = true;
               // planeRigidbody.AddForce(toCarrier);
               transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * rotateSpeed, Space.World);
       
        }
        if ((patrol) && (dist <= sqrRadius))
        {
                transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * rotateSpeed, Space.World);
                 // var velocity = planeRigidbody.velocity;
                //  Vector3.OrthoNormalize(ref toCarrier, ref velocity);
                // planeRigidbody.AddForce(velocity);
        }
       planeRigidbody.velocity = transform.up * minSpeed / 500;
        
    }
}
