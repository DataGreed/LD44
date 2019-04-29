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

    public int price;

    public int ammoLeft;
    float waitTillNextShotSeconds=0;

    public Projectile projectilePrefab;

    public void Start()
    {
        //FIXME: this may be wrong preserving ammo between batttles and buying more ammo
        ammoLeft = defaultAmmoAmount;
    }

    public void Fire(Vector2 originPoint, Vector2 direction)
    {
        //can't fire if no ammo left
        if (ammoLeft <= 0)
        {
            print("Can't shoot: no ammo left");
            return;
        }

        //check time since last shot
        if(waitTillNextShotSeconds>0)return;

        //instantiate all needed projctiles and fire them
        for (int i = 0; i < projectilesPerShot; i++)
        {
            GameObject projectileGameObject = Instantiate(projectilePrefab.gameObject);

            Projectile projectile = projectileGameObject.GetComponent<Projectile>();

            projectile.damage = this.damage;
            projectile.range = this.range;
            projectile.startingSpeed = projectileSpeed;
            //get random spread angle
            Quaternion spreadRotation = Quaternion.AngleAxis(Random.Range(-spreadRangeDegrees/2, spreadRangeDegrees / 2), Vector3.forward);
            //apply spread to original direction
            projectile.startingDirection = spreadRotation * direction;
            projectileGameObject.transform.position = originPoint;

            projectile.Fire();
        }

        //deplete ammo
        ammoLeft--;

        //set delay till next shot
        waitTillNextShotSeconds += delayBetweenShotsSeconds;
    }

    public void FixedUpdate()
    {
        if (waitTillNextShotSeconds > 0)
        {
            //advance the timer that ensures delay between shots
            waitTillNextShotSeconds -= Time.deltaTime;
            if (waitTillNextShotSeconds < 0) waitTillNextShotSeconds = 0;
        }
    }

    public int Accuracy
    {
        get
        {
            return (int)(100 / this.spreadRangeDegrees);
        }
    }

    public int RateOfFire
    {
        get
        {
            return (int)(1 / delayBetweenShotsSeconds);
        }
    }

}
