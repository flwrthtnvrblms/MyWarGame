using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offcset;

    // Update is called once per frame
    void Update()
    {
        if (player != null){
            transform.position = player.position + offcset;
        }
    }
}
