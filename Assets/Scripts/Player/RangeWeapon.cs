using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : MonoBehaviour
{
	[SerializeField] Transform firePoint;
	[SerializeField] GameObject bulletPrefab;

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.F))
		{
			Shoot();
		}
	}
	
	void Shoot()
	{
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
