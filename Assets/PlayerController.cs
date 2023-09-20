using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    
    private float turnSpeed = 5.0f;
    private float horizontalInput;
    float fowardInput; // creo que es el load 0 o 1 al pulsar 
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        fowardInput = Input.GetAxis("Vertical");
        
        Debug.Log("speed " + speed);

      
        if(fowardInput > 0)
        {
            speed += 0.1f;
        }
        else if (fowardInput <= 0 && speed >= 0.5f) 
        {
            speed -= 0.5f;
        }
        else
        {
            speed = 0;
        }
        

        transform.Translate(speed * Time.deltaTime * Vector3.forward , Space.World);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
