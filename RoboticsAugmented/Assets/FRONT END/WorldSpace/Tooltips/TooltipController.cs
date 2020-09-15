using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipController : MonoBehaviour
{
    // Had to remove the singleton, need to figure out how to implement tooltips in AR
    // As UI canvas not controlled by mouse, there will be no UI tooltips.

    // Look at Tooltip.cs to see how to reference
    Vector2Int screen;

    public Transform tooltipsParent;
    public Sprite tooltipSprite;


    public void OnHoverButtonActivateTooltip(Button _hoveredButton, GameObject _newTooltip, GameObject _newTooltipBckg, string buttonTooltip)
    {
        string tooltipText = buttonTooltip;
        string tooltipTextNoSpaces = tooltipText.Replace(" ", string.Empty);

        Transform _tooltipChild = tooltipsParent.Find(tooltipTextNoSpaces);

        Vector2 mp = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        if (_tooltipChild != null) {
            _tooltipChild.gameObject.SetActive(true);
            UpdateTooltipPosition(_tooltipChild.gameObject.GetComponent<RectTransform>());
        }
        else
        {
            SetUpTooltip(_hoveredButton, _newTooltip, _newTooltipBckg, tooltipText, tooltipTextNoSpaces);
        }
    }

    public void DeactivateTooltip(Button _hoveredButton, GameObject _newTooltip, GameObject _newTooltipBckg, string buttonTooltip)
    {
        string tooltipTextNoSpaces = buttonTooltip.Replace(" ", string.Empty);
        
        Transform tooltipExists = tooltipsParent.Find(tooltipTextNoSpaces);
        if (tooltipExists != null)
        {
            tooltipExists.gameObject.SetActive(false);
        }
    }


    private void SetUpTooltip(Button _hoveredButton, GameObject _newTooltip, GameObject _newTooltipBckg, string tooltipText, string tooltipTextNoSpaces)
    {
        // Create newTooltip background in tooltipsParent object in UI layer
        _newTooltipBckg = new GameObject();
        _newTooltipBckg.transform.SetParent(tooltipsParent, false);
        _newTooltipBckg.name = tooltipTextNoSpaces;
        RectTransform tooltipBckgRT = _newTooltipBckg.AddComponent<RectTransform>();
        tooltipBckgRT.pivot = new Vector2(0, 1);
        tooltipBckgRT.anchorMin = new Vector2(0, 1);
        tooltipBckgRT.anchorMax = new Vector2(0, 1);
        _newTooltipBckg.AddComponent<Image>().color = new Color(243, 242, 230, 255);

        // Create text object with tooltip name in tooltip background
        _newTooltip = new GameObject();
        _newTooltip.transform.SetParent(_newTooltipBckg.transform, false);
        RectTransform tooltipRT = _newTooltip.AddComponent<RectTransform>();
        _newTooltip.name = tooltipTextNoSpaces + "Text";

        // Add TMPUGI and change settings
        TextMeshProUGUI tooltipTMP = _newTooltip.AddComponent<TextMeshProUGUI>();
        tooltipTMP.text = tooltipText;
        tooltipTMP.color = new Color32(17, 17, 17, 255);
        tooltipTMP.font = Resources.Load("RalewayRegular SDF", typeof(TMP_FontAsset)) as TMP_FontAsset;
        tooltipTMP.fontSize = 16f;
        tooltipTMP.autoSizeTextContainer = true;
        Canvas.ForceUpdateCanvases();


        // Calculate the size of the box depending on the text length
        tooltipBckgRT.sizeDelta = new Vector2(15, 15) + tooltipRT.sizeDelta;

        // Change position and sprite of tooltip
        UpdateTooltipPosition(tooltipBckgRT);
        tooltipBckgRT.gameObject.GetComponent<Image>().sprite = tooltipSprite;
    }

    public void UpdateTooltipPosition(RectTransform tooltipRect)
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;

        tooltipRect.position = new Vector3(mouseX + 10, mouseY - 10, 0);
    }

}
