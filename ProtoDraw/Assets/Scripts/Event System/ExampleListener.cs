using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class ExampleListener : MonoBehaviour
	{

	private UnityAction someListener;

	void Awake()
		{
		// we can populate actions with functions, like this: 
		someListener = new UnityAction(ExampleFunction);
		// when someListener is called, ExampleFunction will be called
		}

	void OnEnable()
		{
		// start listening
		EventManager.StartListening("someEvent", someListener);
		}

	void OnDisable()
		{
		// stop listening
		EventManager.StopListening("someEvent", someListener);
		}

		void ExampleFunction()
		{
		Debug.Log("ExampleFunc was called!");
		}

	}
