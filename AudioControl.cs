using UnityEngine;

public class AudioControl : MonoBehaviour
{
    private AudioSource[] audioSources;             //Collection of audios.
    private AudioSource flap;
    private AudioSource die;

    void Start()
    {
        audioSources = GetComponents<AudioSource>();
        //Add flap music.
        flap = audioSources[0];
        //Add die music.
        die = audioSources[1];
    }

    public void PlayFlapSound()
    {
        flap.Play();
    }

    public void PlayDieSound()
    {
        die.Play();
    }
}