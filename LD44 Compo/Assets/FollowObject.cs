using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{

    public GameObject objectToFollow;

    private void LateUpdate()
    {
        //preserve z so camera won't fall through round and cut everything from view
        transform.position = new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y,transform.position.z);
    }
}
