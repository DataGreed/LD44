using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 1.0f;
    public Weapon primaryWeapon;    //don't use prefabs here, they won;t work.
    public Weapon secondaryWeapon;
    public Transform shootingOriginPoint;

    public Animator torsoAnimator;
    public Animator legsAnimator;

    public const string FIRING_WEAPON_ANIMATION_PARAMETER= "firingWeapon";
    public const string RUNNING_ANIMATION_PARAMETER = "running";

    public int health = 1;
    public int armor = 1;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   //TODO: move to start or init
    }

    void FixedUpdate()
    {
        if (Dead)
        {
            return;
        }

        // update speed based on movement input
        Vector2 moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        rb.velocity = moveDirection * speed;

        //rotate towards mouse cursor
        Vector3 dir = GetMouseDirection();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg -90;
        torsoAnimator.gameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //fire if the fire button is pressed
        if(Input.GetButton("Fire1"))
        {
            Fire();
        }
        else
        {
            //set torso animation to idle if not firing
            torsoAnimator.SetInteger(FIRING_WEAPON_ANIMATION_PARAMETER, 0);
        }

        //enable/disable running animation
        // we compare to epsilon, not to zero, so we don't get any floating points errors
        if (System.Math.Abs(moveDirection.x) > Mathf.Epsilon || System.Math.Abs(moveDirection.y) > Mathf.Epsilon)
        {
            legsAnimator.SetBool(RUNNING_ANIMATION_PARAMETER, true);

            //rotate legs in the direction of travel
            float moveAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
            legsAnimator.gameObject.transform.rotation = Quaternion.AngleAxis(moveAngle, Vector3.forward);
        }
        else
        {
            legsAnimator.SetBool(RUNNING_ANIMATION_PARAMETER, false);
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

            if (Dead)
            {
                // TODO: death animation
                print("Player died");
                rb.velocity = Vector2.zero;
                // TODO: game over
            }
        }
    }

    Vector3 GetMouseDirection()
    {
        return (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized;
    }

    void Fire()
    {
        Weapon weaponToFire = primaryWeapon;

        if (secondaryWeapon)
        {
            if(secondaryWeapon.ammoLeft>0)
            {
                weaponToFire = secondaryWeapon;
            }
        }

        // choose proper animation for primary or secondary weapon
        // FIXME: don;t assume that primary is always a pistol
        if (weaponToFire==primaryWeapon)
        {
            torsoAnimator.SetInteger(FIRING_WEAPON_ANIMATION_PARAMETER, 1);
        }
        else
        {
            torsoAnimator.SetInteger(FIRING_WEAPON_ANIMATION_PARAMETER, 2);
        }

        //fire towards cursor
        weaponToFire.Fire(shootingOriginPoint.position, GetMouseDirection());

    }

    public bool Dead
    {
        get
        {
            return health <= 0;
        }
    }
}
