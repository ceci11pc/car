using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour
{

    FMOD.Studio.EventInstance engine;
    FMOD.Studio.EventInstance tyres;
    FMOD.Studio.PARAMETER_ID rpmId, loadId;

    PlayerController Car;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        engine = FMODUnity.RuntimeManager.CreateInstance("event:/ENGINE");
        tyres = FMODUnity.RuntimeManager.CreateInstance("event:/TYRES");

        FMOD.Studio.EventDescription engineEventDescription;
        engine.getDescription(out engineEventDescription);

        FMOD.Studio.PARAMETER_DESCRIPTION engineRpmParameterDescription;
        engineEventDescription.getParameterDescriptionByName("RPM", out engineRpmParameterDescription);

        rpmId = engineRpmParameterDescription.id;

        FMOD.Studio.PARAMETER_DESCRIPTION engineLoadParameterDescription;
        engineEventDescription.getParameterDescriptionByName("Accel", out engineLoadParameterDescription);

        loadId = engineLoadParameterDescription.id;
        

        Car = GetComponent<PlayerController>();
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(tyres, GetComponent<Transform>(), GetComponent<Rigidbody>());
        engine.start();
        tyres.start();
    }

    // Update is called once per frame
    void Update()
    {
       
        engine.setParameterByID(rpmId, Car.speed);
        engine.setParameterByID(loadId, Car.fowardInput);
        tyres.setParameterByID(rpmId, Car.speed);

    }
}
