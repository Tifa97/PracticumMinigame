using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : USceneController
{
    public SettingsController() : base(Names.Settings) { }

    public override void SceneDidLoad()
    {
        AddListeners();
    }

    public override void SceneWillAppear()
    {
        var obj = GameObject.Find(Names.Settings);
    }

    public override void SceneWillDisappear()
    {
        base.SceneWillDisappear();
    }

    private void AddListeners()
    {
        var BtnMainMenu = GameObject.Find(Names.BtnMainMenu).GetComponent<Button>();
        if (BtnMainMenu == null) return;

        BtnMainMenu.onClick.AddListener(() =>
        {
            var mainMenu = new MainMenuController();
            UNavigationController.SetRootViewController(mainMenu);
        });
    }
}
