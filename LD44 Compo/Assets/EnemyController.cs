using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed = 8.0f;
    /// <summary>
    /// When checking for being in fire range with player, check not the actual 
    /// range, but range multiplied by modifier. Making this lower may make the 
    /// game easier and keeping it a little bit under zero (like 0.8-0.9)
    /// will increase the chance of hitting a player
    /// </summary>
    public float fireRangeCheckModifier = 0.8f;
    public Weapon primaryWeapon;    //don't use prefabs here, they won;t work.
    public Weapon secondaryWeapon;
    public Transform shootingOriginPoint;

    public Animator torsoAnimator;
    public Animator legsAnimator;

    public const string FIRING_WEAPON_ANIMATION_PARAMETER = "firingWeapon";
    public const string RUNNING_ANIMATION_PARAMETER = "running";

    private bool dodging = false;
    private Rigidbody2D rb;
    private GameObject player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        

        if (dodging)    //TODO: alert enemy when firing that he should dodge
        {
            //TODO: sidestep from vector between player and enemy
        }
        else
        {
            if (SeesPlayer)
            {
                if (PlayerInFireRange)
                {
                    // TODO: fire
                }
                else
                {
                    //TODO: move towards player
                }
            }
        }
    }


    void Fire(Vector2 targetPoint)
    {
        Weapon weaponToFire = GetActiveWeapon();

        // choose proper animation for primary or secondary weapon
        // FIXME: don;t assume that primary is always a pistol
        if (weaponToFire == primaryWeapon)
        {
            torsoAnimator.SetInteger(FIRING_WEAPON_ANIMATION_PARAMETER, 1);
        }
        else
        {
            torsoAnimator.SetInteger(FIRING_WEAPON_ANIMATION_PARAMETER, 2);
        }

        //fire towards given point
        weaponToFire.Fire(shootingOriginPoint.position, targetPoint);

    }



    Weapon GetActiveWeapon()
    {
        Weapon weaponToFire = primaryWeapon;

        if (secondaryWeapon)
        {
            if (secondaryWeapon.ammoLeft > 0)
            {
                weaponToFire = secondaryWeapon;
            }
        }

        return weaponToFire;
    }

    public void MoveTowardsPoint()
    {

    }

    public void StopMoving()
    {
        rb.velocity = Vector2.zero;
    }

    public bool PlayerInFireRange
    {
        get
        {
            //TODO: check distance between enemy and player
            return true;
        }
    }

    public bool SeesPlayer
    {
        get
        {
            //TODO: check distance between enemy and player
            return true;
        }
    }
}
