using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MaterialChecker : MonoBehaviour
{
    public float distance = 1f;

    FMOD.Studio.EventInstance tyres;
    FMOD.Studio.PARAMETER_ID materialId;
    FMOD.Studio.PARAMETER_ID directionId;

    private float material;
    private float direction;
    private Vector3 checkOffset = Vector3.up * 0.1f;
    private Vector3 directionDown = Vector3.down;

    void Start()
    {    
        direction = gameObject.tag == "Left" ? 0f : 1f;
        
        tyres = FMODUnity.RuntimeManager.CreateInstance("event:/TYRES");

        FMOD.Studio.EventDescription tyresEventDescription;
        tyres.getDescription(out tyresEventDescription);

        FMOD.Studio.PARAMETER_DESCRIPTION materialParameterDescription;
        FMOD.Studio.PARAMETER_DESCRIPTION directionParameterDescription;
        tyresEventDescription.getParameterDescriptionByName("Material", out materialParameterDescription);
        tyresEventDescription.getParameterDescriptionByName("Direction", out directionParameterDescription);
        materialId = materialParameterDescription.id;
        directionId = directionParameterDescription.id;

        tyres.start();
    }

    // Update is called once per frame
    void Update()
    { 
        MaterialCheck();
        tyres.setParameterByID(materialId, material);
        tyres.setParameterByID(directionId, direction);
    }

    void OnDestroy()
    {
        tyres.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        tyres.release();
    }

    void MaterialCheck()
    {
        Ray theRay = new Ray(transform.position + checkOffset, directionDown);
        Debug.DrawRay(transform.position + checkOffset, transform.TransformDirection(directionDown * distance), Color.blue);

        if (Physics.Raycast(theRay, out RaycastHit hit, distance))
        { 
            if (hit.collider)
            {
                if (hit.collider.tag == "Road")
                    material = 2f;

                else if (hit.collider.tag == "Terrain")
                    material = 1f;
            }
        }
    }


}
