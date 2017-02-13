using UnityEngine;
using System.Collections;

public class BusinessCard : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Destroy(gameObject, 1.0f);
	
	}

	void  OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "EnemyTag"){
			
			Destroy(this.gameObject);
		}
	}

}
