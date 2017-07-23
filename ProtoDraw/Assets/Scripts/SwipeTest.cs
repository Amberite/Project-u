using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTest : MonoBehaviour {

	public SwipeController swipeController;
	
	[SerializeField]
	private PlayerMovement pm;


	// Update is called once per frame
	void Update () {

		if (pm.Agent.isStopped && pm.Agent.isActiveAndEnabled)
			{

			if (swipeController.SwipeLeft)
				{
				if (pm.CurrentNode.wNode != null)
					{
					pm.MoveToNode(pm.CurrentNode.wNode);
					}
				else
					{
					Debug.Log("Swiped: Can't go west, no link");
					}

				}
			else if (swipeController.SwipeRight)
				{
				if (pm.CurrentNode.eNode != null)
					{
					pm.MoveToNode(pm.CurrentNode.eNode);
					}
				else
					{
					Debug.Log("Swiped: Can't go east, no link");
					}
				}
			else if (swipeController.SwipeUp)
				{
				if (pm.CurrentNode.nNode != null)
					{
					pm.MoveToNode(pm.CurrentNode.nNode);
					}
				else
					{
					Debug.Log("Swiped: Can't go north, no link");
					}
				}
			else if (swipeController.SwipeDown)
				{
				if (pm.CurrentNode.sNode != null)
					{
					pm.MoveToNode(pm.CurrentNode.sNode);
					}
				else
					{
					Debug.Log("Swiped: Can't go south, no link");
					}
				}

			}

		if (swipeController.Tap)
		{
			Debug.Log("Tap!");
		}


	}
}
