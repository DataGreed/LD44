using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponName;
    public float range;
    public float delayBetweenShotsSeconds;
    public float projectileSpeed;
    public int projectilesPerShot;
    public float spreadRangeDegrees;
    public int damage;
    public int defaultAmmoAmount;

    public int ammoLeft;

    public Projectile projectilePrefab;

    public void Start()
    {
        //FIXME: this may be wrong preserving ammo between batttles and buying more ammo
        ammoLeft = defaultAmmoAmount;
    }

    public void Fire(Vector2 originPoint, Vector2 direction)
    {
        //can't fire if no ammo left
        if (ammoLeft <= 0) return;

        //TODO:set timer to check rate of fire since last time fired


        //instantiate all needed projctiles and fire them
        for (int i = 0; i < projectilesPerShot; i++)
        {
            GameObject projectileGameObject = Instantiate(projectilePrefab.gameObject);

            Projectile projectile = projectileGameObject.GetComponent<Projectile>();

            projectile.damage = this.damage;
            projectile.range = this.range;
            projectile.startingSpeed = projectileSpeed;
            //TODO: add spread angle
            projectile.startingDirection = direction;
            projectileGameObject.transform.position = originPoint;

            projectile.Fire();
        }

        //deplete ammo
        ammoLeft--;
    }
}
