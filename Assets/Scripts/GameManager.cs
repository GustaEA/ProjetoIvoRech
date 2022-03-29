using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] PlayerMovement[] heros = new PlayerMovement[2];
	[SerializeField] bool heroChangeBool = false;
	
	void Start()
	{
		heros[0].enabled = true;
		heros[1].enabled = false;
	}
	
	void Update()
	{
		HeroChange();
		
		if(Input.GetKeyDown(KeyCode.E))
		{
			if(heroChangeBool == false)
			{
				heroChangeBool = true;
			}
			else if (heroChangeBool == true
			)
			{
				heroChangeBool = false;
			}
		}
	}
	
	void HeroChange()
	{
		if (heroChangeBool == false)
		{
			heros[0].enabled = true;
			heros[1].enabled = false;
		}
		else
		{
			heros[0].enabled = false;
			heros[1].enabled = true;
		}
	}
}
