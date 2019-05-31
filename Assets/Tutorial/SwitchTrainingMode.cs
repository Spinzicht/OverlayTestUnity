using Ludio.Data;
using Ludio.Data.Tasks;
using Ludio.ExtensionMethods;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ludio.Overlay.UI
{
    public class SwitchTrainingMode : Util.Button
    {
        ClickthroughComponent component;
        private void Start()
        {
            component = new ClickthroughComponent(this);
        }

        // Update is called once per frame
        void Update()
        {
            if (DATA.GLOBAL.Task.Current is Training)
            {
                GetComponent<CanvasGroup>().Show();
            }
            else
            {
                GetComponent<CanvasGroup>().Hide();
            }
        }

        PRACTICEMODE GetOtherMode()
        {
            return (DATA.GLOBAL.Task.Current.Mode == PRACTICEMODE.PRACTICE) ? PRACTICEMODE.CHALLENGE : PRACTICEMODE.PRACTICE;
        }

        protected override void Clicked()
        {
            DATA.GLOBAL.Task.Current.Mode = GetOtherMode();
        }
    }
}
