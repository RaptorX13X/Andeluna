using UnityEngine;
using FMODUnity;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private int levelSound;



    FMOD.Studio.EventInstance FootstepsSound;
    FMOD.Studio.EventInstance JumpSound;
    FMOD.Studio.EventInstance LandSound;
    FMOD.Studio.EventInstance PickUpSound;


    [SerializeField] private EventReference footstepsEvent;
    [SerializeField] private EventReference jumpEvent;
    [SerializeField] private EventReference landEvent;
    [SerializeField] private EventReference pickUpEvent;

    public void PlayFootsteps()
    {
  
                if (levelSound == 1)
                {
                    Debug.Log("sand walk");
                    FootstepsSound = FMODUnity.RuntimeManager.CreateInstance(footstepsEvent);
                    FootstepsSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
                    FootstepsSound.setParameterByNameWithLabel("surface", "sand");
                    FootstepsSound.start();
                    FootstepsSound.release();
                }

            
            
        
    }


    public void PlayJump()
    {
        
            if (levelSound == 1)
            {
                Debug.Log("sand jump");
                JumpSound = FMODUnity.RuntimeManager.CreateInstance(jumpEvent);
                FMODUnity.RuntimeManager.PlayOneShotAttached(jumpEvent, gameObject);
                JumpSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
                JumpSound.setParameterByNameWithLabel("surface", "sand");
                JumpSound.start();
            }
            
            
       
        JumpSound.release();
    }

    public void PlayLanding()
    {
        LandSound = FMODUnity.RuntimeManager.CreateInstance(landEvent);
        FMODUnity.RuntimeManager.PlayOneShotAttached(landEvent, gameObject);
        LandSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
       

       
        {

            if (levelSound == 1)
            {
                Debug.Log("gravel land");
                LandSound.setParameterByNameWithLabel("Surface", "gravel");
                LandSound.start();
            }
           
        }

        LandSound.release();
    }

    public void PlayPickUp()
    {
        Debug.Log("E sound");
        PickUpSound = FMODUnity.RuntimeManager.CreateInstance(pickUpEvent);
        PickUpSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        PickUpSound.setParameterByNameWithLabel("sound", "E");
        PickUpSound.start();
        PickUpSound.release();

        Debug.Log("A sound");
        PickUpSound = FMODUnity.RuntimeManager.CreateInstance(pickUpEvent);
        PickUpSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        PickUpSound.setParameterByNameWithLabel("sound", "A");
        PickUpSound.start();
        PickUpSound.release();

        Debug.Log("G sound");
        PickUpSound = FMODUnity.RuntimeManager.CreateInstance(pickUpEvent);
        PickUpSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        PickUpSound.setParameterByNameWithLabel("sound", "G");
        PickUpSound.start();
        PickUpSound.release();

        Debug.Log("C sound");
        PickUpSound = FMODUnity.RuntimeManager.CreateInstance(pickUpEvent);
        PickUpSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        PickUpSound.setParameterByNameWithLabel("sound", "C");
        PickUpSound.start();
        PickUpSound.release();

        Debug.Log("F# sound");
        PickUpSound = FMODUnity.RuntimeManager.CreateInstance(pickUpEvent);
        PickUpSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        PickUpSound.setParameterByNameWithLabel("sound", "F#");
        PickUpSound.start();
        PickUpSound.release();

        Debug.Log("D sound");
        PickUpSound = FMODUnity.RuntimeManager.CreateInstance(pickUpEvent);
        PickUpSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        PickUpSound.setParameterByNameWithLabel("sound", "D");
        PickUpSound.start();
        PickUpSound.release();
    }
}

