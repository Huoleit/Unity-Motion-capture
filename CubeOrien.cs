using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeOrien : MonoBehaviour
{

    // Use this for initialization
    public Orien orien;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = orien.GetOrien();
        if (Input.GetKey(KeyCode.R))
            orien.SetRef();

    }
}
