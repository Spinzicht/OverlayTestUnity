using Ludio.ExtensionMethods;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ludio
{
    public enum SCENE
    {
        DASHBOARD,
        OVERLAY
    }

    public class COMMANDS
    {
        private COMMANDS() { }

        private static COMMANDS _global;
        public static COMMANDS GLOBAL
        {
            get
            {
                if (_global == null) _global = new COMMANDS();
                return _global;
            }
        }

        public IEnumerator LoadScene(SCENE scene, int wait = 0)
        {
            string name = scene.ToString().CapitalizeFirst();
            Debug.Log(name);

            if(wait != 0)
                yield return new WaitForSeconds(wait);

            SceneManager.LoadScene(name);
        }
    }
}
