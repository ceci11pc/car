using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class OnHover : MonoBehaviour, IPointerEnterHandler
{

    public FMODUnity.EventReference Event;
    public void PlayOneShot()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(Event, gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void OnPointerEnter(PointerEventData eventData)

    {
        
        PlayOneShot();
    }
}
