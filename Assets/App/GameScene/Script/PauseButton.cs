using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	//ポーズボタンが押された時に呼ばれるメソッド
	public void OnClickPauseButton()
	{
		//ゲームマネージャーにPauseのStateを設定
		GameManager.Instance.SetState(GameManager.GameState.PAUSE);
	}



}
