using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	public Transform GameObject;
	void OnTriggerEnter( Collider other)
	{	
			other.transform.position = GameObject.transform.position;
	}
	

}

