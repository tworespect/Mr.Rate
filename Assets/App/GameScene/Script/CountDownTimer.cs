using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
	[SerializeField]
	private float time = 60.0f;
	[SerializeField]
	private Image timeImage10;
	[SerializeField]
	private Image timeImage1;
	[SerializeField]
	private List<Sprite> _numberSpriteList;
	[SerializeField]
	private GameObject gameOverText;


	// Use this for initialization
	void Start ()
	{
		this.gameOverText = GameObject.Find("GameOverText");
	}

	void Update ()
	{

		if (GameManager.Instance.State != GameManager.GameState.PLAY) {

			return;
		}

		if (GameManager.Instance.State == GameManager.GameState.CLEAR) {

			return;
		}


		if (0 < time) {
			time -= Time.deltaTime;
		}
		int time10 = Mathf.CeilToInt (time) / 10;
		int time1 = Mathf.CeilToInt (time) % 10;

		timeImage10.sprite = GetNumberSprite (time10);
		timeImage1.sprite = GetNumberSprite (time1);
	
		if (time < 0) {

			this.gameOverText.GetComponent<Text> ().text = "遅刻！！！" ;
			GameManager.Instance.SetState (GameManager.GameState.GAME_OVER);
	

			}

	
	}
		

	//引数に指定した数字の画像を取得する
	private Sprite GetNumberSprite (int number)
	{
		foreach (Sprite s in _numberSpriteList) {
			if (s.name == number.ToString ()) {
				return s;
			}
		}
		return null;
	}



}