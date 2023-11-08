using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

[System.Serializable]
public class UILocator
{

    [SerializeField] private List<ToggleController> toggles;
    [SerializeField] private CanvasGroup checkboxOn;
    [SerializeField] private CanvasGroup checkboxOff;

    [SerializeField] private Button buttonON;
    [SerializeField] private Button buttonOFF;
    [SerializeField] private Button buttonRotate;
    [SerializeField] private Button buttonTranslate;
    [SerializeField] private Button buttonOffTR;

    [SerializeField] private GameObject containerRotate;
    [SerializeField] private GameObject containerTranslate;

    public void Setup(EventBus eventBus)
    {
        foreach (var toggle in toggles)
        {
            toggle.Setup(eventBus);
        }
        buttonON.onClick.RemoveAllListeners();
        buttonOFF.onClick.RemoveAllListeners();
        buttonON.onClick.AddListener(CheckboxOn);
        buttonOFF.onClick.AddListener(CheckBoxOff);


        buttonRotate.onClick.RemoveAllListeners();
        buttonTranslate.onClick.RemoveAllListeners();
        buttonOffTR.onClick.RemoveAllListeners();
        buttonRotate.onClick.AddListener(OpenRotate);
        buttonTranslate.onClick.AddListener(OpenTranslate);
        buttonOffTR.onClick.AddListener(OffTR);

        CheckboxOn();
    }


    private void CheckboxOn()
    {
        SetupCanvasGroup(checkboxOff, false);
        SetupCanvasGroup(checkboxOn, true);
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

    private void OffTR()
    {
        containerRotate.SetActive(false);
        containerTranslate.SetActive(false);
    }

    private void OpenRotate()
    {
        OffTR();
        containerRotate.SetActive(true);
    }

    private void OpenTranslate()
    {
        OffTR();
        containerTranslate.SetActive(true);
    }


}
