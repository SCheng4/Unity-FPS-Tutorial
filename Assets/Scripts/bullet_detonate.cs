using UnityEngine;
using System.Collections;

public class bullet_detonate : MonoBehaviour {

	float lifespan = 1.0f;
	public GameObject explosionEffect;
	public GameObject fireEffect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lifespan -= Time.deltaTime;
		if (lifespan <= 0) {
			Explode ();
		}
	}

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Enemy") {
			collision.gameObject.tag = "Untagged";
			Instantiate(fireEffect, collision.transform.position, Quaternion.identity);
			Instantiate(explosionEffect, collision.transform.position, Quaternion.identity);
		}
	}

	void Explode() {
		Destroy(gameObject);
	}
}
