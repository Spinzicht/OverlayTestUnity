
using UnityEngine;
using UnityEngine.UI;

namespace Ludio.Overlay
{
    public class OverlayCamera : MonoBehaviour
    {
        [SerializeField] private Material m_Material;
        public bool clickthrough = true;

        void Start()
        {
            OverlayFactory.HANDLER().ClickThrough = clickthrough;
        }

        void OnRenderImage(RenderTexture from, RenderTexture to)
        {
            Graphics.Blit(from, to, m_Material);
        }
    }
}