using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : USceneController
{
    public MainMenuController() : base(Names.MainMenu) { }

    public override void SceneDidLoad()
    {
        AddButtonListeners();
    }

    public override void SceneWillAppear()
    {
        var obj = GameObject.Find(Names.MainMenu);
    }

    private void AddButtonListeners()
    {
        var btnPlay = GameObject.Find(Names.BtnPlay).GetComponent<Button>();
        if (btnPlay == null) return;

        btnPlay.onClick.AddListener(() =>
        {
            var level = new LevelController();
            UNavigationController.SetRootViewController(level);
        });

        var btnSettings = GameObject.Find(Names.BtnSettings).GetComponent<Button>();
        if (btnSettings == null) return;

        btnSettings.onClick.AddListener(() =>
        {
            var settings = new SettingsController();
            AddChildSceneController(settings);
        });

        var btnExit = GameObject.Find(Names.BtnExit).GetComponent<Button>();
        if (btnExit == null) return;

        btnExit.onClick.AddListener(() =>
        {
            QuitGame();
        });
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
