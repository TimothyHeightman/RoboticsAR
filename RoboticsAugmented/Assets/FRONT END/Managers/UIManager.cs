using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {   get
    {
            if (_instance == null)
                Debug.LogError("UIManager is NULL.");

            return _instance;

        }
    }
    
    private void Awake()
    {
        _instance = this; 
    }
    

    void Start()
    {
        
    }


}