using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campanero : MonoBehaviour {

	private Transform target;

	public float radiusOfCall;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other)
	{
		
		if(other.gameObject.CompareTag("Player"))
		{
			Debug.Log("Player is in ranger");
			target = other.transform;
			DoCallAllEnemies();
		}
	}

	void DoCallAllEnemies()
	{
		Collider[] objectsOfCall = Physics.OverlapSphere(transform.position,radiusOfCall);

		if(objectsOfCall == null)
			return;

		foreach(Collider temp in objectsOfCall)
		{	
			IEnemyes tempEnemy = temp.gameObject.GetComponent<IEnemyes>();
			if(tempEnemy != null)
			{
				tempEnemy.SetPlayerTarget(target);
			}
		}
	}

}
