using System;
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

    public float playerDetectionDistance = 40;

    public int health = 1;
    public int armor = 1;

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

    private Vector2 wanderDestination;
    private float timeTillWanderDirectionChange=0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {

        if(Dead)
        {
            return;
        }

        if (dodging)    //TODO: alert enemy when firing that he should dodge
        {
            //TODO: sidestep from vector between player and enemy
            //TODO: raycast to check wich way to dodge so won't hit a wall or another enemy?
        }
        else
        {
            if (SeesPlayer)
            {
                //look at player. Scare the sh%t out of him (her?) :D
                LookTowardsPoint(player.transform.position);

                if (PlayerInFireRange)
                {
                    //fire at player
                    StopMoving();
                    Fire(player.transform.position);
                    //TODO: randomize point around the player a little to give more chances to hit him
                }
                else
                {
                    //move towards player
                    MoveTowardsPoint(player.transform.position);

                    //reset firing animation
                    torsoAnimator.SetInteger(FIRING_WEAPON_ANIMATION_PARAMETER, 0);
                }
            }
            else
            {
                //StopMoving();
                //disable fire animatino
                torsoAnimator.SetInteger(FIRING_WEAPON_ANIMATION_PARAMETER, 0);

                //wander around aimlessly waiting for player

                if (timeTillWanderDirectionChange <= 0)
                {
                    //check if time to change direction
                    Quaternion randomDirection = Quaternion.AngleAxis(UnityEngine.Random.Range(0, 360), Vector3.forward);
                    wanderDestination = randomDirection * Vector2.up * 100; //has to be far

                    timeTillWanderDirectionChange = UnityEngine.Random.Range(0.8f, 1.5f);  
                }

                MoveTowardsPoint(wanderDestination);
                LookTowardsPoint(wanderDestination);

                timeTillWanderDirectionChange -= Time.deltaTime;

                //TODO: raycast randomly to check for furthest wall and go there to prevent hitting walls
                //TODO: randomly stop
                //TODO: on wall collision randomly change wander direction
            }
        }
    }

    internal void TakeDamage(int damage)
    {
        if (!Dead)
        {

            if (armor > 0)
            {
                armor -= damage;
            }
            else if (health > 0)
            {
                health -= damage;
            }

            if(Dead)
            {
                // TODO: death animation
                print("Enemy died");

                rb.velocity = Vector2.zero;
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

        Vector2 fireDirection = (targetPoint - (Vector2)shootingOriginPoint.position).normalized;

        //fire towards given point
        weaponToFire.Fire(shootingOriginPoint.position, fireDirection);

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

    public void MoveTowardsPoint(Vector2 targetPoint)
    {
        Vector3 dir = (targetPoint - (Vector2)transform.position).normalized;
        rb.velocity = dir * speed;

        //enable running animation
        legsAnimator.SetBool(RUNNING_ANIMATION_PARAMETER, true);

        //rotate legs in the direction of travel
        float moveAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        legsAnimator.gameObject.transform.rotation = Quaternion.AngleAxis(moveAngle, Vector3.forward);
     
    }

    public void StopMoving()
    {
        rb.velocity = Vector2.zero;

        //disable running animation
        legsAnimator.SetBool(RUNNING_ANIMATION_PARAMETER, false);
    }

    public void LookTowardsPoint(Vector2 targetPoint)
    {
        Vector3 dir = (targetPoint - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        torsoAnimator.gameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public bool PlayerInFireRange
    {
        get
        {
            return Vector2.Distance(transform.position, player.transform.position) <= GetActiveWeapon().range * fireRangeCheckModifier;
        }
    }

    public bool SeesPlayer
    {
        get
        {
            bool withinDistance = Vector2.Distance(transform.position, player.transform.position) <= playerDetectionDistance;


            if (withinDistance)
            {
                //cast a ray to player and see if it hits wall or player first
                Vector2 dir = (player.transform.position - transform.position).normalized;

                int layerMask = LayerMask.GetMask("Player", "Wall");

                if (Physics2D.Raycast(transform.position, dir, Mathf.Infinity, layerMask).collider.tag == "Player")
                {
                    return true;
                }
            }

            return false;
        }
    }

    public bool Dead
    {
        get
        {
            return health <= 0;
        }
    }
}
