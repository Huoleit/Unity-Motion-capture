using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeOrien : MonoBehaviour
{

    // Use this for initialization
    private Orien orien;
    void Start()
    {
        orien = gameObject.GetComponent<Orien>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = orien.GetOrien();
        if (Input.GetKey(KeyCode.R))
            orien.SetRef();

    }
}
