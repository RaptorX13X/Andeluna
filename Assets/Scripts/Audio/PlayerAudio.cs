using UnityEngine;
using FMODUnity;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private int levelSound;



    FMOD.Studio.EventInstance FootstepsSound;
    FMOD.Studio.EventInstance JumpSound;
    FMOD.Studio.EventInstance LandSound;
    FMOD.Studio.EventInstance InteractionSound;



    [SerializeField] private EventReference footstepsEvent;
    [SerializeField] private EventReference jumpEvent;
    [SerializeField] private EventReference landEvent;
    [SerializeField] private EventReference interactionEvent;

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
                Debug.Log("sand land");
                LandSound.setParameterByNameWithLabel("surface", "sand");
                LandSound.start();
            }
           
        }

        LandSound.release();
    }

    public void PlayInteraction()
    {
       InteractionSound = FMODUnity.RuntimeManager.CreateInstance(interactionEvent);
        InteractionSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        InteractionSound.start();
        InteractionSound.release();
    }

    
}

