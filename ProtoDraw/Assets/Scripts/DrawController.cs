using UnityEngine;

public class DrawController: MonoBehaviour {

	public GameObject linePrefab;

	[SerializeField] float minLength = 0.1f;
	
	GameObject thisLine;
	Vector3 startPos;

	
	Plane objPlane;
	
	// Use this for initialization
	void Start () {
		objPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);	
	}
	
	// Update is called once per frame
	public void DoUpdate () {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
		{ // user begins touch
			thisLine = (GameObject)Instantiate(linePrefab,
												this.transform.position,
												Quaternion.identity);
			Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			float rayDistance;
			if (objPlane.Raycast(mRay, out rayDistance))
				startPos = mRay.GetPoint(rayDistance);
		}
		else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0))
		{ // user moves finger
			Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			float rayDistance;
			if (objPlane.Raycast(mRay, out rayDistance))
				thisLine.transform.position = mRay.GetPoint(rayDistance);

		}
		else if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended || Input.GetMouseButtonUp(0))
		{ // user releases touch
			if (Vector3.Distance(thisLine.transform.position, startPos) < minLength)
				Destroy(thisLine);
		}



			
	}
}
