using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
	

	public Node nNode; // northern or up Node neighbour
	public Node sNode; // southern or up Node neighbour
	public Node eNode; // eastern or up Node neighbour
	public Node wNode; // western or up Node neighbour

	PlayerMovement playerMov;

	// debug stuff
	private Vector3 linkBoxScale = new Vector3(0.25f, 0.25f, 0.25f);
	public float linkSphereRadious = 0.1f;
	public float distanceMult = 0.5f;

	public void Start()
		{
		playerMov = (PlayerMovement)FindObjectOfType(typeof(PlayerMovement));
		}

	public void PlayerEntered (ArrivalDetector detector)
	{
		// player has entered our zone!
		Debug.Log(this.name + ": player has entered our zone via " + detector.name);
		playerMov.ArrivedAt(this);
	}


	# region Shit ton of debugging stuff, could really do with being in its own goddam script

	void OnDrawGizmos()
		{
		if (nNode != null)
			{
			if (nNode.sNode != this)
				{
				// if my northern neighbours southern neighbour is not me...
				Gizmos.color = Color.red;
				LinkBox(nNode);
				}
			else 
				{
				// it is me
				Gizmos.color = Color.green;
				}
			Gizmos.DrawLine(this.transform.position, nNode.transform.position);
			} 
			else 
			{
			// else Node is null, so signify
			NullSphere(Vector3.forward);
			}
		if (sNode != null)
				{
				if (sNode.nNode != this)
					{
					// if my southern neighbours northern neighbour is not me...
					Gizmos.color = Color.red;
					LinkBox(sNode);
					}
				else
					{
					// it is me
					Gizmos.color = Color.green;
					}
				Gizmos.DrawLine(this.transform.position, sNode.transform.position);
			}
			else
			{
			// else Node is null, so signify
			NullSphere(Vector3.back);
			}

		if (eNode != null)
				{
				if (eNode.wNode != this)
					{
					// if my east neighbours west neighbour is not me...
					Gizmos.color = Color.red;
					LinkBox(eNode);
					}
				else
					{
					// it is me
					Gizmos.color = Color.green;
					}
				Gizmos.DrawLine(this.transform.position, eNode.transform.position);
			}
			else
			{
			// else Node is null, so signify
			NullSphere(Vector3.right);
			}
		if (wNode != null)
				{
				if (wNode.eNode != this)
					{
					// if my northern neighbours southern neighbour is not me...
					Gizmos.color = Color.red;
					LinkBox(wNode);
					}
				else
					{
					// it is me
					Gizmos.color = Color.green;
					}
				Gizmos.DrawLine(this.transform.position, wNode.transform.position);
			}
		else
			{
			// else Node is null, so signify
			NullSphere(Vector3.left);
			}

		}

	void LinkBox(Node neighbour) 
	{
		Vector3 heading = (this.transform.position - neighbour.transform.position).normalized / 1.5f;
		Gizmos.DrawWireCube(this.transform.position - heading, linkBoxScale);
	}

	void NullSphere(Vector3 dir)
		{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(this.transform.position + (dir * distanceMult), linkSphereRadious);
		}

		#endregion
	}
