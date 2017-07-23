using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NodeManager : MonoBehaviour {

	[SerializeField]
	Node[] NodesInScene;


	//void ScanForNeighbours() {

	//	NodesInScene = GetComponentsInChildren<Node>();

	//	foreach (Node thisNode in NodesInScene)
	//	{

	//		var nearbyNodes =
	//			from n in NodesInScene
	//			where (Vector3.Distance(thisNode.transform.position, n.transform.position)) < thisNode.scanRadious
	//			select n;

	//		Debug.Log(thisNode.name + " has " + nearbyNodes.Count() + "nodes nearby" );


	//		// build list of neighbour distances?

	//		foreach (Node n in nearbyNodes){
	//			// from nearbyNodes, find northerly neighbours and select closest

	//			Vector2 distance = thisNode.transform.position - n.transform.position;
	//			float x = distance.x;
	//			float y = distance.y;

	//		var northNeighbour =
	//			from n in NodesInScene
	//			where ()
			
			// thisNode.NorthNeighbour =

			// from nearbyNodes, find westerly neighbours and select closest
			// thisNode.WestNeighbour =

			// from nearbyNodes, find easterly neighbours and select closest
			// thisNode.EastNeighbour =

			// from nearbyNodes, find southernly neighbours and select closest
			// thisNode.WestNeighbour =

		//	}
		//}


	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDrawGizmos()
		{
		// for each 
		}
	}
