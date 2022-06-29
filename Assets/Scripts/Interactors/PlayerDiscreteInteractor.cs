using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiscreteInteractor : MonoBehaviour
{
    [SerializeField] private LayerMask PickupMask;

    [SerializeField] private float PickupRange = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray CameraRay = gameObject.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask))
            {
                try
                {
                    HitInfo.collider.gameObject.GetComponent<DiscreteInteractor>().Next();
                    HitInfo.collider.gameObject.GetComponent<DiscreteInteractor>().Rotate();
                }
                catch
                {

                }
            }
        }
        
    }
}
