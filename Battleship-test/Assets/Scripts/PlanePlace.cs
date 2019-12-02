using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePlace : MonoBehaviour
{

    Vector3 launchPlace;
    Vector3 launchAngle;
    [SerializeField] GameObject planePrefab;
    Plane planeScript;


    public int planeMinSpeed = 500;
    public int planeMaxSpeed = 1000;
    public float planeAngularVelocity = 1f; // оставить одно
    public int planeRotateSpeed = 20; //оставить одно
    public int planeAcceleration = 50;
    public float planeFlyRadius = 4f;
    public float planeLifeTime = 30f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch() {
        launchPlace = transform.position;

        GameObject plane = Instantiate(planePrefab, launchPlace, Quaternion.identity);
        plane.transform.rotation = transform.rotation;
        planeScript = plane.GetComponent<Plane>();

        planeScript.minSpeed = planeMinSpeed;
        planeScript.maxSpeed = planeMaxSpeed;
        planeScript.angularVelocity = planeAngularVelocity;
        planeScript.rotateSpeed = planeRotateSpeed;
        planeScript.acceleration = planeAcceleration;
        planeScript.flyRadius = planeFlyRadius;
        planeScript.lifeTime = planeLifeTime;

        Debug.Log("I launched a plane!");
    }
}
