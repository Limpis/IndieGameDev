using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentGUIHelper : MonoBehaviour {

    //Script used to check for and disallow multiple 
    //agent GUIs open at the same time. 

    GameObject activeGUI;

    public void SetActiveGUI(GameObject g)
    {
        if (activeGUI != null && activeGUI != g)
        {
            CloseGUI();
        }

        activeGUI = g;
    }

    private void CloseGUI()
    {
        if (activeGUI.GetComponent<AgentGUI>().CanvasActive())
        {
            activeGUI.GetComponent<AgentGUI>().ToggleCanvas();
        }
    }
}
