using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MouseMovesCamNearScreenEdge : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] Cameras;
    public bool justSwapped = false;
    private int camIndex = 0;
    public float margin = 40;


    // Update is called once per frame
    void Update()
    {
        
        SetCamera();
        float mousePosX = Input.mousePosition.x;
        //Debug.Log(mousePosX);
        
        if (mousePosX < margin)
        {
            if (camIndex > 0 && !justSwapped)
            {
                camIndex--;
                justSwapped = true;
                return;
            }
        }

        if (mousePosX > Screen.width - margin)
        {
            if (camIndex < 3 && !justSwapped)
            {
                camIndex++;
                justSwapped = true;
                return;
            }

        }

        if (mousePosX < Screen.width - margin && mousePosX > margin)
        {
            justSwapped = false;
        }
    }

    public void SetCamera()
    {
        for (int c = 0; c <= 2; c++)
        {
            if (c == camIndex)
                Cameras[c].Priority = 10;
            else
                Cameras[c].Priority = 1;

        }
    }
}
