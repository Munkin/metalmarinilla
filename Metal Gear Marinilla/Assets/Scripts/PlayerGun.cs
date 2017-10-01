using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGun : MonoBehaviour {

	public GameObject prefBullet;

	public Transform shootPosition;

	public float speedOfBullet;

	public int ammo;

	public Text ammoText;

	public float timeOfSlowTime;

	public GameObject SlowTimeObject;

	private bool isSlowTime;

	private float elapsedTime;


	// Use this for initialization
	void Start () {
		ammoText.text = "Bullets " + ammo;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.F))	
		{
			ShootBullet();
		}

		if(Input.GetKeyDown(KeyCode.T))
		{
			SlowTime();
		}

		if(isSlowTime)
		{	
			if(elapsedTime<timeOfSlowTime)
				elapsedTime += Time.deltaTime;
			else
			{
				SlowTimeObject.SetActive(false);
				elapsedTime = 0;
				isSlowTime = false;
				Time.timeScale = 1f;
			}
		}


	}

	public void ShootBullet ()
	{
		if(ammo<=0)
			return;

		GameObject tempBullet = Instantiate(prefBullet,shootPosition.position,shootPosition.rotation);
		tempBullet.transform.SetParent(null);
		tempBullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*speedOfBullet);

		ammo--;

		ammoText.text = "Bullets " + ammo;
	}

	public void SlowTime()
	{
		if(!isSlowTime)
		{
			SlowTimeObject.SetActive(true);
			Time.timeScale = 0.3f;
			isSlowTime = true;
		}
				
	}


}
