﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreloadSceneController : MonoBehaviour
{
    void Start()
    {
#if UNITY_EDITOR
        Debug.unityLogger.logEnabled = true;
#else
        Debug.unityLogger.logEnabled = false;
#endif

        //Need to setup singletons
        AssetProvider.Prewarm();
        InputManager.StartInputManager();

        var MainMenuController = new MainMenuController();
        UNavigationController.SetRootViewController(MainMenuController);
    }
}
