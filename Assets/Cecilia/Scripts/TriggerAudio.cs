using UnityEngine;
using UnityEngine.EventSystems;

public class TriggerAudio : MonoBehaviour, IPointerEnterHandler
{
    public FMODUnity.EventReference Event;
    
    public bool PlayOnAwake;
    public bool PlayOnDestroy;
    public bool PlayOnHover;

    public void PlayOneShot()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(Event, gameObject);
    }

    private void Start()
    {
        if (PlayOnAwake)
            PlayOneShot();
    }

    private void OnDestroy()
    {
        if (PlayOnDestroy)
            PlayOneShot();
    }

    public void OnPointerEnter(PointerEventData eventData)

    {
        if(PlayOnHover)
        PlayOneShot();
    }
}