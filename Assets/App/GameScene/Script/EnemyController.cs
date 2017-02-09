using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyController : MonoBehaviour {

	[SerializeField]
	private Rigidbody2D _rigidbody2d;
	[SerializeField]
	private float _move2Force;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "MainTag") {

			_rigidbody2d.AddForce (Vector2.left * _move2Force);

		}


	}

}
