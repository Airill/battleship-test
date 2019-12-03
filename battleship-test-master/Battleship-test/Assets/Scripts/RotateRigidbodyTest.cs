using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRigidbodyTest : MonoBehaviour
{
  
    public Transform carrierTransform;
    Rigidbody planeRigidbody;
    public float minSpeed;

    // Start is called before the first frame update
    void Start()
    {
        planeRigidbody = GetComponent<Rigidbody>();
        minSpeed = 500f;
    }

    void TakeOff() {
        planeRigidbody.velocity = transform.up * minSpeed / 500;
    }

    void Landing() {

    }

    // Update is called once per frame
    void Update()
    {
       Vector3 toCarrier = carrierTransform.position - transform.position;

        planeRigidbody.velocity = transform.forward * minSpeed / 500;



        toCarrier = carrierTransform.position - transform.position;
        transform.LookAt(toCarrier);
    }
}
