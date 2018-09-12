using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solution : MonoBehaviour {

    [SerializeField]
    private Vector3 movement;
    [SerializeField]
    private float lifeTime;

    private GameObject targetTask;
    private Vector3 defaultSize;
    private bool animationGrowing = true;

    public void SetTarget(GameObject target)
    {
        targetTask = target;
    }

    private void Start()
    {
        StartCoroutine(LifeTime());
    }

    private void Update()
    {
        transform.position = transform.position + movement;
    }

    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(lifeTime);

        if(targetTask.GetComponent<Project>())
        {
            targetTask.GetComponent<Project>().SolveProblem();
        }

        Destroy(gameObject);
    }
}
