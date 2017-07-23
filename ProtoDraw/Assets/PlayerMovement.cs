using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {

	public Node targetNode;

	public Node currentWaypoint;

	NavMeshAgent agent;

	void Start()
		{
		agent = GetComponent<NavMeshAgent>();

		// remove me
		MoveToNode(targetNode);
		}

	void MoveToNode (Node newTarget)
		{
		Debug.Log ("Player Move: New target received: " + newTarget.name);
		targetNode = newTarget;
		agent.destination = targetNode.transform.position;
		}

	public void ArrivedAt(Node arrivalLocation) 
		{ // I've arrived at a location, is it my destination?
		if (arrivalLocation == targetNode)
			{// we have reached our target destination

			}
		else 
		{ // we've arrived at the wrong destination?? whaaat?
			Debug.LogError(" we've arrived at the wrong destination?? whaaat?");
		}
			
		}

	public void ClearTarget () 
		{ // we might never use this?
		targetNode = null;
		}
	}
