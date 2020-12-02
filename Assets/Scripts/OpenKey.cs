using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKey : MonoBehaviour
{
	public float smooth = 2.0f;
	public float OpenAngle = 90.0f;



	private Vector3 defaultRot;
	private Vector3 openRot;
	private bool open;
	private bool enter;

	// Use this for initialization
	void Start()
	{

		defaultRot = transform.eulerAngles;
		openRot = new Vector3(defaultRot.x, defaultRot.y , defaultRot.z + OpenAngle);
	}

	// Update is called once per frame
	void Update()
	{
		if (open)
		{

			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
		}
		else
		{

			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);

		}
		if (Input.GetKeyDown(KeyCode.E) && enter)
		{
			open = !open;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
		{
			enter = true;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.tag == "Player")
		{
			enter = false;
		}
	}
}
