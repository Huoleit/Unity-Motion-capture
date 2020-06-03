using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orien : MonoBehaviour
{
    private Quaternion orien = Quaternion.identity;
    private Quaternion ref_q = Quaternion.identity;

    public void SetRef()
    {
        ref_q = orien;
    }
    public void SetGloablOrien(Quaternion q)
    {
        orien = ConvertToUnity(q);
    }
    public Quaternion GetOrien()
    {
        return Quaternion.Inverse(ref_q) * orien;
    }
    private Quaternion ConvertToUnity(Quaternion input)
    {
        return new Quaternion(
            input.z,
            -input.x,
            -input.y,
            input.w
        );
    }

}
