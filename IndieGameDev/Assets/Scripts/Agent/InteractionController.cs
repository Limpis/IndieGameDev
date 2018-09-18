using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionController : MonoBehaviour {

    AgentGUI gui;
    AgentGUIHelper helper;

    private void Start()
    {
        gui = GetComponent<AgentGUI>();
        helper = GetComponentInParent<AgentGUIHelper>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                gui.ToggleCanvas();
                helper.SetActiveGUI(gameObject);
            }
        }
    }
}
