using UnityEngine;
using Cinemachine;

public class CameraBoundControl : MonoBehaviour
{
    public Transform CameraVerticalBound;
    public CinemachineBrain CinemachineBrain;

    void Update()
    {
        if(transform.localPosition.y < CameraVerticalBound.localPosition.y)
        {
            CinemachineBrain.enabled = false;
        }
    }
}
