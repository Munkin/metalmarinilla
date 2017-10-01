using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrulla : MonoBehaviour, IEnemyes {
	
	public Transform[] path;

	public NavMeshAgent myAgent;

	public float limitDistance;

	private bool isFollowing;

	private Transform target;

	private int currentWaypoint;

	// Use this for initialization
	void Start () {

		myAgent.SetDestination(path[currentWaypoint].position);

	}

	void OnTriggerEnter (Collider other)
	{
		
		if(other.gameObject.CompareTag("Player"))
		{
			Debug.Log("Player is in ranger");
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
			float distanceOfBase = (path[currentWaypoint].position-transform.position).magnitude;
			if(distanceOfBase>=limitDistance)
			{
				myAgent.SetDestination(path[currentWaypoint].position);
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
					myAgent.SetDestination(path[currentWaypoint].position);
				}
			}

		}else
		{
			float distanceOfWaypoint = (path[currentWaypoint].position-transform.position).magnitude;
			if(distanceOfWaypoint<1f)
			{
				currentWaypoint++;
				if(currentWaypoint>=path.Length)
				{
					currentWaypoint = 0;
				}
				myAgent.SetDestination(path[currentWaypoint].position);
			}

			/*float distanceOfPlayerF = (player.position-transform.position).magnitude;

			if(distanceOfPlayerF<distanceToFollowePlayer)
			{
				isFollowing = true;
			}*/

		}
		
	}
}
