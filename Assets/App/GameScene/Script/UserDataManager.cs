using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : SingletonMonoBehaviour<UserDataManager>
{
	/// <summary>
	/// ユーザーの持っているお金の数 
	/// </summary>
	private int _userMoney;

	public int UserMoney {
		get { 
			//private の値を返
			return _userMoney;
		}
		set {
			//ローカルストレージに保存
			PlayerPrefs.SetInt (USER_MONEY_KEY, value);
			//値を設定
			_userMoney = value;
		}
	}

	/// <summary>
	/// ユーザーが持っているビジネスカードの枚数 
	/// </summary>
	private int _userBusinessCardNum = 100;



	public int UserBusinessCardNum {
		get { 
			//private の値を返
			return _userBusinessCardNum;
		}
		set {
			//ローカルストレージに保存
			PlayerPrefs.SetInt (USER_BUSINESS_CARD_NUM_KEY, value);
			//値を設定
			_userBusinessCardNum = value;
		}
	}


	/// <summary>
	/// ユーザーが持っているビジネスカードの枚数 
	/// </summary>
	private int _userLife = 3;

	public int UserLife{
		get { 
			//private の値を返
			return _userLife;
		}
		set {
			//ローカルストレージに保存
			PlayerPrefs.SetInt (USER_LIFE_KEY, value);
			//値を設定
			_userLife = value;
		}
	}

	/// <summary>
	/// クリアしたステージのナンバーをリスト形式で保持する変数 
	/// </summary>
	[SerializeField]
	private List<int> _clearStageNumberList;

	/// <summary>
	/// ローカルデータ保存用のキー 
	/// </summary>
	public static readonly string USER_MONEY_KEY = "USER_MONEY_KEY";

	/// <summary>
	/// ローカルデータ保存用のキー 
	/// </summary>
	public static readonly string USER_BUSINESS_CARD_NUM_KEY = "USER_BUSINESS_CARD_NUM_KEY";


	/// <summary>
	/// ローカルデータ保存用のキー 
	/// </summary>
	public static readonly string USER_LIFE_KEY = "USER_LIFE_KEY";

	/// <summary>
	/// ローカルデータ保存用のキー 
	/// </summary>
	public static readonly string CLEAR_STAGE_NUMBER_KEY = "CLEAR_STAGE_NUMBER_KEY";

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start ()
	{
		//シーンを跨いでも削除されない
		DontDestroyOnLoad (gameObject);
		//既に１度でも保存されているか
		if (PlayerPrefs.HasKey (USER_MONEY_KEY)) {
			//ローカルストレージに保存されているユーザーのお金を取得
			_userMoney = PlayerPrefs.GetInt (USER_MONEY_KEY);
		}
		//既に１度でも保存されているか
		if (PlayerPrefs.HasKey (USER_BUSINESS_CARD_NUM_KEY)) {
			//ローカルストレージに保存されているビジネスカードの枚数を取得
			_userBusinessCardNum = PlayerPrefs.GetInt (USER_BUSINESS_CARD_NUM_KEY);
		}

		if (PlayerPrefs.HasKey (USER_LIFE_KEY)) {
			//ローカルストレージに保存されているビジネスカードの枚数を取得
			_userLife = PlayerPrefs.GetInt (USER_LIFE_KEY);
		}
	}
		
/// <summary>
/// Stages the clear.
/// </summary>
/// <param name="stageNumber">Stage number.</param>
public void StageClear (int stageNumber)
{
	//リストにstageNumberが含まれているか
	if (_clearStageNumberList.Contains (stageNumber)) {
		//既にリストにナンバーが存在している
		Debug.Log ("既にクリアしたステージです");
		return;
	}
	//リストに加える
	_clearStageNumberList.Add (stageNumber);
	//ローカルストレージにステージナンバーのリストを保存
	PlayerPrefsUtility.SaveList<int> (CLEAR_STAGE_NUMBER_KEY, _clearStageNumberList);
}

/// <summary>
/// 引数に指定したステージナンバーが既にクリアされているかどうかを返す(クリアされていたらtrueが返る) 
/// </summary>
/// <returns><c>true</c> if this instance is stage clear the specified stageNumber; otherwise, <c>false</c>.</returns>
/// <param name="stageNumber">Stage number.</param>
public bool IsStageClear (int stageNumber)
{
	return _clearStageNumberList.Contains (stageNumber);	
}

}