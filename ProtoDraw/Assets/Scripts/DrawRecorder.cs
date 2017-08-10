using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct LineData 
{ // line data is just a time and position
	public readonly Vector3 position;
	public readonly float timeOfDraw;
	public LineData(Vector3 p)
	{
		position = p;
		timeOfDraw = Time.fixedTime;
	}

}

public class Line 
	{ // a line is made up of line data
	public List<LineData> _lineDataList;

	public Line(List<LineData> lineDataList )
		{
		_lineDataList = lineDataList;
		}
	}

public class DrawRecorder : MonoBehaviour {

	
	List<LineData> currentDataList;

	List<Line> allLines;

	DrawController drawController;

	void Start()
		{
		// get comp DrawController
		}

	void Update()
		{
		//switch(); iterate through dc states and act appropriately
		}

	public void NewLine ()
	{
		// check to see if currentLine is occupied, if so cache and start new line
		if (currentDataList != null)
			Debug.Log("New Line called when line already exists. EndLine needs to be called before NewLine is started");
		else 
		{
			currentDataList = new List<LineData> ();
		}
	}

	public void UpdateLineRecord (Vector3 position) {

		currentDataList.Add(new LineData(position));
	}

	public void EndLine() 
	{ // ends line and saves data to all Lines list

		if (allLines == null)
			allLines = new List<Line>();

		allLines.Add(new Line(currentDataList));
		currentDataList = null;
		Debug.Log("Draw Recorder: this proof" + allLines.Count);
	}

	public void DestroyLastLine() 
	{
	
	}
}
