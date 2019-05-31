using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Ludio.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static Vector2 LeftTopPosition(this Bounds b)
        {
            Vector2 position;
            position = new Vector2(b.center.x, UnityEngine.Screen.height - b.center.y);
            position -= b.size.XY() / 2;

            return position;
        }

        public static Vector2 XY(this Vector3 v)
        {
            return new Vector2(v.x, v.y);
        }

        public static Vector2 FlipY(this Vector2 v)
        {
            return new Vector2(v.x, UnityEngine.Screen.height - v.y);
        }

        public static void Show(this CanvasGroup canvasGroup)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }

        public static void Hide(this CanvasGroup canvasGroup)
        {
            canvasGroup.alpha = 0f; //this makes everything transparent
            canvasGroup.blocksRaycasts = false; //this prevents the UI element to receive input events
        }

        public static IEnumerator Load(this Sprite sprite, string imgURL)
        {
            WWW www = new WWW(imgURL);
            yield return www;
            sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
        }

        public static string CapitalizeFirst(this string input)
        {
            switch (input)
            {
                case null: return null;
                case "": return "";
                default: return input.First().ToString().ToUpper() + input.Substring(1).ToLower();
            }
        }

        public static Color FromHex(this Color color, string hex)
        {
            Color col = new Color();
            ColorUtility.TryParseHtmlString(hex, out col);
            return col;
        }
    }
}
