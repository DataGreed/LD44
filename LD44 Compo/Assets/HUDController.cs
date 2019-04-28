using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public PlayerController player;

    public Text oxygenText;
    public Text weaponText;

    public Image heartImage;
    public Image armorImage;

    // Update is called once per frame
    void Update()
    {
        Weapon weapon = player.GetActiveWeapon();
        string ammoLeftText = weapon.ammoLeft.ToString();
        if (weapon.ammoLeft > 999999)
        {
            ammoLeftText = "UNLIMITED";
        }
        weaponText.text = $"{weapon.name.ToUpper()} AMMO: {ammoLeftText}";
        oxygenText.text = $"OXYGEN LEFT: {Mathf.Floor(player.oxygenSeconds/60)}:{Mathf.Ceil(player.oxygenSeconds%60).ToString("00")}";

        heartImage.enabled = player.health > 0;
        armorImage.enabled = player.armor > 0;
    }
}
