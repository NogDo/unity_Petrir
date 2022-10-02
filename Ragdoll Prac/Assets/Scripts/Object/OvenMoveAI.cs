using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OvenMoveAI : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField]
    Transform target;

    public GameObject objPlayer;

    bool isPressF;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        isPressF = false;
    }

    void Update()
    {
        if (isPressF)
        {
            agent.transform.LookAt(objPlayer.transform);
            agent.SetDestination(transform.position);
        }
        else
        {
            agent.SetDestination(target.position);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == target.gameObject)
        {
            float fX = Random.Range(-0.4f, 0.4f);
            float fZ = Random.Range(-0.4f, 0.4f);
            Vector3 vectorTargetNewPosition = new Vector3(fX, 0, fZ);
            target.localPosition = vectorTargetNewPosition;
        }
    }

    public void PressFTrue()
    {
        isPressF = true;
    }

    public void PressFFalse()
    {
        isPressF = false;
    }
}
