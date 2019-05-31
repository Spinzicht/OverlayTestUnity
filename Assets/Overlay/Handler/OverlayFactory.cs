using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ludio
{
    public class OverlayFactory
    {
        private static OverlayFactory wf;

        public static OverlayFactory INSTANCE()
        {
            if (wf == null)
            {
#if !UNITY_EDITOR   // You really don't want to enable this in the editor..
                wf = TransparentOverlayFactory.INSTANCE();
#else
                wf = new OverlayFactory();
#endif
            }
            return wf;
        }

        protected OverlayFactory() { }

        public static Overlay.OverlayHandler HANDLER()
        {
            return INSTANCE().GetHandler();
        }

        public virtual Overlay.OverlayHandler GetHandler()
        {
            return Overlay.Windows.OverlayHandler.INSTANCE();
        }
    }

    class TransparentOverlayFactory : OverlayFactory
    {
        private static TransparentOverlayFactory wf;

        public new static TransparentOverlayFactory INSTANCE()
        {
            if (wf == null) wf = new TransparentOverlayFactory();
            return wf;
        }

        private TransparentOverlayFactory() { }

        public override Overlay.OverlayHandler GetHandler()
        {
            return Overlay.Windows.TransparentOverlayHandler.INSTANCE();
        }
    }
}
