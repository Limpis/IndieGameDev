using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentGUI : MonoBehaviour {

    [SerializeField]
    private GameObject agentCanvas;
    [SerializeField]
    private GameObject taskDropdown;

    public void ToggleCanvas()
    {
        if (agentCanvas.activeSelf == false)
        {
            agentCanvas.SetActive(true);
        }
        else if(agentCanvas.activeSelf == true)
        {
            agentCanvas.SetActive(false);
        }
    }

    public void PopulateDropDown(List<GameObject> list)
    {
        //Implement a fully correct population of the dropdown.
        //ALSO implement "None" option as default on top.
        Dropdown d = taskDropdown.GetComponent<Dropdown>();
        d.ClearOptions();

        Dropdown.OptionData option = new Dropdown.OptionData();
        option.text = list[0].GetComponent<Project>().GetProjectName();
        d.options.Add(option);
    }

    private void Start()
    {

    }
}
