using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class HMDInfoManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform SpawnPosition;
    public GameObject VRPlayerPrefab;
    public GameObject SimplePlayerPrefab;
    public GameObject AndroidPlayerPrefab;
    void Start()
    {

        if (Application.platform == RuntimePlatform.Android)
        {
            Debug.Log("Boot using Android!");
            Instantiate(AndroidPlayerPrefab, SpawnPosition.position, SpawnPosition.rotation);
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
        else
        {
            if (!XRSettings.isDeviceActive)
            {
                Debug.Log("No Headset");
                Instantiate(SimplePlayerPrefab, SpawnPosition.position, SpawnPosition.rotation);

            }
            else
            {
                Debug.Log("Headset: " + XRSettings.loadedDeviceName);
                Instantiate(VRPlayerPrefab, SpawnPosition.position, SpawnPosition.rotation);
            }
        }

    }

}
