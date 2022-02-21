using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapColor : MonoBehaviour, IInteractable
{
    IInteractable interactable;
	public GameObject text;
    public Material material;
    public bool check = false;
    public bool fcolor = false;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
    if (check)
    {
        Interact();
        check = false;
        }
    }
    public void Interact()
    {
        material.color= fcolor? Color.green: Color.red;
        fcolor = !fcolor;
		text.SetActive(!text.activeSelf);
        Debug.Log("Cube interact");
    }
}
