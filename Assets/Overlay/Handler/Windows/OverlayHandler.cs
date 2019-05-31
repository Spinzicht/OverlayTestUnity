namespace Ludio.Overlay.Windows
{
    public class OverlayHandler : Overlay.OverlayHandler
    {
        private static OverlayHandler wh;
        public static OverlayHandler INSTANCE()
        {
            if (wh == null)
            {
                wh = new OverlayHandler();
            }
            return wh;
        }

        protected OverlayHandler()
        {
            KeyboardTracker = KeyboardListener.INSTANCE;
            MouseTracker = MouseListener.INSTANCE;
            ActiveWindow = Window.INSTANCE;

            ((KeyboardListener)KeyboardTracker).HookKeyboard();
            ((MouseListener)MouseTracker).HookMouse();
        }

        ~OverlayHandler()
        {
            UnHook();
        }

        public void UnHook()
        {
            ((KeyboardListener)KeyboardTracker).UnHookKeyboard();
            ((MouseListener)MouseTracker).UnHookMouse();
        }
    }
}