using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class PickUpManager : MonoBehaviour
{
    FMOD.Studio.EventInstance PickUpSound;
    [SerializeField] private EventReference pickUpEvent;

    private int number;

    public static PickUpManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    
    public void PlayPickUp()
    {
        switch (number)
        {
            case 0:
                Debug.Log("E sound");
                PickUpSound = FMODUnity.RuntimeManager.CreateInstance(pickUpEvent);
                PickUpSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
                PickUpSound.setParameterByNameWithLabel("sound", "E");
                PickUpSound.start();
                PickUpSound.release();
                number += 1;
                    break;
                case 1:
                Debug.Log("A sound");
                PickUpSound = FMODUnity.RuntimeManager.CreateInstance(pickUpEvent);
                PickUpSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
                PickUpSound.setParameterByNameWithLabel("sound", "A");
                PickUpSound.start();
                PickUpSound.release();
                number += 1;
                break;
            case 2:
                Debug.Log("G sound");
                PickUpSound = FMODUnity.RuntimeManager.CreateInstance(pickUpEvent);
                PickUpSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
                PickUpSound.setParameterByNameWithLabel("sound", "G");
                PickUpSound.start();
                PickUpSound.release();
                number += 1; 
                break;
            case 3:
                Debug.Log("C sound");
                PickUpSound = FMODUnity.RuntimeManager.CreateInstance(pickUpEvent);
                PickUpSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
                PickUpSound.setParameterByNameWithLabel("sound", "C");
                PickUpSound.start();
                PickUpSound.release();
                number += 1; 
                break;
            case 4:
                Debug.Log("F# sound");
                PickUpSound = FMODUnity.RuntimeManager.CreateInstance(pickUpEvent);
                PickUpSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
                PickUpSound.setParameterByNameWithLabel("sound", "F#");
                PickUpSound.start();
                PickUpSound.release();
                number += 1;
                break;
                case 5:
                Debug.Log("D sound");
                PickUpSound = FMODUnity.RuntimeManager.CreateInstance(pickUpEvent);
                PickUpSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
                PickUpSound.setParameterByNameWithLabel("sound", "D");
                PickUpSound.start();
                PickUpSound.release();
                number += 1; 
                break;
                case 6:
                Debug.Log("F# sound");
                PickUpSound = FMODUnity.RuntimeManager.CreateInstance(pickUpEvent);
                PickUpSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
                PickUpSound.setParameterByNameWithLabel("sound", "F#");
                PickUpSound.start();
                PickUpSound.release();
                number += 1;
                break;
                case 7:
                Debug.Log("E sound");
                PickUpSound = FMODUnity.RuntimeManager.CreateInstance(pickUpEvent);
                PickUpSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
                PickUpSound.setParameterByNameWithLabel("sound", "E");
                PickUpSound.start();
                PickUpSound.release();
                number += 1;
                break;
        }
        

        

        

        

        

        
    }
}
