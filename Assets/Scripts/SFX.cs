using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    //Audio
    public AudioClip throwSound;
    public AudioClip impactSound;
    public AudioClip powerUpSound;
    public AudioClip deathSound;
    public AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ThrowSound()
    {
        playerAudio.PlayOneShot(throwSound);
    }
    public void ImpactSound()
    {
        playerAudio.PlayOneShot(impactSound);
    }
    public void PowerUpSound()
    {
        playerAudio.PlayOneShot(powerUpSound);
    }
    public void DeathSound()
    {
        playerAudio.PlayOneShot(deathSound);
    }

}
