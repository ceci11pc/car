using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour
{

    FMOD.Studio.EventInstance engine;
    FMOD.Studio.PARAMETER_ID  loadId;

    PlayerController Car;

    // Start is called before the first frame update
    void Start()
    {
        engine = FMODUnity.RuntimeManager.CreateInstance("event:/ENGINE");

        FMOD.Studio.EventDescription engineEventDescription;
        engine.getDescription(out engineEventDescription);

        FMOD.Studio.PARAMETER_DESCRIPTION engineLoadParameterDescription;
        engineEventDescription.getParameterDescriptionByName("Accel", out engineLoadParameterDescription);

        loadId = engineLoadParameterDescription.id;

        Car = GetComponent<PlayerController>();
        engine.start();
        
    }

    // Update is called once per frame
    void Update()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("RPM", Car.speed);  
        engine.setParameterByID(loadId, Car.fowardInput);
    }

    void OnDestroy()
    {
        engine.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        engine.release();
    }
}
