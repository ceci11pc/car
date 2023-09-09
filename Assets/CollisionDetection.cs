using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public GameObject roadTyle;
   

    // Start is called before the first frame update
    void Start()
    {
       
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("collisionnnn 1");
        if (col.tag == "Player")
        {
            Debug.Log("collisionnnn 2");
            roadTyle.transform.Translate(Vector3.forward * 390);
        }
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
