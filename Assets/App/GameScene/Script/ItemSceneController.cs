using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class ItemSceneController : MonoBehaviour {

	public void toGameScene(){
		SceneManager.LoadScene ("ItemScene");

	}

	public void toselecteScene(){
		SceneManager.LoadScene ("StageSlectScene");

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
