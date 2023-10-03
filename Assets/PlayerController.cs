using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Profiling.RawFrameDataView;

public class PlayerController : MonoBehaviour
{
    private float turnSpeed = 5.0f;
    private float horizontalInput;

    public float revs;
    public float fowardInput; 
    public float speed;

    public MeterScript speedMeter; //meter code
    public int currentSpeed; //meter code
    public int maxSpeed = 50; //meter code


    FMOD.Studio.EventInstance crash;
    FMOD.Studio.EventInstance bigcrash;

    private string[] collisionTag;
    private bool useParameter;
    private string parameterName;
    private float minCollisionVolume = 0.8f;
    private float maxCollisionVelocity = 5f;


    // Start is called before the first frame update
    void Start()
    {
        speedMeter.SetMaxSpeed(maxSpeed); //meter code
}

    // Update is called once per frame
    void Update()
    {
        currentSpeed = (int)speed;
        Debug.Log("currentSpeed    "  + currentSpeed);
        speedMeter.SetSpeed(currentSpeed); //meter code

        horizontalInput = Input.GetAxis("Horizontal");
        fowardInput = Input.GetAxis("Vertical");


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
    transform.Translate(Vector3.left * Time.deltaTime * turnSpeed * horizontalInput);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
            {
            float parameterValue = CalculateImpactVolume(collision.relativeVelocity.magnitude);
            if (parameterValue < minCollisionVolume)
            {
                Debug.Log("Choque chico  " + parameterValue);
                crash = FMODUnity.RuntimeManager.CreateInstance("event:/CRASH");
                FMODUnity.RuntimeManager.AttachInstanceToGameObject(crash, collision.gameObject.GetComponent<Transform>(), collision.gameObject.GetComponent<Rigidbody>());
                crash.start();
                crash.release();
                speed /= 2;
            }
            else if (parameterValue >= minCollisionVolume)
            {
                float currentZ = transform.position.z;
                Debug.Log("Choque mortal  "  + minCollisionVolume + parameterValue);
                bigcrash = FMODUnity.RuntimeManager.CreateInstance("event:/BIGCRASH");
                FMODUnity.RuntimeManager.AttachInstanceToGameObject(bigcrash, collision.gameObject.GetComponent<Transform>(), collision.gameObject.GetComponent<Rigidbody>());
                bigcrash.start();
                speed = 0;
            }

          
        }

    }

    private float CalculateImpactVolume(float speed)
    {
        float volume;
        volume = CubicEaseOut(speed);
        return volume;
    }

    private float CubicEaseOut(float velocity, float startingValue = 0, float changeInValue = 1)
    {
        return changeInValue * ((velocity = velocity / maxCollisionVelocity - 1) * velocity * velocity + 1) + startingValue;
    }

}
