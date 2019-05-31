using Ludio.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Ludio.Overlay.UI
{
    public class CurrentInstruction : MonoBehaviour
    {
        Text t;
        // Use this for initialization
        void Start()
        {
            DATA.GLOBAL.Task.Start();
            t = GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            var task = DATA.GLOBAL.Program.IsProgramOpen() ? DATA.GLOBAL.Task : DATA.GLOBAL.Program.Open;
            var cur = task.Current;
            var text = cur.Text;
            t.text = text;
        }
    }
}