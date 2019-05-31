using Ludio.Data;
using Ludio.ExtensionMethods;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ludio.Overlay.UI
{
    public class InstructionCheckbox : Util.Button {

        bool wasOpen = false; 

        ClickthroughComponent component;
        private void Start()
        {
            component = new ClickthroughComponent(this);
        }

        protected override void Clicked()
        {
            var open = DATA.GLOBAL.Program.IsProgramOpen();
            var task = open ? DATA.GLOBAL.Task : DATA.GLOBAL.Program.Open;
            task.Current.IsDone = true;

            if (!wasOpen)
            {
                if (!task.NextTask())
                {
                    task.Start();
                }
            }
            else
            {
                if (!task.NextTask())
                {
                    var button = GetComponent<Button>();
                    button.interactable = false;
                    Debug.Log("done");
                    StartCoroutine(COMMANDS.GLOBAL.LoadScene(SCENE.DASHBOARD));
                }
            }
            wasOpen = open;
        }
    }
}