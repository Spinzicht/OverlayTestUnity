using Ludio.Commands;
using Ludio.Data;
using Ludio.ExtensionMethods;
using Ludio.Overlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ludio.Dashboard
{
    public class Dashboard : MonoBehaviour, IListener<Program>
    {
        public MonoBehaviour apps;
        public MonoBehaviour program;

        ClickthroughComponent component;

        public void Updated(Program globalProgram)
        {
            if (globalProgram == null) {
                apps.GetComponent<CanvasGroup>().Show();
                program.GetComponent<CanvasGroup>().Hide();
            }
            else
            {
                program.GetComponent<CanvasGroup>().Show();
                apps.GetComponent<CanvasGroup>().Hide();
            }
        }

        private void OnEnable()
        {
            component = new ClickthroughComponent(this);
            DATA.GLOBAL.Add(this);
        }

        private void OnDisable()
        {
            DATA.GLOBAL.Remove(this);
        }
    }
}
