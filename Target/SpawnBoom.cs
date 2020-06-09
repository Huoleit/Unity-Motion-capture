using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoom : MonoBehaviour {

    // Use this for initialization
    public float radius;
    public GameObject PointPrefab;

    private float phi;
    private float theta;
    private float rho;

    void Start () {
        InvokeRepeating("createPoint", 0, 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void createPoint()
    {
        rho = Random.Range(radius * 0.8f, radius);
        theta = Random.Range(2.0f * Mathf.PI / 3.0f, 3.0f * Mathf.PI / 2.0f);
        if (Mathf.Abs(theta - Mathf.PI) < Mathf.PI / 4.0f)
        {
            phi = Random.Range(0, Mathf.PI / 2.0f);
        }
        else
        {
            phi = Random.Range(0, Mathf.PI / 6.0f);
        }

        //rho = radius;
        //theta = Mathf.PI / 2.0f;
        //phi = Mathf.PI / 2.0f;

        Vector3 center = new Vector3(rho * Mathf.Sin(phi) * Mathf.Cos(theta),
                                     rho * Mathf.Sin(phi) * Mathf.Sin(theta),
                                     rho * Mathf.Cos(phi));
        GameObject point = Instantiate(PointPrefab, transform);
        point.transform.localPosition = center;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = new Color(255, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.localPosition, radius);
    }
}
