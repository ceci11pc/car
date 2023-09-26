using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //para poder tener la posicion del auto
    public GameObject player;
    // para que la camara este arriba y no justo en el medio del auto
    private Vector3 offset = new Vector3(0, 1f, 1f);
   

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

    }
}
