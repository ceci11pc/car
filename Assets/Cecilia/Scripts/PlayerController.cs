using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

    public float revs;
    public float fowardInput;
    public float speed;

    public float positionZ;

    public MeterScript speedMeter; //meter code
    public int currentSpeed; //meter code
    public int maxSpeed = 50; //meter code
    public int score;
    public Score playerScore;
    public StaticVar staticVar;
    public GameObject menu;

    FMOD.Studio.EventInstance crash;
    FMOD.Studio.EventInstance bigcrash;
    FMOD.Studio.EventInstance scoreup;  

    private string[] collisionTag;
    private bool useParameter;
    private string parameterName;
    private float minCollisionVolume = 0.8f;
    private float maxCollisionVelocity = 5f;

    private float turnSpeed = 5.0f;
    private float horizontalInput;
    private float cancelInput;

    //0 = pause 1 = playing
    private int gameState;

    void Start()
    {
        score = 0;
        speedMeter.SetMaxSpeed(maxSpeed); //meter code
        playerScore.SetScore(score);
        staticVar = GetComponent<StaticVar>();
    }

    void Update()
    {
        currentSpeed = (int)speed;

        speedMeter.SetSpeed(currentSpeed); //meter code
        cancelInput = Input.GetAxis("Cancel");
     
        horizontalInput = Input.GetAxis("Horizontal");
        fowardInput = Input.GetAxis("Vertical");

        //if input is accelerating and speed not max speed and revs not max revs, speed and revs up
        if (fowardInput > 0 && speed < 50 && revs < 1)
        {
            speed += 0.1f;
            revs += 0.005f;
        }

        //if input is accelerating and speed not max speed and revs = max revs, speed and revs down
        else if (fowardInput > 0 && speed < 50 && revs >= 1)
        {
            speed -= 2f;
            revs = 0.6f;
        }

        //si esta acelerando y la speed llegó al max, se mantiene
        //if input is accelerating and speed is max speed , speed doesn't change
        else if (fowardInput > 0 && speed >= 50)
        {
            speed = 50;
        }

        //if input is not accelerating, and not stoppped, speed down
        else if (fowardInput <= 0 && speed >= 0.5f)
        {
            speed -= 0.5f;
            revs -= 0.1f;
        }
        //else, speed = 0
        else
        {
            speed = 0f;
            revs = 0;
        }

        //Pause state
        if (GameObject.Find("PauseMenuCanvas Variant(Clone)") && speed >= 0.5f )
        {
            speed -= 0.5f;
        }    
            transform.Translate(speed * Time.deltaTime * Vector3.forward, Space.World);

        if (transform.position.x < 4.5 && transform.position.x > - 4.5)
        {
            transform.Translate(Vector3.left * Time.deltaTime * turnSpeed * horizontalInput);
        }
        if (cancelInput == 1 && (GameObject.Find("PauseMenuCanvas Variant(Clone)") == false))
        {
            Instantiate(menu);

            //revisar solo destruye uno de cada)
            Destroy(GameObject.Find("Plane.014(Clone)"));
            Destroy(GameObject.Find("Plane.015(Clone)"));
            Destroy(GameObject.Find("Plane.030(Clone)"));
            Destroy(GameObject.Find("Plane.035(Clone)"));
        }

        positionZ = transform.position.z;

    }

    //different crash sound depending on crash magnitude
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
        {

            float parameterValue = CalculateImpactVolume(collision.relativeVelocity.magnitude);
            if (parameterValue < minCollisionVolume)
            {

                crash = FMODUnity.RuntimeManager.CreateInstance("event:/CRASH");
                FMODUnity.RuntimeManager.AttachInstanceToGameObject(crash, collision.gameObject.GetComponent<Transform>(), collision.gameObject.GetComponent<Rigidbody>());
                crash.start();
                crash.release();
                speed /= 2;
            }
            else if (parameterValue >= minCollisionVolume)
            {
                float currentZ = transform.position.z;
                
                bigcrash = FMODUnity.RuntimeManager.CreateInstance("event:/BIGCRASH");
                FMODUnity.RuntimeManager.AttachInstanceToGameObject(bigcrash, collision.gameObject.GetComponent<Transform>(), collision.gameObject.GetComponent<Rigidbody>());
                bigcrash.start();
                bigcrash.release();
                speed = 0;
                horizontalInput = 0f;
                fowardInput = 0f;             
            }
            Invoke("RestoreTransform", 2f);
        }


    }

    public void ScoreUpdate()
    {
        score++;
        
        staticVar.UpdateScore(score);

        Invoke("DelayScoreUpdate", 0.8f);
    }

    public void DelayScoreUpdate()

    {
        playerScore.SetScore(score);
        scoreup = FMODUnity.RuntimeManager.CreateInstance("event:/SCOREUP");
        scoreup.start();
        scoreup.release();
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

    public void RestoreTransform()
    {
        transform.position = new Vector3(0f, 2.2f, transform.position.z);

        transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
}