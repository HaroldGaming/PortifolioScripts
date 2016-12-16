using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {


    public void PlaySound(AudioClip clip, float volume) {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(clip, volume);
    }
}
