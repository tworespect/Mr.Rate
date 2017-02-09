using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	private GameObject timeText;

	[SerializeField]
	private GameObject moneyText;
	[SerializeField]
	private int money = 0;
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




	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start ()
	{
		_rightButton.OnDownHandler += OnRightButton;
		_rightButton.OnUpHandler += UpRightButton;
		_jumpButton.OnDownHandler += OnJumpButton;


		this.timeText = GameObject.Find("TimeText");
		this.moneyText = GameObject.Find("MoneyText");

	}


	public void Attack()
	{


		if (GameManager.Instance.State == GameManager.GameState.PAUSE) {
			return;   
		}
		if (GameManager.Instance.State == GameManager.GameState.GAME_OVER) {
			return;   
		}

		BusinessCard b = Instantiate (_businessCardPrefab);
		//カードの出現位置をプレイヤーの少し前の位置に設定
		Vector3 cardPos = transform.TransformPoint (new Vector3 (0.6f, 0)); 
		//位置を設定
		b.transform.position = cardPos;

		b.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (1000f, 0));
	}



	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update ()
	{

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


		}




	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag == "moneyTag") {

			//お金を加算
			this.money += 1000;

			this.moneyText.GetComponent<Text> ().text = this.money.ToString ();

			Destroy (other.gameObject);

		}


			

	}





	private void OnRightButton ()
	{
		//ポーズならリターン
		if (GameManager.Instance.State == GameManager.GameState.PAUSE) {
			return;   
		}
		if (GameManager.Instance.State == GameManager.GameState.GAME_OVER) {
			return;   
		}

		//_rigidbody2d.AddForce (Vector2.right * _moveForce);

		//最大速度と現在速度の差分(絶対値Ads)
		float diff = Mathf.Abs (_maxSpeed - _rigidbody2d.velocity.x);
		//0 ~ 1の値が入る。現在のスピードが最高速度に近づくほどcoefficientの値は0に近づく。
		float coefficient = Mathf.Min (diff, 1); 
		//与える力 
		Vector3 addForce = transform.right * _moveForce * coefficient;
		//力を与える
		_rigidbody2d.AddForce (addForce);
			

}



	private void UpRightButton ()

	{


		//_rigidbody2d.velocity = Vector2.zero;

	}




	private void OnJumpButton ()
	{
		//ポーズならリターン
		if (GameManager.Instance.State == GameManager.GameState.PAUSE) {
			return;      
		}
		if (GameManager.Instance.State == GameManager.GameState.GAME_OVER) {
			return;   
		}

		if (_isGround) {
			_rigidbody2d.AddForce (Vector2.up * _jumpForce);
		}

	}

	}