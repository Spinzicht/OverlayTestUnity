using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Ludio.UI
{
    public class ShowLocation : MonoBehaviour
    {
        public Text t;

        void Start()
        {
            OverlayFactory.HANDLER().MouseTracker.OnMouseMoved += MouseTracker_OnMouseMoved;
        }

        private void MouseTracker_OnMouseMoved(object sender, Overlay.MouseMovedArgs e)
        {
            t.text = e.Position.ToString();
        }
    }
}
