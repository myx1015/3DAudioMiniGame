﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPos : MonoBehaviour {

	// ----- Public variables ------
	public GameObject Target;		// Sound object
	public OSC osc;					// OSC script
	
	
	// ----- Application start -----
	void Start () {
		
		OscMessage message = new OscMessage();		// Instantiate OSC message object
		message.address = "TriggerOnOff";			// "TriggerOnOff" is used to control DSP ON/OFF at Pure Data
		message.values.Add (1);						// 1 -> ON
		osc.Send (message);							// Send OSC message
		
		OscMessage message2 = new OscMessage();		// Instantiate OSC message object
		message2.address = "Volume";				// "Volume" is an initial volume of sound
		message2.values.Add (45);					// You can change depending on your speakers
		osc.Send (message2);						// Send OSC message
	}

	
	// ----- Loop --------
	void Update () {
		
		// Compute distance between Camera and Sound object
		float howfar = 10 * Vector3.Distance(transform.position,Target.transform.position); 			// change coefficient for better effect if necessary
		
		
		// Compute Azimuth and Elevation

			// Azimuth
		Vector3 direction = transform.InverseTransformDirection ((Target.transform.position-transform.position));
		float azimuth = Mathf.Atan2 (direction.z, direction.x) * Mathf.Rad2Deg;

				// Adjust computed azimuth to the range of earplug in PureData...
		azimuth -= 90;
		
		if (azimuth < 0)
		{
			azimuth += 360;
		}

			// Elevation		
		float elevation = Mathf.Atan2 (direction.y, Mathf.Sqrt(direction.x*direction.x + direction.z * direction.z)) * Mathf.Rad2Deg;
		
				// Adjust computed elevation to the range of earplug in PureData...
		if (elevation < -40)
			elevation = -40;
		else if (elevation > 90)
			elevation = 90;


		// Send OSC Message

			OscMessage messagePos = new OscMessage();	// Instantiate OSC message object
			messagePos.address = "Position";			// "Position" is (distance, azimuth, elevation)
			messagePos.values.Add(howfar);				// Distance
			messagePos.values.Add(azimuth);				// Azimuth
			messagePos.values.Add (elevation);			// Elevation
			osc.Send(messagePos);						// Send Message
	
	}
	
	
	// ---- Application Stop ----
	private void OnDestroy()
	{
		OscMessage message = new OscMessage();		// Instantiate OSC message object
		message.address = "TriggerOnOff";			// "TriggerOnOff" is used to control DSP ON/OFF at Pure Data
		message.values.Add (0);						// 0 -> OFF
		osc.Send (message);							// Send OSC message		
	}
}
//