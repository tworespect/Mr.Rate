﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	
	[SerializeField]
	private Rigidbody2D _rigidbody2d;
	[SerializeField]
	private MoveButton _rightButton;
	[SerializeField]
	private JumpButton _jumpButton;
	[SerializeField]
	private float _moveForce;
	[SerializeField]
	private float _stopForce;
	[SerializeField]
	private float _jumpForce;
	[SerializeField]
	private float _intromoveForce;


	[SerializeField]
	private GameObject moneyText;
	[SerializeField]
	private float _lineLength;
	[SerializeField]
	private bool _isGround;
	[SerializeField]
	private float _maxSpeed;
	[SerializeField]
	private float _currentSpeed;
	[SerializeField]
	private BusinessCard _businessCardPrefab;
	[SerializeField]
	private float _playerPosion;
	[SerializeField]
	private bool _isBusEnter;
	[SerializeField]
	private SpriteRenderer _playerSprite;
	/// <summary>
	/// 何秒ごとに点滅させるか 
	/// </summary>
	[SerializeField]
	private float _blinkInterval = 0.2f;
	/// <summary>
	/// 点滅させるための時間のカウンター 
	/// </summary>
	[SerializeField]
	private float _blinkSecondCounter;
	[SerializeField]
	private float interval = 0.01f;
	[SerializeField]
	private float timeCount = 0.0f;


	//private Animator animator;

	[SerializeField]
	private int spriteIndex = 0;

	[SerializeField]
	// エディタ上からアニメーション用のスプライトを必要数渡す（並び順でアニメーションする
	public Sprite[] walkSprites;

	[SerializeField]
	// キャラクターにアタッチされているSpriteRendererを渡す
	public SpriteRenderer spriteRenderer; 

	[SerializeField]
	private GameObject cardText;

	[SerializeField]
	private GameObject lifeText;
	[SerializeField]
	private GameObject gameClearText;




	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start ()
	{

	
		_rightButton.OnDownHandler += OnRightButton;
		_rightButton.OnUpHandler += UpRightButton;
		_jumpButton.OnDownHandler += OnJumpButton;



		this.moneyText = GameObject.Find("MoneyText");
		this.cardText = GameObject.Find("CardText");
		this.lifeText = GameObject.Find ("LifeText");
		this.gameClearText = GameObject.Find ("ClearText");


		this.cardText.GetComponent<Text> ().text = UserDataManager.Instance.UserBusinessCardNum.ToString ();
		this.lifeText.GetComponent<Text> ().text = ("x") + UserDataManager.Instance.UserLife.ToString ();
		this.moneyText.GetComponent<Text> ().text = UserDataManager.Instance.UserMoney.ToString ();
	
		//animator = this.gameObject.GetComponent<Animator>();

	}




	/*
	void Walk() {
		animator.SetBool("Ground", true);
	}
*/

	public void Attack()
	{


		if (_isBusEnter) {

			return;

		}

		if (GameManager.Instance.State == GameManager.GameState.INTRO) {
			return;   
		}
		if (GameManager.Instance.State == GameManager.GameState.PAUSE) {
			return;   
		}
		if (GameManager.Instance.State == GameManager.GameState.GAME_OVER) {
			return;   
		}

		if (GameManager.Instance.State == GameManager.GameState.CLEAR) {
			return;   
		}

		if (0 < UserDataManager.Instance.UserBusinessCardNum) {
			UserDataManager.Instance.UserBusinessCardNum -= 1;
			BusinessCard b = Instantiate (_businessCardPrefab);
		

			//カードの出現位置をプレイヤーの少し前の位置に設定
			Vector3 cardPos = transform.TransformPoint (new Vector3 (0.2f, 0)); 
			//位置を設定
			b.transform.position = cardPos;

			b.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (800f, 0));

			this.cardText.GetComponent<Text> ().text = UserDataManager.Instance.UserBusinessCardNum.ToString ();

		}

	}



	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update ()
	{

		if (GameManager.Instance.State == GameManager.GameState.CLEAR) {
			return;   
		}

		//バスと衝突したら
		if (_isBusEnter) {
			//時間をカウント
			_blinkSecondCounter += Time.deltaTime;
			//0.2秒を超えたら
			if (_blinkSecondCounter > _blinkInterval) {
				//０に初期化
				_blinkSecondCounter = 0;
				//Sprite Rendererのアクティブを切り替える
				_playerSprite.enabled = !_playerSprite.enabled;
			}

		}
			

		//線の始点
		Vector3 startPos = transform.position;
		//終点
		Vector3 endPos = transform.position - transform.up * _lineLength;
		//線にLayerがGroundのオブジェクトが接触しているかどうかを判定
		_isGround = Physics2D.Linecast (startPos, endPos, LayerMask.GetMask ("Ground"));    
		//線がSceneビューで見れるようにデバッグ表示
		Debug.DrawLine (startPos, endPos);

		//現在の速度を測定
		_currentSpeed = _rigidbody2d.velocity.x;

		//現在の場所
		_playerPosion = this.transform.position.x;

		if (GameManager.Instance.State == GameManager.GameState.INTRO) {
		
			_rigidbody2d.AddForce (Vector2.right * _intromoveForce);

			timeCount += Time.deltaTime;

			if (timeCount > interval) {

				spriteIndex = (spriteIndex + 1) % walkSprites.Length;

				spriteRenderer.sprite = walkSprites [spriteIndex];

				timeCount = 0.0f;
			}


		}

		}

	/// Blinks the end.
	/// </summary>




	void OnTriggerEnter2D(Collider2D other) {

		if (GameManager.Instance.State == GameManager.GameState.CLEAR) {
			return;   
		}

		if (other.gameObject.tag == "moneyTag") {

			//お金を加算
			UserDataManager.Instance.UserMoney += 1000;

			this.moneyText.GetComponent<Text> ().text = UserDataManager.Instance.UserMoney.ToString ();

			Destroy (other.gameObject);

		}else if (other.gameObject.tag == "EnemyTag") {
			//バスと衝突
			_isBusEnter = true;
			//２秒後にBlinkEndを呼ぶ
			Invoke ("BlinkEnd", 3.0f);	
		}else if (other.gameObject.tag == "BuildTag"){
			
			this.gameClearText.GetComponent<Text> ().text = "出勤！！" ;
			Destroy (this.gameObject);

			GameManager.Instance.SetState (GameManager.GameState.CLEAR);

			SceneManager.LoadScene("StageSlectScene");

			//第一引数にクリアしたステージのナンバーを入れる
			UserDataManager.Instance.StageClear(1);
		}



	}

	private void BlinkEnd ()
	{
		_playerSprite.enabled = true;

		_isBusEnter = false;
	}




	private void OnRightButton ()
	{

		if (_isBusEnter) {
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
			_rigidbody2d.AddForce (Vector3.left * _stopForce);
		}
		if (GameManager.Instance.State == GameManager.GameState.CLEAR) {
			return;   
		}

		//_rigidbody2d.AddForce (Vector2.right * _moveForce);

		//最大速度と現在速度の差分(絶対値Abs)
		float diff = Mathf.Abs (_maxSpeed - _rigidbody2d.velocity.x);
		//0 ~ 1の値が入る。現在のスピードが最高速度に近づくほどcoefficientの値は0に近づく。
		float coefficient = Mathf.Min (diff, 1); 
		//与える力 
		Vector3 addForce = transform.right * _moveForce * coefficient;
		//力を与える
		_rigidbody2d.AddForce (addForce);


		if (_currentSpeed > 11) {


			_rigidbody2d.AddForce (Vector3.left * _stopForce);


		}



		timeCount += Time.deltaTime;

		if (timeCount > interval) {

			spriteIndex = (spriteIndex + 1) % walkSprites.Length;

			spriteRenderer.sprite = walkSprites [spriteIndex];

			timeCount = 0.0f;
		}
	

}






	private void UpRightButton ()

	{


		//_rigidbody2d.velocity = Vector2.zero;

	}




	private void OnJumpButton ()
	{

		if (_isBusEnter) {

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

		if (_isGround) {
			
			_rigidbody2d.AddForce (Vector2.up * _jumpForce);
		}

	}

	}