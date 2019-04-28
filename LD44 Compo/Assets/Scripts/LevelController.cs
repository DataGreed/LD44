using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    public string sceneNamePrefix = "Level";

    public GameObject HUD;
    public GameObject shop;
    public GameObject levelWon;
    public GameObject player;
    public GameObject gameOver;

    public int levelNumber;
    public int totalLevels = 9;

    // Start is called before the first frame update
    void Start()
    {
        //stop time
        Time.timeScale = 0;

        //load player data (health, oxygen, armor, weapon, ammo
        //TODO: load player data (playerprefs? singleton?)

        //give player everything he has
        //TODO: give player everything that's needed
        //TODO: ensure minimum level of oxygen

        //hide HUD
        HUD.SetActive(false);
        gameOver.SetActive(false);
        levelWon.SetActive(false);
        //show shop
        shop.SetActive(true);

        string sceneName = SceneManager.GetActiveScene().name;

        levelNumber = Int32.Parse(sceneName[sceneName.Length-1].ToString());

    }

    public void StartLevel()
    {

        HUD.SetActive(true);
        shop.SetActive(false);

        //start time
        Time.timeScale = 1;
    }

    void Update()
    {
        //TODO: check for win condition
        //TODO: check for fail condition
    }

    void WinLevel()
    {
        //stop time
        Time.timeScale = 0; //so oxygen will stop depleting

        //save player progress
        //TODO: save player progress

        print("Level won!");
        //TODO: show win overlay
    }

    public void LoadNextLevel()
    {
        print("Loading next level");
        //TODO: refactor
        string sceneName = sceneNamePrefix + "0" + levelNumber.ToString();
        print($"Loading scene{sceneName}");
        SceneManager.LoadScene(sceneName);
    }

    public void RestartLevel()
    {
        print("Restarting level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        print("Game over");
    }

    public int EnemiesLeft
    {
        get
        {
            //TOOD: implement
            return 0;
        }
    }
}
