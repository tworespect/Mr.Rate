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
	private float _jumpForce;
	[SerializeField]
	private GameObject timeText;
	[SerializeField]
	private GameObject gameOverText;
	[SerializeField]
	private GameObject moneyText;
	[SerializeField]
	private int money = 0;


	[SerializeField]
	private float time = 60.0f;
	[SerializeField]
	private Image timeImage10;
	[SerializeField]
	private Image timeImage1;



	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start ()
	{
		_rightButton.OnDownHandler += OnRightButton;
		_jumpButton.OnDownHandler += OnJumpButton;


		this.timeText = GameObject.Find("TimeText");
		this.gameOverText = GameObject.Find("GameOverText");
		this.moneyText = GameObject.Find("MoneyText");

	}




	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update ()
	{

		if (0 < time) {
			time -= Time.deltaTime;
		}

		this.timeText.GetComponent<Text> ().text =  Mathf.CeilToInt(time).ToString();

		if (time < 0) {

			this.gameOverText.GetComponent<Text> ().text = "遅刻！！！" ;

			int time10 = Mathf.CeilToInt(time) / 10;
			int time1 = Mathf.CeilToInt(time) % 10;
	

		}


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
		_rigidbody2d.AddForce (Vector2.right * _moveForce);
	}



	private void OnJumpButton ()
	{
		_rigidbody2d.AddForce (Vector2.up * _jumpForce);
	}
}