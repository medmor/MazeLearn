﻿
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    NavMeshAgent agent;
    Camera cam;
    Animator animator;

    public Texture2D TargetCursor;
    public Texture2D PointerCursor;
    Vector3 targetRotationDirection;
    private LayerMask masks;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        cam = Camera.main;
        targetRotationDirection = transform.forward;
        masks = LayerMask.GetMask("Walkable", "Walls");
    }

    void Update()
    {
        var ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, masks))
        {
            if (hit.collider.gameObject.CompareTag("Walls"))
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            else
            {

                Cursor.SetCursor(TargetCursor, Vector2.zero, CursorMode.Auto);
                if (Input.GetMouseButtonDown(0))
                {
                    agent.isStopped = false;
                    agent.SetDestination(hit.point);
                    targetRotationDirection = hit.point - transform.position;
                }
            }
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }

        var remainingDist = GetPathRemainingDistance();
        if (agent.isStopped || remainingDist == 0)
        {
            animator.SetFloat("Speed", 0);
        }
        else
        {
            animator.SetFloat("Speed", 1);
        }

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetRotationDirection, Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    float GetPathRemainingDistance()
    {
        if (agent.pathPending ||
            agent.pathStatus == NavMeshPathStatus.PathInvalid ||
            agent.path.corners.Length == 0)
            return -1f;

        float distance = 0.0f;
        for (int i = 0; i < agent.path.corners.Length - 1; ++i)
        {
            distance += Vector3.Distance(agent.path.corners[i], agent.path.corners[i + 1]);
        }

        return distance;
    }
}
