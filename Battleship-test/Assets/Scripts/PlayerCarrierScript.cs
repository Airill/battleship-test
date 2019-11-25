using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarrierScript : MonoBehaviour
{
    public GameObject carrier;
    public int maxSpeed;
    public int speed;
    public int rotateSpeed = 10;


    Rigidbody m_Rigidbody; // переименовать


    // Start is called before the first frame update
    void Start() {
        m_Rigidbody = GetComponent<Rigidbody>();
        maxSpeed = 500;
        speed = 0;
    }


    // Update is called once per frame
    void Update() {

        m_Rigidbody.velocity = transform.up * speed/500;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            IncreaseSpeed();            
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            DecreaseSpeed();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            RotateRight();            
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            RotateLeft();
        }
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

    }

    
}
