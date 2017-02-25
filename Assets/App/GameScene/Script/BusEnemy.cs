using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BusEnemy : EnemyBase {


	[SerializeField]
	private float _move2Force;
	[SerializeField]
	public GameObject mainCharacter;
	[SerializeField]
	private int _receiveAtackNum;
	[SerializeField]
	private float approachDistance;
	[SerializeField]
	private float destroyDistance;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		// 念のためNullチェック
		if (mainCharacter == null) {

			return;

		}
			
		if (GameManager.Instance.State == GameManager.GameState.INTRO) {
			return;   
		}

		//ポーズならリターン
		if (GameManager.Instance.State == GameManager.GameState.PAUSE) {
			return;   
		}
		if (GameManager.Instance.State == GameManager.GameState.GAME_OVER) {
			return;   
		}
		if (GameManager.Instance.State == GameManager.GameState.CLEAR) {
			return;   
		}


		float distance = Vector3.Distance (mainCharacter.transform.position, transform.position);

		float x = mainCharacter.transform.position.x - transform.position.x;


		if (distance < approachDistance) {

			_rigidbody2d.AddForce (Vector2.left * _move2Force);

		}
			
		if (x > destroyDistance) {

			Destroy (this.gameObject);

		}


	}


	protected override void _OnTriggerEnter2D (Collider2D other)
	{
		base._OnTriggerEnter2D (other);
	

		if (other.gameObject.tag == "MainTag") {

			Destroy (this.gameObject);

		} else if (other.gameObject.tag == "CardTag") {
			_receiveAtackNum += 1;

			if (_receiveAtackNum >= 2) {

				Destroy (this.gameObject);
			}
		}		


	}


}