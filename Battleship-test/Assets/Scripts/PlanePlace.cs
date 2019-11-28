using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePlace : MonoBehaviour
{

    Vector3 launchPlace;
    Vector3 launchAngle;
    [SerializeField] GameObject planePrefab;

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
      //  launchAngle = new Vector3 (0, 0, transform.rotation.z);
        GameObject plane = Instantiate(planePrefab, launchPlace, Quaternion.identity) as GameObject;
        plane.transform.rotation = transform.rotation;
        //plane.carrier
        Debug.Log("I fly!");
    }
}
