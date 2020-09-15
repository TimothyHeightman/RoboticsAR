using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


[System.Serializable]
public class MeshCard
{
    // Define MeshCards object to be connected into the inspector
    public obj item;
    public GameObject meshCard;

    public MeshCard(obj item, GameObject meshCard)
    {
        this.item = item;
        this.meshCard = meshCard;
    }
}

public class InventoryModal : Modal
{
    // Add all relevant objects to the inspector - modal, buttons, locks etc.

    [SerializeField]
    private List<MeshCard> availableCards = new List<MeshCard>();

    public Dictionary<obj, GameObject> availableCardsDict = new Dictionary<obj, GameObject>();


    void Awake ()
    {
        // Define all of the variables required, inherited from parent Modal class
        _modal = this.gameObject;
        _modalOverlay = this.transform.GetChild(0).GetComponentInParent<Button>();
        _closeModalBtn = this.transform.GetChild(1).GetChild(0).GetChild(1).GetComponentInParent<Button>();
    }

    void Start()
    {
        CloseListeners();
        //ButtonFromKey(obj.board).onClick.AddListener(PlaceBoard);
    }

    private void DictionaryMeshCards()
    {
        // Assigns a key to each card to ease calling each object in program
        foreach(MeshCard card in availableCards)
        {
            availableCardsDict.Add(card.item, card.meshCard);
        }
    }

    private GameObject CardFromKey(obj item)
    {
        // Retrieves the required card from the selection of MeshID as defined
        // in the inspector
        if (availableCardsDict.ContainsKey(item) == false)
        {
            DictionaryMeshCards();
            return availableCardsDict[item];
        }

        return availableCardsDict[item];
    }

    private Button ButtonFromKey(obj item)
    {
        // Retrieves the required button from the card
        return CardFromKey(item).GetComponent<Button>();
    }

    private void SelectAndPlaceItem(Button thisClick, obj item)
    {
        // Functionality for instantiating prefabs, closing the inventory as it is 
        // introduced onto the scene
        //InstantiateItem(item);
        CloseModal();
        thisClick.interactable = false;
    }

    public override void CloseModal()
    {
        // Override abstract class method to add selection of first category as modal
        // is closed.
        base.CloseModal();
    }

}