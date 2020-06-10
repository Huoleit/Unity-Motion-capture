using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigBone {
    public GameObject gameObject;
    public HumanBodyBones bone;
    Animator animator;

    public RigBone(GameObject g, HumanBodyBones b){
        gameObject = g;
        bone = b;
        animator = g.GetComponent<Animator>();
        if (animator == null){
            Debug.LogError("No Animator");
            return;
        }
        Avatar avatar = animator.avatar;
        if (avatar == null || !avatar.isHuman || !avatar.isValid){
            Debug.LogError("No Avatar");
            return;
        }
    }

    public void SetLocalRotation(Quaternion q){
        animator.GetBoneTransform(bone).localRotation = q;
    }
	
}
