using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePoint : MonoBehaviour {

    // Use this for initialization
    public GameObject AttackPrefab;
    void Start () {
        Destroy(this.gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
       
        
        if (other.name != this.name)
        {
            Score score = other.gameObject.GetComponent<Score>();
            score.Increase(1);
            Debug.Log("add");

            gameObject.SetActive(false);
            GameObject attack = Instantiate(AttackPrefab);
            ParticleSystem p = attack.GetComponent<ParticleSystem>();
            p.Pause();
            float time = p.main.duration;

            attack.transform.position = gameObject.transform.position;
            p.Play();

            Debug.Log(other.name);
            Destroy(attack, time);
        }
           

    }
}
