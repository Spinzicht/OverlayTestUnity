using System;
using Ludio;
using Ludio.Commands;
using Ludio.Data;
using Ludio.ExtensionMethods;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : Ludio.Util.Button, IListener<Program>
{
    Text text;
    CanvasGroup background;

    public string programName;

    void OnEnable()
    {
        Debug.Log("enable");
        DATA.GLOBAL.Add(this);
        Init();
    }

    void OnDisable()
    {
        Debug.Log("disable");
        DATA.GLOBAL.Remove(this);
    }

    private void Init()
    {
        text = GetComponentInChildren<Text>();
        background = GetComponentInChildren<CanvasGroup>();
    }

    public void Updated(Program globalProgram)
    {

        if (globalProgram == null && programName == "")
        {
            text.fontStyle = FontStyle.Bold;
            background.Show();
            return;
        }

        if (globalProgram == null || globalProgram.Name != programName)
        {
            text.color = new Color().FromHex("#D9D9D9FF");
            text.fontStyle = FontStyle.Normal;
            background.Hide();
        }
        else
        {
            text.color = new Color().FromHex(globalProgram.Color);
            text.fontStyle = FontStyle.Bold;
            background.Show();
        }
    }

    private void OnDestroy()
    {
        Debug.Log("destroy");
    }

    protected override void Clicked()
    {
        DATA.GLOBAL.SetProgram(programName);
    }
}
