using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour {

	public Color colorOn;

	public Color colorOff;

	public SwitchManager mySwitchManager;

	public string partCode;

	private bool isOn;


	void OnTriggerEnter(Collider other)
	{
		if(!isOn&&other.gameObject.CompareTag("Player"))
		{	
			Debug.Log("Happening");
			isOn = true;
			gameObject.GetComponent<Renderer>().material.color = colorOn;
			GameManager.Instance.SwitchTouched(mySwitchManager, partCode);
		}
	}

	public void SetOff()
	{
		isOn = false;
		gameObject.GetComponent<Renderer>().material.color = colorOff;
	}

}
