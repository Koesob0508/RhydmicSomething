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
        [SerializeField] protected AudioSource audioClap;
        [SerializeField] protected AudioSource audioSnare;

        public List<AudioClip> audioClips;

        public void Initialize()
        {
            audioKick.clip = audioClips[0];
            audioHiHat.clip = audioClips[1];
            audioViolin.clip = audioClips[2];
            audioClap.clip = audioClips[3];
        }

        public void Play(int _noteNumber)
        {
            switch(_noteNumber)
            {
                case 0:
                    audioKick.Play();
                    break;
                case 1:
                    audioHiHat.Play();
                    break;
                case 2:
                    audioViolin.Play();
                    break;
                case 3:
                    audioClap.Play();
                    break;
                case 4:
                    audioSnare.Play();
                    break;

                default:
                    break;
            }
            
        }
    }
}

