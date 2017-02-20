using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

	[SerializeField]
	private Player _player;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		if (GameManager.Instance.State != GameManager.GameState.PLAY) {

			return;

		}

		transform.localPosition = new Vector3 (
			_player.transform.localPosition.x +5,
			transform.localPosition.y,
			transform.localPosition.z);
	}
}