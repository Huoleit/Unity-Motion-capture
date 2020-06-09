using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostTest : MonoBehaviour {

    // Use this for initialization
    SendRecord send;
	void Start () {
        send = gameObject.GetComponent<SendRecord>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.P))
        {
            send.Send("1", "30");
        }
	}
}
