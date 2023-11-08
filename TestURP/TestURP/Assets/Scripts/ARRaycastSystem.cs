using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARRaycastSystem : MonoBehaviour
{
    [SerializeField] private ARRaycastManager m_RaycastManager;
    private List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    private EventBus bus;



    public void Setup(EventBus eventBus)
    {
        bus = eventBus;

    }


    void Update()
    {
        if (Input.touchCount == 0)
            return;




        if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))
        {

            bus.Invoke(new SignalCreateARObject(m_Hits[0]));

            //text.text = m_Hits.Count.ToString();
            //  createAirPlane.InstantiateAirPlane(m_Hits[0]);
            // Only returns true if there is at least one hit
        }
    }
}
