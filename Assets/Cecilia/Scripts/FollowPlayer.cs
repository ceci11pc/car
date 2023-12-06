using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //get player's position
    public GameObject player;
    // set camera above player
    private Vector3 offset = new Vector3(0, 1f, 1f);
   

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
