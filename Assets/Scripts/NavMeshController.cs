using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    public Transform objetivo;
    private LineRenderer lineRenderer;
    private NavMeshPath path;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        lineRenderer = GetComponent<LineRenderer>();

        agent.CalculatePath(objetivo.position, path);
        DrawPath();
    }

    // Update is called once per frame
    void Update()
    {
        agent.CalculatePath(objetivo.position, path);
        DrawPath();
    }

    void DrawPath()
    {
        if (path.corners.Length < 2)
            return; // No hay suficiente información para dibujar el camino

        lineRenderer.positionCount = path.corners.Length;
        lineRenderer.SetPositions(path.corners);
    }
}
