using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class FactoryARObjects : MonoBehaviour
{
    [SerializeField] private GameObject m_Prefab;
    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private ARAnchorManager aRAnchorManager;


    private GameObject airPlane;
    private ARPlane chooseArPlane;
    private EventBus bus;
    private bool flagCreating;

    public void Setup(EventBus eventBus)
    {
        bus = eventBus;
        RegisterEvents();
        flagCreating = true;
    }




    private void RegisterEvents()
    {
        bus.Subscribe<SignalCreateARObject>(InstantiateAirPlane);
    }


    private void InstantiateAirPlane(SignalCreateARObject signal)
    {
        if (!flagCreating)
            return;

        if (signal.Hit.trackable is ARPlane plane)
        {
            Vector3 planeVector = new Vector3(plane.center.x, plane.center.y, plane.center.z);
            planeVector.x = Mathf.Ceil(planeVector.x);
            planeVector.y = Mathf.Ceil(planeVector.y);
            planeVector.z = Mathf.Ceil(planeVector.z);

            airPlane = Instantiate(m_Prefab, planeVector, Quaternion.Euler(Vector3.zero));
            chooseArPlane = plane;

            planeManager.enabled = false;

            if (airPlane.TryGetComponent(out ISetup setuper))
                setuper.SetupEventBus(bus);

            flagCreating = false;
            bus.Invoke(new SignalForMediatorTRS(airPlane));
        }
        
    }

    public void CreateAnchor()
    {
        Pose pose = new Pose(airPlane.transform.position, airPlane.transform.rotation);
        ARAnchor anchor = aRAnchorManager.AttachAnchor(chooseArPlane, pose);
    }
}
