using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guardia : MonoBehaviour, IEnemyes {

	public NavMeshAgent myAgent;

	public Transform guardiaBase;

	public float limitDistance;

	private bool isFollowing;

	private Transform target;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			target = other.transform;
			myAgent.SetDestination(target.position);
			isFollowing = true;
		}

		if(other.gameObject.CompareTag("bullet"))
		{
			gameObject.SetActive(false);
		}
	}


	public void SetPlayerTarget(Transform player)
	{
		float distanceOfPlayerCall = (player.position - transform.position).magnitude;
		if(distanceOfPlayerCall<limitDistance)
		{
			target = player;
			myAgent.SetDestination(target.position);
			isFollowing = true;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(isFollowing)
		{
			float distanceOfBase = (guardiaBase.position-transform.position).magnitude;
			if(distanceOfBase>=limitDistance)
			{
				myAgent.SetDestination(guardiaBase.position);
				isFollowing = false;
			}else
			{
				float distanceOfPlayer = (target.position-transform.position).magnitude;
				if(distanceOfPlayer>1)
				{
					myAgent.SetDestination(target.position);
				}else
				{
					isFollowing = false;
					myAgent.SetDestination(guardiaBase.position);
				}
			}

		}
		
	}
}
