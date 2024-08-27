using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    public float CameraMoveSpeed;
    void Update()
    {
        //Camera Move
        Player playerLogic = player.GetComponent<Player>();

        if (playerLogic.h == 1) 
            transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(0.7f, 0 , -1),CameraMoveSpeed);

        else if (playerLogic.h == -1) 
            transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(-0.7f, 0 , -1), CameraMoveSpeed);
        
        if (playerLogic.v == 1) 
            transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(0, 0.5f , -1), CameraMoveSpeed);

        else if (playerLogic.v == -1) 
            transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(0, -0.5f , -1), CameraMoveSpeed);

        else {
            transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(0, 0 , -1), 0.01f);
        }
    }
}
