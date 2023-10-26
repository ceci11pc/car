using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AnimalHurt : MonoBehaviour
{

    private PlayerController player;


    FMOD.Studio.EventInstance animalhit;

    // Start is called before the first frame update
    void Start()
    {
        //ESTO ES SALVADOR. ENCUENTRO LA INSTANCIA DEL AUTO, CON SU SCORE ACTUAL Y TODO!!!!
        player = GameObject.Find("Player Car").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animalhit = FMODUnity.RuntimeManager.CreateInstance("event:/ANIMALHIT");
            animalhit.start();
            animalhit.release();
            player.ScoreUpdate();
        

            Debug.Log("YOUR SCOREEEE Animal hurt on trigger enter");
        }
    }


}
