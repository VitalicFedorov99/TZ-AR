using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

[System.Serializable]
public class UILocator
{
    [SerializeField] private List<ButtonController> buttons;
    [SerializeField] private List<ToggleController> toggles;
    [SerializeField] private CanvasGroup checkboxOn;
    [SerializeField] private CanvasGroup checkboxOff;

    [SerializeField] private Button buttonON;
    [SerializeField] private Button buttonOFF;

    [SerializeField] private CustomButton buttonForward;
    [SerializeField] private CustomButton buttonBack;


    public void Setup(EventBus eventBus)
    {
        foreach (var button in buttons)
        {
            button.Setup(eventBus);
        }
        foreach (var toggle in toggles)
        {
            toggle.Setup(eventBus);
        }
        buttonON.onClick.RemoveAllListeners();
        buttonOFF.onClick.RemoveAllListeners();
        buttonON.onClick.AddListener(CheckboxOn);
        buttonOFF.onClick.AddListener(CheckBoxOff);
        CheckboxOn();
        buttonForward.Setup(eventBus);
        buttonBack.Setup(eventBus);
    }


    private void CheckboxOn()
    {
        SetupCanvasGroup(checkboxOff,false);
        SetupCanvasGroup(checkboxOn,true);
    }

    private void CheckBoxOff()
    {
        SetupCanvasGroup(checkboxOff, true);
        SetupCanvasGroup(checkboxOn, false);
    }

    private void SetupCanvasGroup(CanvasGroup group, bool flag)
    {
        int numberAlpha = 0;
        if (flag)
            numberAlpha = 1;
        group.alpha = numberAlpha;
        group.blocksRaycasts = flag;
        group.interactable = flag;
    }



}
