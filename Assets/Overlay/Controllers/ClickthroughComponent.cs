using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Ludio.ExtensionMethods;
using UnityEngine.UI;

namespace Ludio.Overlay
{
    public class ClickthroughComponent
    {
        IClickthroughController controller;
        MonoBehaviour component;
        private bool hover = false;

        public ClickthroughComponent(MonoBehaviour mb, IClickthroughController tc = null) {
            controller = tc;
            component = mb;
            OverlayFactory.HANDLER().MouseTracker.OnMouseMoved += MouseTracker_OnMouseMoved;
        }

        private void MouseTracker_OnMouseMoved(object sender, Overlay.MouseMovedArgs e)
        {
            Bounds bounds = new Bounds(component.transform.position, ((RectTransform)component.transform).sizeDelta);
            var pos = bounds.LeftTopPosition();
            var size = bounds.size;

            var x = e.Position.x;
            var y = e.Position.y;

            MouseMove(e.Position);

            if (x > pos.x &&
                y > pos.y &&
                x < pos.x + size.x &&
                y < pos.y + size.y)
            {
                if(!hover)
                {
                    hover = true;
                    HoverEnter();
                }
            }
            else
            {
                if (hover)
                {
                    hover = false; ;
                    HoverExit();
                }
            }
        }

        protected void MouseMove(Vector2 position) { if(controller != null) controller.MouseMoved(position); }

        protected void HoverEnter()
        {
            OverlayFactory.HANDLER().ClickThrough = false;
            if (controller != null) controller.HoverEntered();
        }

        protected void HoverExit()
        {
            OverlayFactory.HANDLER().ClickThrough = true;
            if (controller != null) controller.HoverExited();
        }
    }
}
