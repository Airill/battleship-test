using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarrierScript : MonoBehaviour
{
    [SerializeField] GameObject carrier;
    [SerializeField] int maxSpeed;
    [SerializeField] int speed;
    [SerializeField] int rotateSpeed = 10;
    [SerializeField] GameObject[] planes;
    bool planesLaunched = false;


    Rigidbody m_Rigidbody; // переименовать


    // Start is called before the first frame update
    void Start() {
        m_Rigidbody = GetComponent<Rigidbody>();
        maxSpeed = 500;
        speed = 0;
    }


    // Update is called once per frame
    void FixedUpdate() {

        m_Rigidbody.velocity = transform.up * speed/500;
      
    }


    public void IncreaseSpeed() {

        if (speed < maxSpeed) {
            speed++;
        }
    }
   
    public void DecreaseSpeed() {
        if (speed > -maxSpeed) {
            speed--;
        }
        

    }

    public void RotateLeft() {

        //Rotate the sprite about the Y axis in the negative direction
        transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * rotateSpeed, Space.World);
    }

    public void RotateRight() {

        transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * rotateSpeed, Space.World);
    }

    public void LaunchPlanes() {
        if (!planesLaunched)
        {
            for (int i = 0; i < planes.Length; i++)
            {
                Debug.Log("Plane Launched");
                PlaneScript planeScript = planes[i].GetComponent<PlaneScript>();
                planeScript.Fly();

            }
            planesLaunched = true;
        }

    }

    
    
}
