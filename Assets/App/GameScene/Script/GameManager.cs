using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
	// <summary>
	/// ゲームの状態の列挙型
	/// </summary>
	public enum GameState
	{
		NONE,
		PLAY,
		PAUSE,
		GAME_OVER
	}


	/// <summary>
	/// The state.
	/// </summary>
	[SerializeField]
	private GameState _state;

	public GameState State {
		get{ return _state; }
	}

	/// <summary>
	/// Start this instance.
	/// </summary>
	private void Start ()
	{
		//初期状態はPLAY
		_state = GameState.PLAY;
	}

	/// <summary>
	/// 状態を設定する
	/// </summary>
	/// <param name="state">State.</param>
	public void SetState (GameState state)
	{
		_state = state;
	}
}