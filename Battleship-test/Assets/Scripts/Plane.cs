using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{

   [SerializeField] int speed;
   [SerializeField] int minSpeed;
   [SerializeField] int maxSpeed;
   [SerializeField] float angularVelocity;
   [SerializeField] int acceleration;
   [SerializeField] float flyRadius;
    int rotateSpeed;
    Rigidbody planeRigidbody;
    Transform planeTransform;
    Transform carrierTransform;

   [SerializeField] GameObject carrier;
    Rigidbody carrierRigidbody;
    bool patrol = false;

    Vector3 toCarrier;

    float angle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        carrier = GameObject.Find("PlayerCarrier");
        planeRigidbody = GetComponent<Rigidbody>();
        carrierRigidbody = carrier.GetComponent<Rigidbody>();
        minSpeed = 400;
        flyRadius = 4f;
        rotateSpeed = 20;
        angularVelocity = 1f;

        carrierTransform = carrier.GetComponent<Transform>();

        Vector3 axis;
        carrierTransform.rotation.ToAngleAxis(out angle, out axis);
        takeoff();
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
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (!patrol)
        {
            
            angle += 0.4f;

        }
        


        if (dist > flyRadius + 0.05f)
        {
            patrol = true;
            angle += angularVelocity;
            //transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * rotateSpeed, Space.World);

        }
        if ((patrol) && (dist <= flyRadius - 0.05f))
        {
            // transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * rotateSpeed, Space.World);
            angle -= angularVelocity;
        }
       planeRigidbody.velocity = transform.up * minSpeed / 500;
        
    }
}
