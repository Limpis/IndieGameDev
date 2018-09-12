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

    private void Start()
    {
        bodyMeshRenderer = agentBody.GetComponent<MeshRenderer>();
        headMeshRenderer = agentHead.GetComponent<MeshRenderer>();

        initialBodyMat = bodyMeshRenderer.material;
        initialHeadMat = headMeshRenderer.material;

        customBodyMat = new Material(initialBodyMat);
        customHeadMat = new Material(initialHeadMat);

        customBodyMat.color = shirtColor;
        customHeadMat.color = skinColor;

        bodyMeshRenderer.material = customBodyMat;
        headMeshRenderer.material = customHeadMat;
    }
}
