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


		}




	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag == "moneyTag") {

			//お金を加算
			this.money += 1000;

			this.moneyText.GetComponent<Text> ().text = this.money.ToString();

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

		_rigidbody2d.AddForce (Vector2.right * _moveForce);
			
			

}



	private void UpRightButton ()

	{

		_rigidbody2d.AddForce (Vector2.down * _stopForce);

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