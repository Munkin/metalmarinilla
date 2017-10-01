using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour {

	public string codeToAcces;

	public GameObject theDoor;

	public int puzzleId;

	public Switches[] mySwitches;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CheckSecuence(Queue<string> cola)
	{
		if(cola.Count<codeToAcces.Length)
			return;

		string actualCombination = "";
		while(cola.Count>0)
		{
			actualCombination += cola.Dequeue();
			Debug.Log(actualCombination);
		}

		if(codeToAcces.Equals(actualCombination))
		{
			theDoor.SetActive(false);
		}else
		{
			SetAllButtonsOff();
		}

	}

	public void SetAllButtonsOff ()
	{
		foreach(Switches temp in mySwitches)
		{
			temp.SetOff();
		}
	}
}
