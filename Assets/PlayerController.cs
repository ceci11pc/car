using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    
    private float turnSpeed = 5.0f;
    private float horizontalInput;
    public float revs;
    public float fowardInput; // creo que es el load 0 o 1 al pulsar 
    public float speed;
    //public float load;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        fowardInput = Input.GetAxis("Vertical");
        //load = fowardInput > 0 ? 1 : 0;


        //si esta acelerando y la speed no llegó al max, y revs no llegó al max sube la speed y revs
        if(fowardInput > 0 && speed < 50 && revs < 1)
        {
            speed += 0.1f;
            revs += 0.005f;
        }

        //si esta acelerando y la speed no llegó al max, y revs sí llegó al max baja la speed y revs
        else if (fowardInput > 0 && speed < 50 && revs >= 1)
        {
            speed -= 2f;
            revs = 0.6f;
        }

        //si esta acelerando y la speed llegó al max, se mantiene
        else if (fowardInput > 0 && speed >= 50)
        {
            speed = 50;
        }
        //si no está acelerando y no está frenado, bajá la speed
        else if (fowardInput <= 0 && speed >= 0.5f) 
        {
            speed -= 0.5f;
            revs -= 0.1f;
        }
        //sino, la speed es 0
         else
        {
        speed = 0f;
         revs = 0;
        }






    transform.Translate(speed * Time.deltaTime * Vector3.forward , Space.World);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
