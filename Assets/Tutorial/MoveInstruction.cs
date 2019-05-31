using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ludio.Overlay.UI
{
    public class MoveInstruction : MonoBehaviour {

        private bool isLow = false;
        private float amount;
        // Use this for initialization
        void Start () {
            amount = Screen.height / 13;
        }

        // Update is called once per frame
        void Update()
        {
            if (!isLow && !OverlayFactory.HANDLER().CanToggleClickThrough)
            {
                isLow = true;
                transform.SetPositionAndRotation(transform.position + new Vector3(0, -amount, 0), new Quaternion());
            }
            else if (isLow && OverlayFactory.HANDLER().CanToggleClickThrough)
            {
                transform.SetPositionAndRotation(transform.position + new Vector3(0, amount, 0), new Quaternion());
                isLow = false;
            }
        }
    }
}
