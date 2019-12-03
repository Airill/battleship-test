using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePlace : MonoBehaviour
{

    Vector3 launchPlace;
    Vector3 launchAngle;
    [SerializeField] GameObject planePrefab;
    Plane planeScript;


    [SerializeField] int planeMinSpeed = 600;
    [SerializeField] int planeMaxSpeed = 1000;
    [SerializeField] float planeAngularVelocity = 1f; // оставить одно
    [SerializeField] int planeRotateSpeed = 20; //оставить одно
    [SerializeField] int planeAcceleration = 25;
    [SerializeField] float planeFlyRadius = 4f;
    [SerializeField] float planeLifeTime = 30f;
    [SerializeField] float planeSpaceBetweenPlanes = 2f;

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
        planeScript.spaceBetweenPlanes = planeSpaceBetweenPlanes;

        Debug.Log("I launched a plane!");
    }
}
