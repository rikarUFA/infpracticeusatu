using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapScript : MonoBehaviour
{
    public Transform PlayerTransf;
    void LateUpdate()
    {
        UpdateCamPosition();
    }
    void UpdateCamPosition()
    {
        Vector3 newPos = PlayerTransf.position;
        newPos.y = transform.position.y;
        transform.position = newPos;

        transform.rotation = Quaternion.Euler(90, PlayerTransf.eulerAngles.y, 0);

    }
}
