using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : USceneController
{
    public LevelController() : base(Names.Level) { }

    public override void SceneDidLoad()
    {
        
    }

    public override void SceneWillAppear()
    {
        var obj = GameObject.Find(Names.Level);
    }

    public override void SceneWillDisappear()
    {
        base.SceneWillDisappear();
    }
}
