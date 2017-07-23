using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
	{

	public Node TargetNode { get; private set; }

	// this needs to be set in inspector because starting node needs initialising
	[SerializeField]
	Node startingNode;

	public Node CurrentNode { get; private set; }
	public NavMeshAgent Agent { get; private set; }

	bool inTargetArea = false;

	void Start()
		{
		Agent = GetComponent<NavMeshAgent>();
		Agent.isStopped = true;

		// TODO: correct initialising
		if (CurrentNode == null)
			CurrentNode = startingNode;

		}

	public void MoveToNode(Node newTarget)
		{
		Debug.Log("Player Move: New target received: " + newTarget.name);
		TargetNode = newTarget;
		Agent.isStopped = false;
		inTargetArea = false;
		Agent.destination = TargetNode.transform.position;
		}

	public void ArrivedAt(Node arrivalLocation)
		{ // I've arrived at a location, is it my destination?
		if (arrivalLocation == TargetNode)
			{// we have reached our target area - perhaps we can start a coroutine here to tell if we need to stop?
			inTargetArea = true;
			}
		else
			{ // we've arrived at the wrong destination?? whaaat?
			Debug.LogWarning(" we've arrived at the wrong destination?? whaaat?");
			}

		}

	public void ClearTarget()
		{ // we might never use this?
		TargetNode = null;
		Agent.isStopped = true;
		}

	void FixedUpdate()
		{

		if (inTargetArea && TargetNode != null) 
			{
			// Check if we've reached the destination
			if (!Agent.pathPending)
				{
				if (Agent.remainingDistance <= Agent.stoppingDistance)
					{
					if (!Agent.hasPath || Agent.velocity.sqrMagnitude == 0f)
						{

						CurrentNode = TargetNode;
						ClearTarget();
						
						Debug.Log("Yo I'm here");
						}
					}
				}
			}
		}
	}
