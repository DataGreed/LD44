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
    public GameObject levelWonUI;
    public PlayerController player;
    public GameObject gameOverUI;

    public Weapon[] weaponPrefabs;

    public int levelNumber;
    public int totalLevels = 9;

    public float minimumOxygen = 12;
    public float oxygenBonusForVictory = 5; //same as in last tank. Use to balance

    bool levelWon = false;
    bool gameOver = false;

    private List<EnemyController> enemies;

    // Start is called before the first frame update
    void Start()
    {
        //stop time
        Time.timeScale = 0;

        //load player data preserved between levels 
        //(health, oxygen, armor, weapon, ammo)
        player.oxygenSeconds = PlayerPrefs.GetInt("ox", (int)minimumOxygen);   //oxygen
        if(player.oxygenSeconds<minimumOxygen)
        {
            player.oxygenSeconds = minimumOxygen;
        }
        player.health = PlayerPrefs.GetInt("he", 1);    //health
        player.armor = PlayerPrefs.GetInt("ar", 0);    //armor

        string weaponName = PlayerPrefs.GetString("we", "");    //secondary weapon name

        if(weaponName.Length>0)
        {
            foreach (var item in weaponPrefabs)
            {
                if(weaponName==item.weaponName)
                {
                    player.secondaryWeapon = Instantiate(item);
                    player.secondaryWeapon.ammoLeft = PlayerPrefs.GetInt("am", 0);    //ammo

                    break;
                }
            }

            if(player.secondaryWeapon==null)
            {
                print($"Could not find player weapon from prefs:{weaponName}");
            }
        }

        //hide HUD
        HUD.SetActive(false);
        gameOverUI.SetActive(false);
        levelWonUI.SetActive(false);
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


        if (!(gameOver || levelWon))
        {
            //check fail condition
            if (player.Dead)
            {
                GameOver();
            }
        }


        if (!(gameOver || levelWon))
        {
            //check win condition
            int enemiesLeft = 999;  //so we won't win in case of possible initialization glitch

            //TODO: update not every frame to optimize?
            if (enemies == null)
            {
                GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
                if (enemyObjects.Length > 0)
                {
                    enemies = new List<EnemyController>();
                    for (int i = 0; i < enemyObjects.Length; i++)
                    {
                        enemies.Add(enemyObjects[i].GetComponent<EnemyController>());
                    }
                }
            }
            else
            {
                enemiesLeft = 0;
                foreach (var item in enemies)
                {
                    if (!item.Dead)
                    {
                        enemiesLeft += 1;
                    }
                }
            }


            if (enemiesLeft <= 0)
            {
                WinLevel();
            }
        }

    }

    void WinLevel()
    {
        //give bonus for victory
        player.oxygenSeconds += oxygenBonusForVictory;
        //stop time
        Time.timeScale = 0; //so oxygen will stop depleting

        //save player progress
        PlayerPrefs.SetInt("ox", (int)Mathf.Ceil(player.oxygenSeconds));   //oxygen
        PlayerPrefs.SetInt("he", player.health);    //health
        PlayerPrefs.SetInt("ar", player.armor);    //armor
        if (player.secondaryWeapon)
        {
            PlayerPrefs.SetString("we", player.secondaryWeapon.weaponName);    //secondary weapon name
            PlayerPrefs.SetInt("am", player.secondaryWeapon.ammoLeft);    //ammo
        }
        else
        {
            PlayerPrefs.SetString("we", "");    //secondary weapon name
            PlayerPrefs.SetInt("am", 0);    //ammo
        }

        print("Level won!");
        levelWonUI.SetActive(true);
        levelWon = true;
    }

    public void LoadNextLevel()
    {
        print("Loading next level");
        //TODO: refactor
        string sceneName = sceneNamePrefix + "0" + (levelNumber+1).ToString();
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
        gameOverUI.SetActive(true);
        gameOver = true;
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
