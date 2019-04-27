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

    /// <summary>
    /// Call to fire this projectile
    /// </summary>
    public void Fire()
    {
        //TODO: remember originating point to count distance travelled

        //fire only if not fired yet
        if(!shot)
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = startingDirection * startingSpeed;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //TODO: detect collisions with enemies, deal damage and destroy

        //TODO: destroy if travelled to far

        //TODO: detect collisions with level and destroy
    }
}
