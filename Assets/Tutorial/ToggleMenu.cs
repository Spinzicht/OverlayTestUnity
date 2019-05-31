using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ludio.ExtensionMethods;
using UnityEngine.EventSystems;

namespace Ludio.Overlay.UI
{
    public class ToggleMenu : Util.Button
    {
        ClickthroughComponent component;
        private void Start()
        {
            component = new ClickthroughComponent(this);
        }

        private bool _open = false;
        public Canvas menu;

        // Use this for initialization
        protected override void Clicked()
        {
            _open = !_open;

            OverlayFactory.HANDLER().CanToggleClickThrough = !_open;

            if (_open)
            {
                menu.GetComponent<CanvasGroup>().Show();
            }
            else
            {
                menu.GetComponent<CanvasGroup>().Hide();
            }
        }
    }
}
