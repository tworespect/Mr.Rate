using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanEnemy : EnemyBase {


	[SerializeField]
	private float _moveForce;
	[SerializeField]
	public GameObject mainCharacter;
	[SerializeField]
	private int _receiveAtackNum;
	[SerializeField]
	private float approachDistance;
	[SerializeField]
	private float destroyDistance;

	[SerializeField]
	private int spriteIndex = 0;

	[SerializeField]
	// エディタ上からアニメーション用のスプライトを必要数渡す（並び順でアニメーションする
	public Sprite[] walkSprites;

	[SerializeField]
	// キャラクターにアタッチされているSpriteRendererを渡す
	public SpriteRenderer spriteRenderer; 

	[SerializeField]
	private float timeCount = 0.0f;
	[SerializeField]
	private float interval = 0.01f;
	[SerializeField]
	private BusinessCard _businessCardPrefab;

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

			_rigidbody2d.AddForce (Vector2.left * _moveForce);

		}

		if (x > destroyDistance) {

			Destroy (this.gameObject);

		}

		timeCount += Time.deltaTime;

		if (timeCount > interval) {

			spriteIndex = (spriteIndex + 1) % walkSprites.Length;

			spriteRenderer.sprite = walkSprites [spriteIndex];

			timeCount = 0.0f;
		}

	
			
			BusinessCard b = Instantiate (_businessCardPrefab);
			//カードの出現位置をプレイヤーの少し前の位置に設定
			Vector3 cardPos = transform.TransformPoint (new Vector3 (-0.2f, 0)); 
			//位置を設定
			b.transform.position = cardPos;

			b.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-100f, 0));


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