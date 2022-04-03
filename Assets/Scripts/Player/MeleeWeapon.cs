using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
	[SerializeField] Transform swordTransform;
	[SerializeField] float attackRange = 0.5f;
	[SerializeField] LayerMask enemyLayer;
 	void Update()
	{
		if(Input.GetKeyDown(KeyCode.C))
		{
			Attack();
		}
	}
	
	void Attack()
	{
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(swordTransform.position, attackRange, enemyLayer);
		
		foreach (var enemy in hitEnemies)
		{
			Debug.Log("AAAAAAAAAAA");
		}
	}
	
	public void EnableMeleeWeapon(bool weapon)
	{
		if(weapon == false)
		{
			this.enabled = false;
		}
		else
		{
			this.enabled = true;
		}
	}
	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(swordTransform.position, attackRange);
	}
}
