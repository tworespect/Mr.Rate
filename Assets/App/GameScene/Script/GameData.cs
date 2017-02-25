using UnityEngine;
using System.Collections;

	public sealed class GameData 
	{
		// SingletoneのInstance生成
		private static GameData instance_ = new GameData();

		// プレイヤーLifeの初期値
		private int playerLife = 3;

		// playerLife にアクセスするためのプロパティ
		public static int PlayerLife { get { return instance_.playerLife; } set { instance_.playerLife = value; } }
	}
	
/*
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

*/