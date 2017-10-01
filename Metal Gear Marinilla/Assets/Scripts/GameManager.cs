using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour {

	private static GameManager instance;

	public static GameManager Instance
	{
		get
		{
			return instance;
		}
	}

	private SwitchManager actualManager;

	private Queue<string> actualCombination;

	private void Awake()
	{	
		actualCombination = new Queue<string>();

		if(instance != null)
			Destroy(gameObject);
		else
			instance = this;
	}

	public void SwitchTouched (SwitchManager sManager, string codePart)
	{
		if(actualManager!=null)
		{
			if(actualManager.puzzleId != sManager.puzzleId)
			{
				actualManager.SetAllButtonsOff();
				actualCombination.Clear();
				actualManager = sManager;
				actualCombination.Enqueue(codePart);
			}else
			{
				actualCombination.Enqueue(codePart);
				actualManager.CheckSecuence(actualCombination);
				
			}
		}else
		{
			actualManager = sManager;
			actualCombination.Enqueue(codePart);
		}
	}

}
