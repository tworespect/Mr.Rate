using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MojiController : MonoBehaviour {

	[SerializeField]
	private float _move3Force;
	[SerializeField]
	public GameObject mainCharacter3;
	[SerializeField]
	private int _receiveAtackNum3;
	[SerializeField]
	private float approachDistance3;
	[SerializeField]
	private float destroyDistance3;
	[SerializeField]
	private Rigidbody2D _rigidbody2d3;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		// 念のためNullチェック
		if (mainCharacter3 == null) {

			return;

		}



		float distance = Vector3.Distance (mainCharacter3.transform.position, transform.position);

		float x = mainCharacter3.transform.position.x - transform.position.x;


		if (distance < approachDistance3) {

			_rigidbody2d3.AddForce (Vector2.left * _move3Force);

		}

		if (x > destroyDistance3) {

			Destroy (this.gameObject);

		}


	}
}
