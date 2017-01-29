using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class JumpButton : MonoBehaviour,IPointerDownHandler
{
	/// <summary>
	/// Occurs when on pointer down handler.
	/// </summary>
	public event Action OnDownHandler;

	// Use this for initialization
	void Start ()
	{

	}

	/// <summary>
	/// Raises the pointer down event.
	/// </summary>
	/// <param name="eventData">Event data.</param>
	public void OnPointerDown (PointerEventData eventData)
	{
		OnDownHandler.Invoke ();
	}
}