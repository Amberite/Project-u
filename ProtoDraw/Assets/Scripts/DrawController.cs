using UnityEngine;

public class DrawController: MonoBehaviour {

	public GameObject linePrefab;
	public DrawRecorder recorder;

	// to determine if we are dragging (drawing) or just tapping
	[SerializeField] float drawDelay = 0.1f;
	float touchTime = 0f;

	public GameObject thisLine; // TODO: this is gross - fixme
	Vector3 startPos;
	Plane objPlane;

	public enum DrawState
		{
		Stopped = 0,
		Started = 1,
		Continuing = 2
		}

	[SerializeField]
	private DrawState drawState = DrawState.Stopped;

	// Use this for initialization
	void Start () {	
	objPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);	
	}

	// TODO: right now I've tightly coupled DrawRecorder in here with derpy methods.
	// would make much more sense to have a public enum that is updated with different states which an update function in draw recorder checks
	/* 
	 * if DrawController.Started
	 * else if DrawController.Moving
	 * else if DrawController.Stopped
	 * 
	 * perhaps this is a good place for events?
	*/
	
	// Update is called once per frame
	public void DoUpdate () {
		
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
		{ // user begins touch, we don't know if we're drawing yet but we need the coords incase we are 

			touchTime = Time.time;

			// initialise coords
			Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			float rayDistance;
			if (objPlane.Raycast(mRay, out rayDistance))
				startPos = mRay.GetPoint(rayDistance);

			// create new line <
			thisLine = Instantiate(linePrefab,
									this.transform.position,
									Quaternion.identity,
									this.transform);
			// tell recorder to start new recording <
			recorder.NewLine();

			// change state to started <
			drawState = DrawState.Started;


		}
		else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0))
		{ // user moves finger, line renderer moves like a pencil drawn accross screen


			Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			float rayDistance;
			if (objPlane.Raycast(mRay, out rayDistance))
				thisLine.transform.position = mRay.GetPoint(rayDistance);
			
			// update recorder
			recorder.UpdateLineRecord(thisLine.transform.position);
			drawState = DrawState.Continuing;
			}
		else if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended || Input.GetMouseButtonUp(0))
		{ // user releases touch, check to see if it was just a tap


			// end recording
			recorder.EndLine();

			// new way
			if (Time.time - touchTime <= drawDelay)
				{ // then it was just a tap
				Destroy(thisLine);
				// recorder.EraseLastLine();
				}

			drawState = DrawState.Stopped;
		}
		
	}
}
