using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour 
{
	[SerializeField]
	private Image _selfImage;
	[SerializeField]
	private Sprite _pauseSprite;
	[SerializeField]
	private Sprite _playSprite;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	//ポーズボタンが押された時に呼ばれるメソッド
	public void OnClickPauseButton ()
	{
		//現在の状態がPLAYなら
		if (GameManager.Instance.State == GameManager.GameState.PLAY) {
			_selfImage.sprite = _playSprite;
			//ゲームマネージャーにPauseのStateを設定
			GameManager.Instance.SetState (GameManager.GameState.PAUSE);
		} 
		//ポーズなら
		else if (GameManager.Instance.State == GameManager.GameState.PAUSE) {
			_selfImage.sprite = _pauseSprite;
			//ゲームマネージャーにPauseのStateを設定
			GameManager.Instance.SetState (GameManager.GameState.PLAY);
		}
		//それ以外
		else {
			//何もしない	
		}
	}


}
