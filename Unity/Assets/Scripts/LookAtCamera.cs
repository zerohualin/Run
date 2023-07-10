using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Camera cameraToLookAt;

    void Update()
    {
        transform.LookAt(transform.position + cameraToLookAt.transform.rotation * Vector3.forward,
            cameraToLookAt.transform.rotation * Vector3.up);
    }
}