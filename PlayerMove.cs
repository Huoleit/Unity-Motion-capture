using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float velocity = 1.3f;
    private CharacterController characterController;
	// Use this for initialization
	void Start () {
        characterController = gameObject.GetComponent<CharacterController>();

	}
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(h, 0, v);
        moveDirection.y += Physics.gravity.y;
        if (characterController.isGrounded){
            moveDirection = new Vector3(h, 0, v);
        }
        //Debug.Log(h);
        characterController.Move(velocity * Time.deltaTime * moveDirection);
	}
}
