using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype02
{
    
    public abstract class P2SoundManager : MonoBehaviour
    {
        protected AudioSource audioSource;
        public List<AudioClip> audioClips;

        public bool isAudioSource;

        public void Initialize()
        {
            this.audioSource = this.gameObject.GetComponent<AudioSource>();

            if(audioSource)
            {
                this.isAudioSource = true;
            }
        }
        public void Play(int _noteNumber)
        {
            switch(_noteNumber)
            {
                case > 0:
                    audioSource.clip = audioClips[_noteNumber - 1];
                    audioSource.Play();
                    break;

                default:
                    break;
            }
            
        }
    }
}

