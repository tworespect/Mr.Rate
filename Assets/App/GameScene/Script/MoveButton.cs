using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class MoveButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
	[SerializeField]
	private bool _isPointerDown;

	/// <summary>
	/// Occurs when on down handler.
	/// </summary>
	public event Action OnDownHandler;
	public event Action OnUpHandler;


	// Use this for initialization
	void Start ()
	{

	}

	void Update ()
	{
		if (_isPointerDown) {
			OnDownHandler.Invoke ();

		} else{
			OnUpHandler.Invoke();
		}


	}

	public void OnPointerDown (PointerEventData eventData)
	{
		_isPointerDown = true;
	
	}

	public void OnPointerUp (PointerEventData eventData)
	{
		_isPointerDown = false;


	}
}
