using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class ARRaycastSystem : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager m_RaycastManager;

    [SerializeField] private TMP_Text text;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    [SerializeField] private CreateAirPlane createAirPlane;
    

    void Update()
    {
        if (Input.touchCount == 0)
            return;

        //text.text = "Нажатие было";
        if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))
        {
            //text.text = m_Hits.Count.ToString();
            createAirPlane.InstantiateAirPlane(m_Hits[0]);
            // Only returns true if there is at least one hit
        }
    }
}
