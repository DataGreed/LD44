using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 1.0f;
    public Weapon primaryWeapon;
    public Weapon secondaryWeapon;

    void FixedUpdate()
    {   
        // update speed based on movement input
        Vector2 moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        rb.velocity = moveDirection * speed;

        //rotate towards mouse cursor
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if(Input.GetButton("Fire1"))
        {
            Fire();
        }
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

        //fire towards cursor
        weaponToFire.Fire(transform.position, (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized);

    }
}
