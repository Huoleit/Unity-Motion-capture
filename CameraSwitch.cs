using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    // Use this for initialization
    public GameObject front;
    public GameObject back;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            front.SetActive(true);
            back.SetActive(false);
        }
        else if(Input.GetKeyUp(KeyCode.Alpha2))
        {
            front.SetActive(false);
            back.SetActive(true);
        }
	}
}
