using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CollisionDetection : MonoBehaviour
{
    //when Player enters the trigger the road is translated, and obstacles (cars and animals are generated at random positions)
    private float randomPositionX;
    private Vector3 offsetPosition;
    private Vector3 offsetAnimalPositionLeft;
    private Vector3 offsetAnimalPositionRight;
    private Vector3 playerPosition;
    private GameObject car;
    private GameObject animalRight;
    private GameObject animalLeft;
    public GameObject roadTyle;
    public GameObject[] animals ;
    public GameObject[] carObstacles;


    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            randomPositionX = NextFloat(-3f, 2.77f);
            offsetPosition = new Vector3(randomPositionX, 0.7f, 0);

            offsetAnimalPositionLeft = new Vector3(NextFloat(-15f, 0f), -0.45f, 0);
            offsetAnimalPositionRight = new Vector3(NextFloat(0f, 15f), -0.45f, 0);

            roadTyle.transform.Translate(Vector3.forward * 390);
   
            car = Instantiate(GetRandomItem(carObstacles), transform.position +  offsetPosition, Quaternion.identity);
            
            animalLeft = Instantiate(GetRandomItem(animals), transform.position + offsetAnimalPositionLeft, Quaternion.identity);
            animalLeft.transform.Rotate(new Vector3(0, NextFloat(13f, 130f), 0));

            animalRight = Instantiate(GetRandomItem(animals), transform.position + offsetAnimalPositionRight, Quaternion.identity);
            animalRight.transform.Rotate(new Vector3(0, NextFloat(-13f, -130f), 0));


        }
    }
        // Update is called once per frame
        void Update()
    {
        playerPosition = GameObject.Find("Player Car").transform.position;

        if (car && car.transform.position.z < playerPosition.z)
        {
            Destroy(car);
        }


        //to check
        if (animalLeft && animalLeft.transform.position.z < playerPosition.z)
        {
            Destroy(animalLeft);
        }

        if (animalRight && animalRight.transform.position.z < playerPosition.z)
        {
            Destroy(animalRight);
        }
    }


    static float NextFloat(float min, float max)
    {
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }

    public GameObject GetRandomItem(GameObject[] arrayToRandomize)
    {
        int randomNum = Random.Range(0, arrayToRandomize.Length);
        print(randomNum);
        GameObject printRandom = arrayToRandomize[randomNum];
        print(printRandom);
        return printRandom;
    }




}
