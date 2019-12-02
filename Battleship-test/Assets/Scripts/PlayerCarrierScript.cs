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
    [SerializeField] int flyRadius;
    [SerializeField] int planesPerPlace = 5;
     bool planesLaunched = false;


    Rigidbody carrierRigidbody; // переименовать


    // Start is called before the first frame update
    void Start() {
        carrierRigidbody = GetComponent<Rigidbody>();
        maxSpeed = 500;
        speed = 0;
    }


    // Update is called once per frame
    void FixedUpdate() {

        carrierRigidbody.velocity = transform.forward * speed/500;
      
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
        transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * rotateSpeed, Space.World);
    }

    public void RotateRight() {

        transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotateSpeed, Space.World);
    }

    public void LaunchPlanes() {
        StartCoroutine(LaunchPlane());
    }

   public IEnumerator LaunchPlane() {
        if (!planesLaunched)
        {
            planesLaunched = true;
            for (int i = 0; i < planes.Length; i++)
            {
                Debug.Log("Plane Launched");
                PlanePlace planePlaceScript = planes[i].GetComponent<PlanePlace>();
                for (int j =1; j <= planesPerPlace; j++)
                {
                    planePlaceScript.Launch();
                    yield return new WaitForSeconds(1);
                }
                

            }

        }
    }
    
    
}
