using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CheckboxManager
{
    private EventBus bus;

    private int currentElementNumber;

    [SerializeField] private List<int> openNumbers;
    public CheckboxManager(EventBus eventBus)
    {
        bus = eventBus;
        openNumbers = new List<int>();
        currentElementNumber = 1;
        RegisterEvents();
    }


    private void RegisterEvents()
    {
        bus.Subscribe<SignalClick>(CallClickElement);
    }

    private void CallClickElement(SignalClick signal)
    {
        if (openNumbers.Contains(signal.Number))
            return;
        if (signal.Number != currentElementNumber)
        {
            bus.Invoke(new SignalErrorClick(signal.Number, signal.ClickElement));
            return;
        }
        openNumbers.Add(signal.Number);
        bus.Invoke(new SignalUpdateElement(currentElementNumber));
        currentElementNumber++;
    }


}

public enum TypeClickElement
{
    Button,
    Toggle
}
