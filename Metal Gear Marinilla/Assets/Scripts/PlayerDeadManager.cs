using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeadManager : MonoBehaviour {

	void OnCollisionEnter (Collision other)
	{
		if(other.gameObject.CompareTag("enemy"))
		{
			SceneManager.LoadScene(0);
		}
	}

}
