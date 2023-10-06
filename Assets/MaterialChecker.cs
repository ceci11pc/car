using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MaterialChecker : MonoBehaviour
{
    FMOD.Studio.EventInstance tyres;
    FMOD.Studio.PARAMETER_ID materialId;
    FMOD.Studio.PARAMETER_ID directionId;
    public float distance = 1f;
    private float Material;
    private float Direction;
    private Vector3 checkOffset = Vector3.up * 0.1f;
    private Vector3 direction = Vector3.down;

    

    // Start is called before the first frame update
    void Start()
    {
        
        Direction = gameObject.tag == "Left" ? 0f : 1f;
        
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
        tyres.setParameterByID(materialId, Material);
        tyres.setParameterByID(directionId, Direction);
        Debug.Log("material  " + Material );
    }

    void OnDestroy()
    {
        tyres.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        tyres.release();
    }

    void MaterialCheck()
    {
        Ray theRay = new Ray(transform.position + checkOffset, direction);
        Debug.DrawRay(transform.position + checkOffset, transform.TransformDirection(direction * distance), Color.blue);


        if (Physics.Raycast(theRay, out RaycastHit hit, distance))
        {
            
            if (hit.collider)
            {
                if (hit.collider.tag == "Road")

                    Material = 2f;
                else if (hit.collider.tag == "Terrain")

                    Material = 1f;
                // else

                // Material = 0f;
            }

        }
    }


}
