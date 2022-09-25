using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OvenMoveAI : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField]
    Transform target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(target.position);
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
}
