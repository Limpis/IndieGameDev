using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solution : MonoBehaviour {

    [SerializeField]
    private Vector3 movement;
    [SerializeField]
    private float lifeTime;

    private SolutionData data;
    private GameObject targetTask;
    private MeshRenderer meshRenderer;

    public void SetTarget(GameObject target)
    {
        targetTask = target;
    }

    private void Start()
    {
        data = GetComponent<SolutionData>();

        StartCoroutine(LifeTime());
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        meshRenderer.material.color = targetTask.GetComponent<Task>().GetColor();
    }

    private void Update()
    {
        transform.position = transform.position + movement;
    }

    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(lifeTime);

        if(targetTask.GetComponent<Task>())
        {
            targetTask.GetComponent<Task>().SolveProblem(data.SolutionQuality);
        }

        Destroy(gameObject);
    }
}
