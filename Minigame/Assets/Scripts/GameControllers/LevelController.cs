using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : USceneController
{
    public LevelController() : base(Names.Level) { }
    private GameObject EndMenu;
    private Text TxtSuccess;
    private Text TxtFail;
    private Button BtnRetry;
    private Button BtnMenu;
    private int totalEnemies;
    private int enemiesLeft;
    private bool isLevelComplete = false;

    public override void SceneDidLoad()
    {
        Time.timeScale = 1;
        GetUIComponents();
        HandleButtonClicks();
        EnemySpawnController.OnEnemiesSet += EnemySpawnController_OnEnemiesSet;
        EnemyHealth.OnEnemyDied += EnemyHealth_OnEnemyDied;
        PlayerHealth.OnPlayerDied += PlayerHealth_OnPlayerDied;
    }

    private void HandleButtonClicks()
    {
        BtnRetry.onClick.AddListener(() =>
        {
            var level = new LevelController();
            UNavigationController.SetRootViewController(level);
        });
       
        BtnMenu.onClick.AddListener(() =>
        {
            var menu = new MainMenuController();
            UNavigationController.SetRootViewController(menu);
        });
    }

    private void GetUIComponents()
    {
        EndMenu = GameObject.Find(Names.EndMenu);
        if (EndMenu == null) return;
        TxtSuccess = GameObject.Find(Names.TxtSuccess).GetComponent<Text>();
        if (TxtSuccess == null) return;
        TxtFail = GameObject.Find(Names.TxtFail).GetComponent<Text>();
        if (TxtFail == null) return;
        BtnRetry = GameObject.Find(Names.BtnRetry).GetComponent<Button>();
        if (BtnRetry == null) return;
        BtnMenu = GameObject.Find(Names.BtnToMenu).GetComponent<Button>();
        if (BtnMenu == null) return;
        EndMenu.SetActive(false);
        TxtSuccess.gameObject.SetActive(false);
        TxtFail.gameObject.SetActive(false);
    }

    private void EnemySpawnController_OnEnemiesSet(int enemies)
    {
        totalEnemies = enemies;
        enemiesLeft = totalEnemies;
    }

    private void PlayerHealth_OnPlayerDied()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        AssetProvider.ReturnAllToPool();
        EndMenu.SetActive(true);
        TxtFail.gameObject.SetActive(true);
    }

    private void EnemyHealth_OnEnemyDied()
    {
        enemiesLeft--;
        if (enemiesLeft <= 0)
        {
            Time.timeScale = 0;
            AssetProvider.ReturnAllToPool();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            EndMenu.SetActive(true);
            TxtSuccess.gameObject.SetActive(true);
        }
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
