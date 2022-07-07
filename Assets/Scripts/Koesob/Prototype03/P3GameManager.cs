using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Prototype03
{
    public class P3GameManager : MonoBehaviour
    {
        private static P3GameManager instance = null;
        public static UnityAction ActionInitialize;
        public static UnityAction ActionStart;
        public static UnityAction ActionEnd;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;

                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            this.Initialize();
        }

        private void Initialize()
        {

        }

        private void StartPlay()
        {

        }

        private void EndPlay()
        {

        }

        public static P3GameManager Intance
        {
            get
            {
                if(instance == null)
                {
                    return null;
                }

                return instance;
            }
        }
    }
}

