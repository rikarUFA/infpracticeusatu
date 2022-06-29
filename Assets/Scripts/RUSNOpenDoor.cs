using UnityEngine;
using System.Collections;
using System;

public class RUSNOpenDoor : MonoBehaviour
{

	public float smooth = 2.0f;
	public float DoorOpenAngle = 90.0f;

	public AudioClip OpenAudio;
	public AudioClip CloseAudio;
	private bool AudioS;

	private Vector3 defaultRot;
	private Vector3 openRot;
	private bool open;
	private bool enter;

	// Use this for initialization
	void Start()
	{

		defaultRot = transform.eulerAngles;
		openRot = new Vector3(defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);
	}

	// Update is called once per frame
	void Update()
	{
		if (open)
		{
			if (AudioS == false)
			{
				gameObject.GetComponent<AudioSource>().PlayOneShot(OpenAudio);
				AudioS = true;
			}
			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
		}
		else
		{
			if (AudioS == true)
			{
				gameObject.GetComponent<AudioSource>().PlayOneShot(CloseAudio);
				AudioS = false;
			}
			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);

		}
		if (Input.GetKeyDown(KeyCode.E) && enter)
		{
			open = !open;
		}
	}
	#if UNITY_EDITOR_WIN
	DB dB;
	#endif
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
		{
			enter = true;
			#if UNITY_EDITOR_WIN
            dB.ActualActions(1, 1, 1, 2, "RE", DateTime.Now, "Войти в комнату RUSN");
			#endif
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