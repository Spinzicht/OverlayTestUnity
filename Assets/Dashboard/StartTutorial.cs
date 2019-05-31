using Ludio;
using Ludio.Data;
using Ludio.ExtensionMethods;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTutorial : Ludio.Util.Button
{
    public string tutorial;

    protected override void Clicked()
    {
        DATA.GLOBAL.SetTask(tutorial);
        StartCoroutine(COMMANDS.GLOBAL.LoadScene(SCENE.OVERLAY));
    }
}
