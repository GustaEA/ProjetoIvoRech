using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHeroes : MonoBehaviour
{
    [SerializeField] GameObject[] heroes = new GameObject[2];
	[SerializeField] bool heroChangeBool;
	bool heroOne;
	bool heroTwo;
	
	void Start()
	{
		heroChangeBool = false;		
	}
	
	void Update()
	{
		CheckHeroBool();
		HeroActivated();
		if(Input.GetKeyDown(KeyCode.E))
		{
			ChangeHeroesBool();
		}
	}

	private void ChangeHeroesBool()
	{
		if (heroChangeBool == false)
		{
			heroChangeBool = true;
		}
		else if (heroChangeBool == true)
		{
			heroChangeBool = false;
		}
	}

	void CheckHeroBool()
	{
		if(heroChangeBool == true)
		{
			heroTwo = true;
			heroOne = false;
		}
		else
		{
			heroOne = true;
			heroTwo = false;
		}
	}
	
	void HeroActivated()
	{
		heroes[0].GetComponent<PlayerMovement>().EnableMovement(heroOne);
		heroes[0].GetComponent<MeleeWeapon>().EnableMeleeWeapon(heroOne);
		
		heroes[1].GetComponent<PlayerMovement>().EnableMovement(heroTwo);
		heroes[1].GetComponent<RangeWeapon>().EnableRangeWeapon(heroTwo);
	}
}
