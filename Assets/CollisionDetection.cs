using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CollisionDetection : MonoBehaviour
{
    //offset para que las ruedas toquen justo la ruta y la posicion X sea random
    private float randomPositionX;
    private Vector3 offsetPosition;
    private Vector3 offsetAnimalPositionLeft;
    private Vector3 offsetAnimalPositionRight;
    public GameObject roadTyle;
    public GameObject[] animals ;
    public GameObject[] carObstacles;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("collisionnnn 1");
        if (col.tag == "Player")
        {
            randomPositionX = NextFloat(-3.14f, 2.77f);
            offsetPosition = new Vector3(randomPositionX, 0.25f, 0);

            offsetAnimalPositionLeft = new Vector3(NextFloat(-15f, 0f), -0.45f, 0);
            offsetAnimalPositionRight = new Vector3(NextFloat(0f, 15f), -0.45f, 0);

            roadTyle.transform.Translate(Vector3.forward * 390);
   
            Instantiate(GetRandomItem(carObstacles), transform.position +  offsetPosition, Quaternion.identity);
            
            GameObject animalLeft = (GameObject)Instantiate(GetRandomItem(animals), transform.position + offsetAnimalPositionLeft, Quaternion.identity);
            animalLeft.transform.Rotate(new Vector3(0, NextFloat(13f, 130f), 0));

            GameObject animalRight = (GameObject)Instantiate(GetRandomItem(animals), transform.position + offsetAnimalPositionRight, Quaternion.identity);
            animalRight.transform.Rotate(new Vector3(0, NextFloat(-13f, -130f), 0));


        }
    }
        // Update is called once per frame
        void Update()
    {
        
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
