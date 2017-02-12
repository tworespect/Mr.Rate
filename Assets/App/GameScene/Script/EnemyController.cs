using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyController : MonoBehaviour {

	[SerializeField]
	private Rigidbody2D _rigidbody2d;
	[SerializeField]
	private float _move2Force;
	[SerializeField]
	public GameObject mainCharacter;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		// 念のためNullチェック
		if( mainCharacter != null ) {

			// メインキャラクターのX座標が10未満
			if( mainCharacter.transform.position.x > 5.0f ) {
				
				_rigidbody2d.AddForce (Vector2.left * _move2Force);
			}
		}

		if (this.transform.position.x < -10) {

			Destroy (this.gameObject);

		}

	}


	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "MainTag") {

			Destroy (this.gameObject);
			
		} else if (other.gameObject.tag == "CardTag") {



				Destroy (this.gameObject);
			}
				


	}


}
