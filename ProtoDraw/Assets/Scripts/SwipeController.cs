using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour {

	private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
	private bool isDragging;
	private Vector2 startTouch, swipeDelta;

	public float dzRadious = 100f; // radious of swipe sense dead zone

	public Vector2 SwipeDelta { get { return swipeDelta; } }


	public bool Tap				{ get { return tap; } }
	public bool SwipeLeft		{ get { return swipeLeft; } }
	public bool SwipeRight		{ get { return swipeRight; } }
	public bool SwipeUp			{ get { return swipeUp; } }
	public bool SwipeDown		{ get { return swipeDown; } }
	
	// Update is called once per frame
	public void DoUpdate () 
	{
		// reset all flags
		tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

		#region Standalone Input
		if (Input.GetMouseButtonDown(0))
			{ // click
			tap = true;
			isDragging = true;
			startTouch = Input.mousePosition;
			}
		else if (Input.GetMouseButtonUp(0))
			Reset();

		#endregion
		
		#region Mobile Input
		if (Input.touches.Length > 0 )
		{
			if (Input.touches[0].phase == TouchPhase.Began)
			{ // start touch
				tap = true;
				isDragging = true;
				startTouch = Input.touches[0].position;
			}
			else if (Input.touches [0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
			{
				Reset();
			}
		}
		#endregion

		// Calculate the distance
		swipeDelta = Vector2.zero;

		if (isDragging == true)
		{
			if (Input.touches.Length > 0)
				swipeDelta = Input.touches[0].position - startTouch;
			else if (Input.GetMouseButton(0))
				swipeDelta = (Vector2)Input.mousePosition - startTouch;
		}

		// Did we cross the deadzone?
		if (swipeDelta.magnitude > dzRadious){

			// which direction?
			float x = swipeDelta.x;
			float y = swipeDelta.y;
			if (Mathf.Abs (x) > Mathf.Abs(y))
			{
				// Left or right
				if (x < 0)
					swipeLeft = true;
				else
					swipeRight = true;
			}
			else
			{
				// up or down
				if (y < 0)
					swipeDown= true;
				else
					swipeUp = true;
				}

			Reset();
		}
	}

	public void Reset()
		{
		startTouch = swipeDelta = Vector2.zero;
		isDragging = false;
		}
	}
