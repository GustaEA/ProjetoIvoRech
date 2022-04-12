using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHeroes : MonoBehaviour
{
	[SerializeField] GameObject[] heroes = new GameObject[2];
	[SerializeField] GameObject heroActive;
	[SerializeField] bool heroChangeBool;
	[SerializeField] Transform waitOrbHero;
	[SerializeField] Transform currentPosition;
	Vector2 offset;
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
		HeroWaitOrbOffset();
		HeroWait();
		ReturnHeroActivated();
		if(Input.GetKeyDown(KeyCode.E))
		{			
			currentPosition.position = heroActive.transform.position;
			ChangeHeroesBool();
			ChangePositions();
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
	
	void HeroWaitOrbOffset()
	{
		if(heroOne == true)
		{
			offset = new Vector2(heroes[0].transform.position.x - 1.2f, heroes[0].transform.position.y + 1f);
			waitOrbHero.transform.position = offset;
		}
		else
		{
			offset = new Vector2(heroes[1].transform.position.x - 1.2f, heroes[1].transform.position.y + 1f);
			waitOrbHero.transform.position = offset;
		}
	}
	
	void HeroWait()
	{
		if(heroOne == true)
		{
			heroes[1].transform.position = waitOrbHero.position;
		}
		else
		{
			heroes[0].transform.position = waitOrbHero.position;
		}
	}	
	
	GameObject ReturnHeroActivated()
	{
		if(heroOne == true)
		{
			heroActive = heroes[0];
		}
		else
		{
			heroActive = heroes[1];
		}
		return heroActive;
	}
	
	void ChangePositions()
	{
		if(heroOne == true)
		{
			heroes[1].transform.position = currentPosition.transform.position;
		}
		else
		{
			heroes[0].transform.position = currentPosition.transform.position;
		}
	}
}
