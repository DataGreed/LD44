using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    public string SceneNameToLoad = "Level01";

    public void StartGame()
    {
        print($"Loading scene{SceneNameToLoad}");
        SceneManager.LoadScene(SceneNameToLoad);
    }
}
