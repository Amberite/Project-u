using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTest : MonoBehaviour {

	public SwipeController swipeController;
	private Vector3 desiredPosition;


	void OnDrawGizmosSelected()
		{
		// draw dzRadious gizmo
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(this.transform.position, swipeController.dzRadious / 80);

		}

	// Update is called once per frame
	void Update () {
		if (swipeController.SwipeLeft)
			{
			desiredPosition += Vector3.left;
			Debug.Log("Swipe left");
			}
		else if (swipeController.SwipeRight)
			{
			desiredPosition += Vector3.right;
			Debug.Log("Swipe right");
			}
		else if (swipeController.SwipeUp)
			{
			desiredPosition += Vector3.up;
			Debug.Log("Swipe up");
			}
		else if (swipeController.SwipeDown)
			{
			desiredPosition += Vector3.down;
			Debug.Log("Swipe down");
			}

		gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, desiredPosition, 3f * Time.deltaTime);

		if (swipeController.Tap)
		{
			Debug.Log("Tap!");
		}


	}
}
