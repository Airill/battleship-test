using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarrierScript : MonoBehaviour
{
    [SerializeField] GameObject carrier;
    [SerializeField] int maxSpeed;
    [SerializeField] int speed;
    float angle;
    [SerializeField] float angularVelocity = 1f;
    [SerializeField] GameObject[] planes;

    [SerializeField] int planesPerPlace = 5;
     bool planesLaunched = false;
    Vector3 axis;
    float speedMultiplier = 0.002f;

    Rigidbody carrierRigidbody; // переименовать


    // Start is called before the first frame update
    void Start() {
        carrierRigidbody = GetComponent<Rigidbody>();

        speed = 0;
       // transform.rotation.ToAngleAxis(out angle, out axis);

    }


    // Update is called once per frame
    void FixedUpdate() {

        // carrierRigidbody.velocity = transform.forward * speed/500;
        transform.Translate(Vector3.forward * speed * speedMultiplier * Time.fixedDeltaTime);

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

        transform.Rotate(new Vector3(0, -1, 0) * Time.fixedDeltaTime * angularVelocity, Space.World);
        angle -= angularVelocity;
      //  transform.Rotate(0, Time.deltaTime * clockwise, 0);
    }

    public void RotateRight() {

        transform.Rotate(new Vector3(0, 1, 0) * Time.fixedDeltaTime * angularVelocity, Space.World);
        angle += angularVelocity;
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
