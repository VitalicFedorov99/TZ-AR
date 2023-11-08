using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneTrackingModeVisualizer : MonoBehaviour
{
    ARPlane m_ARPlane;
    MeshRenderer m_PlaneMeshRenderer;
    Color m_OriginalColor;

    void Awake()
    {
        m_ARPlane = GetComponent<ARPlane>();
        m_PlaneMeshRenderer = GetComponent<MeshRenderer>();
        m_OriginalColor = m_PlaneMeshRenderer.material.color;
    }

    void Update()
    {
        UpdatePlaneColor();
    }

    void UpdatePlaneColor()
    {

        Color planeMatColor = Color.cyan;

        switch (m_ARPlane.trackingState)
        {
            case TrackingState.None:
                planeMatColor = Color.grey;
                break;
            case TrackingState.Limited:
                planeMatColor = Color.red;
                break;
            case TrackingState.Tracking:
                planeMatColor = m_OriginalColor;
                break;
        }

        planeMatColor.a = m_OriginalColor.a;
        m_PlaneMeshRenderer.material.color = planeMatColor;
    }
}
