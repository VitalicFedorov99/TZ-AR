using UnityEngine;


//Translate Rotate Scale
public class MediatorTRS : MonoBehaviour
{

    [SerializeField] private float speedRotate;
    [SerializeField] private float speedTranslate;

    private TranslateARObject translateARObject;
    private RotateARObject rotateARObject;
    private ScaleARObject scaleARObject;

    private EventBus bus;


    public void Setup(EventBus eventBus)
    {
        bus = eventBus;
        translateARObject = new TranslateARObject(speedTranslate);
        rotateARObject = new RotateARObject(speedRotate);
        scaleARObject = new ScaleARObject();
        RegisterEvents();
    }

    public void RotateObject(int number) 
    {
        EnumOrientations orientation = (EnumOrientations)number; 
        rotateARObject.Rotate(orientation);
    }

    public void TranslateObject(int number)
    {
        EnumOrientations orientation = (EnumOrientations)number;
        translateARObject.Translate(orientation);
    }

    public void ScaleObject(bool scaleFlag) 
    {
        scaleARObject.Scale(scaleFlag);
    }


    private void RegisterEvents() 
    {
        bus.Subscribe<SignalForMediatorTRS>(SetupARObject);
    }
    
    private void SetupARObject(SignalForMediatorTRS signal) 
    {
        translateARObject.Setup(signal.GameObj);
        rotateARObject.Setup(signal.GameObj);
        scaleARObject.Setup(signal.GameObj);
    }
}
