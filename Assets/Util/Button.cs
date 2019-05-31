using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Ludio.Util
{
    public abstract class Button : MonoBehaviour
    {
        public void Click()
        {
            EventSystem.current.SetSelectedGameObject(null);
            Clicked();
        }

        protected abstract void Clicked();
    }
}
