using UnityEngine;

namespace Ludio.Overlay
{
    public interface IClickthroughController
    {
        void MouseMoved(Vector2 position);

        void HoverEntered();

        void HoverExited();
    }
}