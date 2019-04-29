using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{

    public int minimumOxygen = 12;
    public int armorPrice = 5;

    public PlayerController player;

    public Weapon shotgunPrefab;
    public Weapon smgPrefab;
    public Weapon carbinePrefab;
    public Weapon riflePrefab;


    public Text title;

    public Text playerOxygenText;
    public Text playerSpendableOxygenText;

    public Text armorText;

    public Text playerSecondaryWeaponText;
    public Button sellWeaponButton;

    public Text shotgunText;
    public Button shotgunBuyButton;

    public Text smgText;
    public Button smgBuyButton;

    public Text carbineText;
    public Button carbineBuyButton;

    public Text rifleText;
    public Button rifleBuyButton;


    public Button armorBuyButton;


    // Start is called before the first frame update
    void Start()
    {
        //set title
        string sceneName = SceneManager.GetActiveScene().name;
        string battleNumber = sceneName[sceneName.Length - 1].ToString();   //TODO: will break if more than 9
        title.text = $"BATTLE {battleNumber} out of 9"; //TODO: get real number of battles

        //update default ammo amount and weapon names once
        shotgunText.text = $"{shotgunPrefab.weaponName.ToUpper()} (AMMO: {shotgunPrefab.defaultAmmoAmount})";
        smgText.text = $"{smgPrefab.weaponName.ToUpper()} (AMMO: {smgPrefab.defaultAmmoAmount})";
        carbineText.text = $"{carbinePrefab.weaponName.ToUpper()} (AMMO: {carbinePrefab.defaultAmmoAmount})";
        rifleText.text = $"{riflePrefab.weaponName.ToUpper()} (AMMO: {riflePrefab.defaultAmmoAmount})";

        //update buy prices once
        smgBuyButton.GetComponentInChildren<Text>().text = $"BUY FOR {smgPrefab.price}";
        carbineBuyButton.GetComponentInChildren<Text>().text = $"BUY FOR {carbinePrefab.price}";
        rifleBuyButton.GetComponentInChildren<Text>().text = $"BUY FOR {riflePrefab.price}";
        shotgunBuyButton.GetComponentInChildren<Text>().text = $"BUY FOR {shotgunPrefab.price}";

        armorBuyButton.GetComponentInChildren<Text>().text = $"BUY FOR {armorPrice}";
    }

    // Update is called once per frame
    void Update()
    {
        //update GUI
        //update what player have

        //oxygen
        playerOxygenText.text = $"OXYGEN: {Mathf.Floor(player.oxygenSeconds / 60)}:{Mathf.Ceil(player.oxygenSeconds % 60).ToString("00")}";

        //spendable oxygen
        playerSpendableOxygenText.text = $"SPENDABLE: {Mathf.Floor(SpendableOxygen / 60)}:{Mathf.Ceil(SpendableOxygen % 60).ToString("00")}";

        //armor
        if (player.armor > 0)
        {
            armorText.text = "ARMOR EQUIPPED";
        }
        else
        {
            armorText.text = "NO ARMOR";
        }

        if (player.secondaryWeapon)
        {
            //update price on sell weapon button 
            sellWeaponButton.GetComponentInChildren<Text>().text = $"SELL FOR {player.secondaryWeapon.price}";

            //update weapon name
            playerSecondaryWeaponText.text = $"SECONDARY WEAPON:\n{player.secondaryWeapon.weaponName} (AMMO: {player.secondaryWeapon.ammoLeft})";
            sellWeaponButton.interactable = true;
        }
        else
        {
            playerSecondaryWeaponText.text = $"SECONDARY WEAPON:\nEMPTY";
            sellWeaponButton.GetComponentInChildren<Text>().text = $"SELL";
            sellWeaponButton.interactable = false;
        }

        //enable/disable buy weapon buttons
        smgBuyButton.interactable = player.secondaryWeapon == null;
        carbineBuyButton.interactable = player.secondaryWeapon == null;
        rifleBuyButton.interactable = player.secondaryWeapon == null;
        shotgunBuyButton.interactable = player.secondaryWeapon == null;

        //enable/disable buy armor button
        armorBuyButton.interactable = player.armor <= 0;
    }

    int SpendableOxygen
    {
        get
        {
            if (player.oxygenSeconds <= minimumOxygen)
            {
                return 0;
            }

            return ((int)player.oxygenSeconds - minimumOxygen);
        }
    }

    void BuyWeapon(Weapon weaponPrefab)
    {
        if(SpendableOxygen >= weaponPrefab.price)
        {
            player.oxygenSeconds -= weaponPrefab.price;
            player.secondaryWeapon = Instantiate(weaponPrefab);
        }
        else
        {
            //TODO: play sound alert 
            //TODO: show "not enough spendable oxygen alert"
        }
    }

    public void SellSecondaryWeapon()
    {
        if(player.secondaryWeapon)
        {
            player.oxygenSeconds += player.secondaryWeapon.price;
            player.secondaryWeapon = null;  //TODO: better to destroy object?..
        }
    }

    public void BuyShotgun()
    {
        BuyWeapon(shotgunPrefab);
    }

    public void BuySMG()
    {
        BuyWeapon(smgPrefab);
    }

    public void BuyCarbine()
    {
        BuyWeapon(carbinePrefab);
    }

    public void BuyRifle()
    {
        BuyWeapon(riflePrefab);
    }

    public void BuyArmor()
    {
        if (SpendableOxygen >= armorPrice)
        {
            player.oxygenSeconds -= armorPrice;
            player.armor+=1;
        }
        else
        {
            //TODO: play sound alert 
            //TODO: show "not enough spendable oxygen alert"
        }
    }


}
