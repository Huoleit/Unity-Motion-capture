using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigController : MonoBehaviour {

    public GameObject humanoid;
    public Orien orien;
    private RigBone rightLowerArm;

    private float x, y, z;

	
	void Start () {
        rightLowerArm = new RigBone(humanoid, HumanBodyBones.RightLowerArm);

        x = 0;
        y = 0;
        z = 0;
    }
	
	void Update () {
        if (Input.GetKey(KeyCode.R))
            orien.SetRef();

        //if (Input.GetKey(KeyCode.Q))
        //    x -= 10;
        //if (Input.GetKey(KeyCode.W))
        //    x += 10;
        //if (Input.GetKey(KeyCode.A))
        //    y -= 10;
        //if (Input.GetKey(KeyCode.S))
        //    y += 10;
        //if (Input.GetKey(KeyCode.Z))
        //    z -= 10;
        //if (Input.GetKey(KeyCode.X))
        //    z += 10;
        //Quaternion q = Quaternion.Euler(x, y, z);
        //rightLowerArm.SetLocalRotation(q);

        rightLowerArm.SetLocalRotation(orien.GetOrien());

    }
}
