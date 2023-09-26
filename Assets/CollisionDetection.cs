using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    //offset para que las ruedas toquen justo la ruta y la posicion X sea random
    private float randomPositionX;
    private Vector3 offsetPosition;

    public GameObject roadTyle;
   
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
            offsetPosition = new Vector3(randomPositionX, 0.45f, 0);

            roadTyle.transform.Translate(Vector3.forward * 390);
   
            Instantiate(GetRandomObstacleCar(carObstacles), transform.position +  offsetPosition, Quaternion.identity);
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

    public GameObject GetRandomObstacleCar(GameObject[] arrayToRandomize)
    {
        int randomNum = Random.Range(0, arrayToRandomize.Length);
        print(randomNum);
        GameObject printRandom = arrayToRandomize[randomNum];
        print(printRandom);
        return printRandom;
    }


}
