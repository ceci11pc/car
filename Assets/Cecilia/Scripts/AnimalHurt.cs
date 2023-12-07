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
        player = GameObject.Find("Player Car").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animalhit = FMODUnity.RuntimeManager.CreateInstance("event:/ANIMALHIT");
            animalhit.start();
            animalhit.release();
            player.ScoreUpdate();
        }
    }
}
