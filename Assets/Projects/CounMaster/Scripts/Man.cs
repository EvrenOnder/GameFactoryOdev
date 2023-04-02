using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Man : PoolAbleObject
{
    public SOMan manInfo;

    private NavMeshAgent agent;

    private bool isMovedToCenter = false;

    void OnEnable()
    {
        EventManager.instance.OnMoveToCenter.AddListener(moveToCenter);
    }
    void OnDisable()
    {
        EventManager.instance.OnMoveToCenter.RemoveListener(moveToCenter);
    }

    void Awake()
    {
        // setPosForAgent();
    }

    public void setPosForAgent()
    {
        agent = GetComponent<NavMeshAgent>();
        NavMeshHit closestHit;

        if (NavMesh.SamplePosition(gameObject.transform.position, out closestHit, 500f, NavMesh.AllAreas))
            gameObject.transform.position = closestHit.position;
        else
            Debug.LogError("Could not find position on NavMesh!");
        agent.enabled = true;
    }

    void Update()
    {


    }

    private void moveToCenter()
    {
        if (agent == null)
        {
            setPosForAgent();
        }
        agent.enabled = true;
        // float distance = Vector3.Distance(this.transform.position,this.transform.parent.position);
        agent.SetDestination(this.transform.parent.position);

        StartCoroutine(stopNavigating(manInfo.navTime));
    }
    private IEnumerator stopNavigating(float navTime)
    {
        yield return new WaitForSeconds(navTime);
        stopAgent();
        StartCoroutine( reCenterAgain());
    }

    private IEnumerator reCenterAgain()
    {
        yield return new WaitForSeconds(manInfo.reOrganizeTime);
        Debug.Log("Recnter Again");
        moveToCenter();
    }

    public void stopAgent()
    {
        if (agent.enabled)
            agent.isStopped = true;
        agent.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            EventManager.instance.fireManDamage(this);
        }
    }

}
