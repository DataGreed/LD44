using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public PlayerController player;

    public Text oxygenText;
    public Text weaponText;
    public Text enemiesText;

    public Image heartImage;
    public Image armorImage;

    private List<EnemyController> enemies;

    // Update is called once per frame
    void Update()
    {
        int enemiesLeft = 0;

        //TODO: update not every frame to optimize?
        //TODO: probably better to move to game controller where win condition is checked and read it from there
        if (enemies==null)
        {
            GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
            if(enemyObjects.Length>0)
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
            foreach (var item in enemies)
            {
                if(!item.Dead)
                {
                    enemiesLeft += 1;
                }
            }
        }

        Weapon weapon = player.GetActiveWeapon();
        string ammoLeftText = weapon.ammoLeft.ToString();
        if (weapon.ammoLeft > 999999)
        {
            ammoLeftText = "UNLIMITED";
        }
        weaponText.text = $"{weapon.name.ToUpper()} AMMO: {ammoLeftText}";
        oxygenText.text = $"OXYGEN LEFT: {Mathf.Floor(player.oxygenSeconds/60)}:{Mathf.Ceil(player.oxygenSeconds%60).ToString("00")}";
        enemiesText.text = $"ENEMIES LEFT: {enemiesLeft}";

        heartImage.enabled = player.health > 0;
        armorImage.enabled = player.armor > 0;

    }
}
