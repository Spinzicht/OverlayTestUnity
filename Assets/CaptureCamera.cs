using Assets;
using Assets.C;
using Ludio;
using Ludio.Overlay;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CaptureCamera : MonoBehaviour {

    Texture2D tex;
    Texture2D tex2;

    public GameObject target;
    bool wait = true;
    // Use this for initialization
    void Start () {
        tex = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, true);
        tex2 = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, true);

        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(2);
        wait = false;
    }

    void OnPostRender()
    {
        if(!wait)
        {
            tex = OverlayFactory.HANDLER().ActiveWindow.GetActiveWindowCapture();
            if(tex != null)
                target.GetComponent<RawImage>().texture = tex;
        }
    }


}
