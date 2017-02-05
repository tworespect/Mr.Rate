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
		transform.localPosition = new Vector3 (
			_player.transform.localPosition.x,
			transform.localPosition.y,
			transform.localPosition.z);
	}
}