using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentGUI : MonoBehaviour {

    [SerializeField]
    private GameObject agentCanvas;
    [SerializeField]
    private GameObject taskDropdown;

    private List<GameObject> dropdownList;
    private GameObject objectActiveInDropdown;
    private Dropdown dropdownMenu;

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
        //NOTE! Unable to handle multiple task types.

        //Save list to keep access to all task gameobjects.
        dropdownList = list;

        dropdownMenu.ClearOptions();
        Dropdown.OptionData option;

        for (int i = 0; i < dropdownList.Count; i++)
        {
            option = new Dropdown.OptionData();

            if (dropdownList[i].GetComponent<Project>())
            {
                option.text = dropdownList[i].GetComponent<Task>().GetName();
                dropdownMenu.options.Add(option);
            }
            else
            {
                Debug.Log("Error! Project script not present on gameobject sent to populate dropdown menu.");
            }
        }

        option = new Dropdown.OptionData();
        option.text = "None";
        dropdownMenu.options.Insert(0, option);

        dropdownMenu.RefreshShownValue();
    }

    public GameObject GetActiveTask()
    {
        return objectActiveInDropdown;
    }

    private void Start()
    {
        dropdownMenu = taskDropdown.GetComponent<Dropdown>();
        dropdownMenu.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(dropdownMenu);
        });

        PopulateDropDown(new List<GameObject>());
    }

    private void DropdownValueChanged(Dropdown change)
    {
        if(change.value == 0)
        {
            objectActiveInDropdown = null;
        }
        else
        {
            objectActiveInDropdown = dropdownList[change.value - 1];
        }
    }
}
