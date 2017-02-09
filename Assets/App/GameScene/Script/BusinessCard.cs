using UnityEngine;
using System.Collections;

public class BusinessCard : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Destroy(gameObject, 3.0f);
	
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "EnemyTag"){
			
			Destroy(gameObject);
		}
	}

}
