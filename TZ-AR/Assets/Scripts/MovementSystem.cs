using UnityEngine;


public class MovementSystem : MonoBehaviour
{
    [SerializeField] private GameObject arCamera;
    [SerializeField] private GameObject xROrigin;
    [SerializeField] private float speed;
    
    
    private Vector3 vectorMovement;
    private bool flag;
    private EventBus bus;




    public void Setup(EventBus eventBus)
    {
        flag = false;
        bus = eventBus;
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        bus.Subscribe<SignalPressButtonMovement>(StartMove);
        bus.Subscribe<SignalUpButtonMovement>(EndMove);
    }


    private void FixedUpdate()
    {
        if (!flag)
            return;
        Move(vectorMovement);
    }
    private void Move(Vector3 vector)
    {
        xROrigin.transform.Translate(arCamera.transform.rotation * (vector) * speed * Time.fixedDeltaTime);

    }


    private void StartMove(SignalPressButtonMovement signal)
    {
        vectorMovement = signal.VectorMovement;
        flag = true;
    }

    private void EndMove(SignalUpButtonMovement signal)
    {
        flag = false;
    }


}
