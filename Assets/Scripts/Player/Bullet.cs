using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] float speed = 20;
	Rigidbody2D rb;
	
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = transform.right * speed;
	}
}
