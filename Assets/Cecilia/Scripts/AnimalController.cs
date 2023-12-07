using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{

    private GameObject car;
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("Player Car");

    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < car.transform.position.z)
        {
            Destroy(gameObject);    
        }
    }
}
