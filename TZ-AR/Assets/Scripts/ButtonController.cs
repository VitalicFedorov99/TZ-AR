using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{

    [SerializeField] private int number;
    private Button button;
    private Image image;
    private TypeClickElement typeClickElement = TypeClickElement.Button;
    private bool isOn = false;

    private EventBus bus;

    public void Setup(EventBus eventBus)
    {
        bus = eventBus;
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(Click);
        bus.Subscribe<SignalUpdateElement>(UpdateButton);
    }


    private void Click()
    {
        if (!isOn)
        {
            bus.Invoke(new SignalClick(number, typeClickElement));
        }
    }
    private void UpdateButton(SignalUpdateElement signal)
    {
        if (signal.Number != number)
            return;

        isOn = true;
        image.color = Color.green;
    }

}
