using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour {

    AgentGUI gui;

    private void Start()
    {
        gui = GetComponent<AgentGUI>();
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Add raycast so that mouse is not tracing though other GUI components.
            gui.ToggleCanvas();
        }
    }
}
