using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFramerate : MonoBehaviour
{
    public int targetFramerate = 60;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = targetFramerate;
    }


}
