using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public bool pursuitof = false;
    GameObject playerObj;
    PlayerController player;
    Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<PlayerController>();
        playerTransform = playerObj.transform;
        
    }

    void LateUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        if (pursuitof)
        {
            transform.position = new Vector3(playerTransform.position.x,
                                             transform.position.y,
                                             transform.position.z);
        }
    }
}
