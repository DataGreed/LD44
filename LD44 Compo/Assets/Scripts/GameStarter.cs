using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    public string SceneNameToLoad = "Level01";

    public void StartGame()
    {

        //Reset allplayer progress since it's a new game
        PlayerPrefs.DeleteAll();

        //TODO: refactor and save keys somewhere
        PlayerPrefs.SetInt("ox", 20);   //oxygen
        PlayerPrefs.SetInt("he", 1);    //health
        PlayerPrefs.SetInt("ar", 0);    //armor
        PlayerPrefs.SetInt("am", 0);    //ammo
        PlayerPrefs.SetString("we", "");    //secondary weapon name

        print($"Loading scene{SceneNameToLoad}");
        SceneManager.LoadScene(SceneNameToLoad);
    }
}
