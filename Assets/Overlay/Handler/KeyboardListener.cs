using System;
using UnityEngine;
using WeakEvent;

namespace Ludio.Overlay
{
    public abstract class KeyboardListener
    {
        protected readonly WeakEventSource<KeyPressedArgs> _onKeyPressed = new WeakEventSource<KeyPressedArgs>();
        public event EventHandler<KeyPressedArgs> OnKeyPressed
        {
            add { _onKeyPressed.Subscribe(value); }
            remove { _onKeyPressed.Unsubscribe(value); }
        }

        protected readonly WeakEventSource<KeyPressedArgs> _onKeyReleased = new WeakEventSource<KeyPressedArgs>();
        public event EventHandler<KeyPressedArgs> OnKeyReleased
        {
            add { _onKeyReleased.Subscribe(value); }
            remove { _onKeyReleased.Unsubscribe(value); }
        }
    }

    public class KeyPressedArgs : EventArgs
    {
        public KeyCode KeyPressed { get; private set; }

        public KeyPressedArgs(KeyCode key)
        {
            KeyPressed = key;
        }
    }

}
