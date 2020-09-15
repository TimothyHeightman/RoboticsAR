using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{

    // Example of how we to implement tooltips - place this script on any object having a tooltip on hover

    GameObject _newTooltip, _newTooltipBckg;
    bool hoverBool;
    Button cardButton;
    string cardTooltip;

    void Awake()
    {
        cardButton = GetComponent<Button>();
        cardTooltip = name;
    }

    void Update()
    {
        if (hoverBool) OnPointerOver();
    }

    public void OnPointerEnter(PointerEventData data)
    {
        hoverBool = true;
    }

    public void OnPointerExit(PointerEventData data)
    {
        hoverBool = false;
        // no longer a singleton because of convention, reference differently
        // TooltipManager.Instance.DeactivateTooltip(cardButton, _newTooltip, _newTooltipBckg, cardTooltip);
    }

    public void OnPointerUp(PointerEventData data)
    {
        hoverBool = false;
        // no longer a singleton because of convention, reference differently
        // TooltipManager.Instance.DeactivateTooltip(cardButton, _newTooltip, _newTooltipBckg, cardTooltip);
    }


    void OnPointerOver()
    {
        // no longer a singleton because of convention, reference differently
        //TooltipManager.Instance.OnHoverButtonActivateTooltip(cardButton, _newTooltip, _newTooltipBckg, cardTooltip);
    }
}
