using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{

   public int speed; //serialize
   public int minSpeed;
   public int maxSpeed;
   public float angularVelocity;
   public int acceleration;
   public float flyRadius;
   public float lifeTime;
   public int rotateSpeed;
    public float spaceBetweenPlanes;
          bool timeToLand = false;
          float takeOffTime;
          float dist;

    Rigidbody planeRigidbody;
    Transform planeTransform;
    Transform carrierTransform;

    Vector3 dir;
    GameObject closestPlane;
    GameObject carrier;
    Rigidbody carrierRigidbody;
    bool patrol = false;

    Vector3 toCarrier;

    float angle = 0f;
    Vector3 axis;

    float dR = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        carrier = GameObject.Find("PlayerCarrier"); // заменить на тег
        GameObject[] planes = GameObject.FindGameObjectsWithTag("Plane");

        closestPlane = FindClosestPlane(planes);
        Debug.Log(closestPlane);

        

        planeRigidbody = GetComponent<Rigidbody>();
        carrierRigidbody = carrier.GetComponent<Rigidbody>();

        speed = (minSpeed + maxSpeed) / 2;


        takeOffTime = Time.time;
        

        carrierTransform = carrier.GetComponent<Transform>();
        

        carrierTransform.rotation.ToAngleAxis(out angle, out axis);
        TakeOff();
    }

    void TakeOff() {
        planeRigidbody.velocity = transform.up * minSpeed / 500;
    }

    void Landing() {
        toCarrier = carrierTransform.position - transform.position;
        transform.LookAt(toCarrier);
        Debug.Log(toCarrier);
        if (dist < carrier.transform.localScale.x)
        {
            Destroy(this.gameObject);
        }
    }

    void IncreaseSpeed()
    {
        if (speed + acceleration <= maxSpeed)
        {
            speed += acceleration;
        }
        else
        {
            speed = maxSpeed;
        }
    }

    void DecreaseSpeed()
    {
        if (speed - acceleration >= minSpeed)
        {
            speed -= acceleration;
        }
        else
        {
            speed = minSpeed;
        }
    }

    GameObject FindClosestPlane (GameObject[] planes)
    {
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        for (int i = 0; i < planes.Length; i++)
        {
            Vector3 diff = planes[i].transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if ((curDistance < distance) && (planes[i] != this.gameObject))
            {
                closest = planes[i];
                distance = curDistance;
            }
        }
        Debug.Log(distance);
        return closest;
    }
    // Update is called once per frame 
    void Update()
    {

        if ((closestPlane != null) && (Vector3.Distance(transform.position, closestPlane.transform.position) < spaceBetweenPlanes-0.5f))
        {
            DecreaseSpeed();
        }
        if ((closestPlane != null) && (Vector3.Distance(transform.position, closestPlane.transform.position) > spaceBetweenPlanes+0.5f))
        {
            IncreaseSpeed();
        }

        dist = Vector3.Distance(transform.position, carrierTransform.position);

        if (Time.time >= takeOffTime + lifeTime)
        {
            timeToLand = true;
        }

        if (!timeToLand) {
            
            if (!patrol)
            {
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
                angle += 0.5f;
            }
        
            if ((patrol) && (dist > flyRadius + dR))
            {


                transform.rotation.ToAngleAxis(out angle, out axis);
            angle += angularVelocity;
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotateSpeed, Space.World);

            }
            if ((patrol) && (dist <= flyRadius - dR))
            {
            transform.rotation.ToAngleAxis(out angle, out axis);
            angle -= angularVelocity;
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * rotateSpeed, Space.World);

            }
            if ((dist < flyRadius + dR) && (dist > flyRadius - dR))
            {

                toCarrier = carrierTransform.position - transform.position;
                dir = Vector3.Cross(new Vector3(transform.position.x, -1, transform.position.z), toCarrier);

                transform.LookAt(new Vector3(dir.x, 0, dir.z) + transform.position);

                if (!patrol)
                {
                    patrol = true;
                    Debug.Log("patrol = true");
                }
            }
        }
        else
        {
            Landing();
        }


       planeRigidbody.velocity = transform.forward * speed / 500;
        
    }
}
