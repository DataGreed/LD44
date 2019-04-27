using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float range;
    public int damage;
    public float startingSpeed;
    public Vector2 startingDirection;

    bool shot = false;

    private Rigidbody2D rb;
    Vector2 startPoint;

    /// <summary>
    /// Call to fire this projectile
    /// </summary>
    public void Fire()
    {
        float angle = Mathf.Atan2(startingDirection.y, startingDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        startPoint = transform.position;

        //fire only if not fired yet
        if (!shot)
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = startingDirection * startingSpeed;
            shot = true;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //TODO: detect collisions with enemies, deal damage and destroy


        //TODO: detect collisions with level and destroy

        //check if travelled to far and need to be destroyed
        if (Vector2.Distance(this.transform.position, startPoint) >= range)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Wall")
        {
            Destroy(this.gameObject);
        }
        else if(collision.tag=="Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(this.damage);
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(this.damage);
            Destroy(this.gameObject);
        }
    }
}
