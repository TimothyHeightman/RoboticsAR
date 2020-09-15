using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class ModalController : MonoBehaviour
{
    // Set Up prefab game objects: references and new ones in which to instantiate prefabs.
    // Needs implementation, as singleton removed for convention

    // These help check if prefabs already instantiated
    private List<string> createdModals = new List<string>();

    private Dictionary<string, GameObject> createdModalsDict = new Dictionary<string, GameObject>();

    public void ActivateModal(Dictionary<string, GameObject> exists, string name, GameObject prefab, GameObject modal, Transform parent)
    {
        // If modal not in hirearchy, instantiate prefab
        if (createdModalsDict.ContainsKey(name) == false)
        {
            modal = Instantiate(prefab, parent);
            modal.SetActive(true);
            exists.Add(name, modal);
        }
        
        exists[name].SetActive(true);

    }
    
    // Left in to show possible functionality 
    /*public void ActivateHelpModal(Mode desiredMode)
    {

        switch (desiredMode)
        {     
            //Depending on the current mode different modals are created/enabled

            case Mode.Calibrate:

                ActivateModal(createdModalsDict, "calibrateHelp", _helpCalPrefab, helpCal, this.transform.GetChild(1));
                break;

            case Mode.Measure:

                ActivateModal(createdModalsDict, "measureHelp", _helpMesPrefab, helpMes, this.transform.GetChild(1));
                break;

            case Mode.Explore:

                ActivateModal(createdModalsDict, "exploreHelp", _helpExplPrefab, helpExpl, this.transform.GetChild(1));
                break;

            case Mode.DataTake:

                ActivateModal(createdModalsDict, "dataHelp", _helpDataPrefab, helpData, this.transform.GetChild(1));
                break;
        }
    }

    public void ActivateInventory()
    {
        //ActivateModal(createdModalsDict, "inventory", _inventoryPrefab, inventory, this.transform.GetChild(2));
    }*/

}