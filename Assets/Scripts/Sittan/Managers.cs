using System;
using System.Collections;
using UnityEngine;

namespace Prototype03
{
    public class Managers : MonoBehaviour
    {
        static Managers s_instance;
        static Managers Instance => s_instance;

        #region Contents

        GameManager _game = new GameManager();
        StageManager _stage = new StageManager();

        public static GameManager Game => Instance._game ;
        public static StageManager Stage => Instance._stage;

        #endregion

        #region Core

        InputManager _input = new InputManager();
        UIManager _ui = new UIManager();
        SoundManager _sound = new SoundManager();

        public static InputManager Input => Instance._input;
        public static UIManager UI => Instance._ui;
        public static SoundManager Sound => Instance._sound;

        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            if (s_instance == null)
            {
                GameObject go = GameObject.Find("@Managers");
                if (go == null)
                {
                    go = new GameObject { name = "@Managers" };
                    go.AddComponent<Managers>();
                }

                DontDestroyOnLoad(go);
                s_instance = go.GetComponent<Managers>();

                //Data.Init();
                //Local.Init();
                //Option.Init();
                //Sound.Init();
                //Game.Init();
            }
        }
    }
}