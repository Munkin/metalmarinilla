using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWhenTouch : MonoBehaviour {

	public GameObject winText;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			winText.SetActive(true);
		}
	}

}
