using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour {

	#region Initialisation

	private Dictionary<string, UnityEvent> eventDictionary;

	private static EventManager eventManager;
	
	public static EventManager Instance 
	{ 
		get {
			if (!eventManager)
				eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;
			// first checks for one in scene, then checks again for error message
			if (!eventManager)
				Debug.LogError("There needs to be one active EventManager in the scene!");
			else
				{
				eventManager.Init();
				}

			return eventManager;
			} 

	}

	void Init() 
		{
		if (eventDictionary == null)
			eventDictionary = new Dictionary<string, UnityEvent>();
		}

		#endregion

		public static void StartListening (string eventName, UnityAction listener)
		{
			UnityEvent thisEvent = null;
			if (Instance.eventDictionary.TryGetValue (eventName, out thisEvent))
				{
					thisEvent.AddListener(listener);
				} 
			else
			{
			thisEvent = new UnityEvent();
			thisEvent.AddListener(listener);
			Instance.eventDictionary.Add(eventName, thisEvent);
			}
		}

		public static void StopListening (string eventName, UnityAction listener)
		{
		if (eventManager == null) return;

		UnityEvent thisEvent = null;

		if (Instance.eventDictionary.TryGetValue (eventName, out thisEvent))
			{
			thisEvent.RemoveListener(listener);
			}
		}

		public static void TriggerEvent (string eventName)
		{
			UnityEvent thisEvent = null;
			if(Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
				{
				thisEvent.Invoke();
				}
		}
	}
