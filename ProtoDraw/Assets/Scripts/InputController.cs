using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
	{

	public SwipeController swipeController;
	public DrawController drawController;

	private enum InputMode
		{
		Locked = 0,
		Swiping = 1,
		Drawing = 2
		}

	[SerializeField]
	private InputMode inputMode = InputMode.Locked;


	// Update is called once per frame
	void Update()
		{

		switch (inputMode)
			{
			case InputMode.Locked:
				break;
			case InputMode.Drawing:
				drawController.DoUpdate();
				break;
			case InputMode.Swiping:
				swipeController.DoUpdate();
				break;
			}

		}


	}
