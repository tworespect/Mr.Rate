using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCountDown : MonoBehaviour
{
	[SerializeField]
	private Text _startCountDownText;

	[SerializeField]
	private float _countDown;

	/// <summary>
	/// The is count down end.
	/// </summary>
	private bool _isCountDownEnd;

	/// <summary>
	/// Start this instance.
	/// </summary>
	private void Start ()
	{
		_countDown = 4.0f;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	private void Update ()
	{
		if (_isCountDownEnd) {
			return;
		}

		_countDown -= Time.deltaTime;

		if (_countDown >= 1) {
			//_countDownを整数化して文字列にする
			_startCountDownText.text = ((int)_countDown).ToString ();
		} else if (_countDown >= 0) {
			_startCountDownText.text = "START!";            
		} else {
			_startCountDownText.text = "";
			_isCountDownEnd = true;
			GameManager.Instance.SetState (GameManager.GameState.PLAY);
		}

	}
}