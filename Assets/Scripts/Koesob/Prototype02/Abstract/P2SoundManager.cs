using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype02
{
    
    public abstract class P2SoundManager : MonoBehaviour
    {
        [SerializeField] protected AudioSource audioKick;
        [SerializeField] protected AudioSource audioHiHat;
        [SerializeField] protected AudioSource audioViolin;
        public List<AudioClip> audioClips;

        public void Initialize()
        {
        }

        public void Play(int _noteNumber)
        {
            switch(_noteNumber)
            {
                case 0:
                    audioKick.clip = audioClips[_noteNumber];
                    audioKick.Play();
                    break;
                case 1:
                    audioHiHat.clip = audioClips[_noteNumber];
                    audioHiHat.Play();
                    break;
                case 2:
                    audioViolin.clip = audioClips[_noteNumber];
                    audioViolin.Play();
                    break;

                default:
                    break;
            }
            
        }
    }
}

