using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTankController : MonoBehaviour
{
    public float secondsRestores = 3;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //TODO: regactor to add and sell oxygen through methods
            collision.gameObject.GetComponent<PlayerController>().oxygenSeconds += secondsRestores;
            Destroy(this.gameObject);
        }

    }
}
