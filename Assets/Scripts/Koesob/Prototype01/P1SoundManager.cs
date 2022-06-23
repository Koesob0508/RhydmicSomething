using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace prototype01
{
    public class P1SoundManager : MonoBehaviour
    {
        public AudioSource audioSource;
        public List<AudioClip> audioClips;
        public void Initialize()
        {
            audioSource = this.gameObject.GetComponent<AudioSource>();
        }

        public void Play(int _noteNumber)
        {
            if(_noteNumber == 1)
            {
                audioSource.clip = audioClips[0];
                audioSource.Play();
            }
            else if(_noteNumber == 2)
            {
                audioSource.clip = audioClips[1];
                audioSource.Play();
            }

            
        }
    }
}