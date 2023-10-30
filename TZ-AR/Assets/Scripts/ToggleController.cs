using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    [SerializeField] private int number;

    private Toggle toggle;
    private bool isOn = false;
    private bool toggleOff = false;
    private TypeClickElement typeClickElement = TypeClickElement.Toggle;

    private EventBus bus;
    public void Setup(EventBus eventBus)
    {
        bus = eventBus;
        toggle = GetComponent<Toggle>();
        RegisterEvents();
    }

    private void Click(Toggle toggle)
    {
        if (toggleOff)
        {
            toggle.isOn = true;
            return;
        }


        if (!isOn)
        {
            toggle.isOn = false;
            bus.Invoke(new SignalClick(number, typeClickElement));
        }
    }

    private void RegisterEvents()
    {
        toggle.onValueChanged.AddListener(delegate { Click(toggle); });
        bus.Subscribe<SignalUpdateElement>(UpdateToggle);
    }


    private void UpdateToggle(SignalUpdateElement signal)
    {
        if (signal.Number != number)
            return;



        toggleOff = true;
        toggle.isOn = true;
        isOn = true;
    }




}
