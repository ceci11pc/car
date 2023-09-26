using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MaterialChecker : MonoBehaviour
{
    public float distance = 1f;
    private float Material;
    private Vector3 checkOffset = Vector3.up * 0.1f;
    private Vector3 direction = Vector3.down;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MaterialCheck();
    }

    void MaterialCheck()
    {
        Ray theRay = new Ray(transform.position + checkOffset, direction);
        Debug.DrawRay(transform.position + checkOffset, transform.TransformDirection(direction * distance), Color.blue);


        if (Physics.Raycast(theRay, out RaycastHit hit, distance))
        {
            Debug.Log("material  " + Material);
            if (hit.collider)
            {
                if (hit.collider.tag == "Road")

                    Material = 2;
                else if (hit.collider.tag == "Terrain")

                    Material = 1;
                else

                    Material = 0f;
            }
            
        }
    }

    void PlayFootstepsEvent(string path)
    {
        // "Material" es el exacto nombre del parameter de FMOD !!!!
        FMOD.Studio.EventInstance Footsteps = FMODUnity.RuntimeManager.CreateInstance(path);
        Footsteps.setParameterByName("Material", Material);
        Footsteps.start();
        Footsteps.release();
    }
}
