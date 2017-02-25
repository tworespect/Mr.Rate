using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour {


	[SerializeField]
	protected Rigidbody2D _rigidbody2d;

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other)
	{
		

		_OnTriggerEnter2D (other);


	}

	protected virtual void _OnTriggerEnter2D(Collider2D other)
	{


	}


}