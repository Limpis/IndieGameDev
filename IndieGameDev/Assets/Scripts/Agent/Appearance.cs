using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appearance : MonoBehaviour {

    //Specifies shirt and skin color of agent.

    [SerializeField]
    private Color shirtColor, skinColor;
    [SerializeField]
    private GameObject agentBody, agentHead;

    private Material initialBodyMat, initialHeadMat;
    private Material customBodyMat, customHeadMat;

    private MeshRenderer bodyMeshRenderer, headMeshRenderer;

    public void SetColors(Color body, Color head)
    {
        if(bodyMeshRenderer == null)
        {
            bodyMeshRenderer = agentBody.GetComponent<MeshRenderer>();
            initialBodyMat = bodyMeshRenderer.material;
        }
        if(headMeshRenderer == null)
        {
            headMeshRenderer = agentHead.GetComponent<MeshRenderer>();
            initialHeadMat = headMeshRenderer.material;
        }

        shirtColor = body;
        skinColor = head;

        UpdateColors();
    }

    private void Start()
    {
        if (bodyMeshRenderer == null)
        {
            bodyMeshRenderer = agentBody.GetComponent<MeshRenderer>();
            initialBodyMat = bodyMeshRenderer.material;
        }
        if (headMeshRenderer == null)
        {
            headMeshRenderer = agentHead.GetComponent<MeshRenderer>();
            initialHeadMat = headMeshRenderer.material;
        }

        UpdateColors();
    }

    private void UpdateColors()
    {
        customBodyMat = new Material(initialBodyMat);
        customHeadMat = new Material(initialHeadMat);

        customBodyMat.color = shirtColor;
        customHeadMat.color = skinColor;

        bodyMeshRenderer.material = customBodyMat;
        headMeshRenderer.material = customHeadMat;
    }
}
