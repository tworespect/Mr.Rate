using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager: MonoBehaviour {


	[SerializeField]
	private GameObject moneyText;
	[SerializeField]
	private GameObject cardText;
	[SerializeField]
	private GameObject lifeText;

	// Use this for initialization
	void Start () {

		this.moneyText = GameObject.Find("MoneyText");
		this.cardText = GameObject.Find("CardText");
		this.lifeText = GameObject.Find ("LifeText");



		this.moneyText.GetComponent<Text> ().text = UserDataManager.Instance.UserMoney.ToString ();
		this.cardText.GetComponent<Text> ().text = UserDataManager.Instance.UserBusinessCardNum.ToString ();
		this.lifeText.GetComponent<Text> ().text = ("x") + UserDataManager.Instance.UserLife.ToString ();


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
