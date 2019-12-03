using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
   [SerializeField] GameObject carrier;//оставить чтото одно
    PlayerCarrierScript carrierPlayerScript;

    // Start is called before the first frame update
    void Start()
    {
        carrier = GameObject.Find("PlayerCarrier"); //оставить чтото одно
        carrierPlayerScript = carrier.GetComponent<PlayerCarrierScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            carrierPlayerScript.IncreaseSpeed();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            carrierPlayerScript.DecreaseSpeed();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            carrierPlayerScript.RotateRight();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            carrierPlayerScript.RotateLeft();
        }

        if (Input.GetKey(KeyCode.H))
        {
            carrierPlayerScript.LaunchPlanes();
        }
    }
}
