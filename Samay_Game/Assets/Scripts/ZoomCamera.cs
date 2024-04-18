using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{

    private CinemachineFreeLook freeLookCamera;
    private CinemachineFreeLook.Orbit[] originalOrbits;

    [Range(0.1f,0.5f)]
    public float minZoom = 0.5f;

    [Range(1f,5f)]
    public float maxZoom = 1.0f;

    [AxisStateProperty]
    public AxisState zAxis = new AxisState(0, 1, false, true, 50f, 0.1f, 0.1f, "Mouse ScrollWheel", false);

    // Start is called before the first frame update
    void Start()
    {

        freeLookCamera = GetComponent<CinemachineFreeLook>();
        if (freeLookCamera != null)
        {


            originalOrbits = new CinemachineFreeLook.Orbit[freeLookCamera.m_Orbits.Length];
            for (int i = 0; i < originalOrbits.Length; i++)
            {
                originalOrbits[i].m_Height = freeLookCamera.m_Orbits[i].m_Height;
                originalOrbits[i].m_Radius = freeLookCamera.m_Orbits[i].m_Radius;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (originalOrbits != null)
        {
            zAxis.Update(Time.deltaTime);
            float zoomScale = Mathf.Lerp(minZoom, maxZoom, zAxis.Value);

            for(int i = 0;i < originalOrbits.Length;i++)
            { 
                freeLookCamera.m_Orbits[i].m_Height = originalOrbits[i].m_Height * zoomScale;
                freeLookCamera.m_Orbits[i].m_Radius = originalOrbits[i].m_Radius * zoomScale;
                       
            }
        }
    }
}
