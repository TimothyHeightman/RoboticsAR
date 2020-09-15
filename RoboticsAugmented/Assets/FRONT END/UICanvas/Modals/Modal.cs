using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Modal : MonoBehaviour
{   
    // Define all variables to be inherited by Modal children
    protected GameObject _modal;
    protected GameObject _activeBckg;
    protected Button _modalOverlay;
    protected Button _closeModalBtn;
    protected Button _previousBtn;
    protected Button _nextBtn;

    public virtual void CloseModal()
    {
        // Deactivate modal and active tool cue
        _modal.SetActive (false);
        _activeBckg.SetActive(false);
    }

    public virtual void CloseListeners()
    {
        // Add listeners and close modal
        _modalOverlay.onClick.AddListener(delegate{CloseModal(); });
        _closeModalBtn.onClick.AddListener(delegate{CloseModal();});
    }
}