using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InterfaceControl : MonoBehaviour
{
    [SerializeField] private GameObject panelGameOver;
    
    public void OnPanelGameOver()
    {
        panelGameOver.SetActive(true);
    }
}
