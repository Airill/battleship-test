using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    //Смещение камеры для центрации игрока по оси Х
    public float offsetX = -5;
    //Смещение камеры для центрации игрока по оси Z
    public float offsetZ = -10;
    //Максимальная дистанция отдаления камеры от игрока.
    public float maximumDistance = 2;
    public float playerVelocity = 10;

    public float positionY = 20;

    private float movementX;
    private float movementZ;
    public Camera followedCamera;

    // Update вызывается один раз за фрэйм
    void Update() {
        movementX = ((player.transform.position.x + offsetX - this.transform.position.x)) / maximumDistance;
        movementZ = ((player.transform.position.z + offsetZ - this.transform.position.z)) / maximumDistance;
        this.transform.position += new Vector3((movementX * playerVelocity * Time.deltaTime), 0, (movementZ * playerVelocity * Time.deltaTime));
        //rts/bird view
        if (Input.GetKeyUp("p"))
        {
            offsetZ = -15;
            offsetX = 0;
            Vector3 temp = followedCamera.transform.position;
            temp.y = 20;
            followedCamera.transform.position = temp;
        }
        //rts/rpg
        if (Input.GetKeyUp("o"))
        {
            offsetZ = -20;
            offsetX = -2;
            Vector3 temp1 = followedCamera.transform.position;
            temp1.y = 25;
            followedCamera.transform.position = temp1;
        }
        //Diablo style
        if (Input.GetKeyUp("i"))
        {
            offsetZ = -10;
            offsetX = 0;
            Vector3 temp1 = followedCamera.transform.position;
            temp1.y = 15;
            followedCamera.transform.position = temp1;
        }
    }
}
 
