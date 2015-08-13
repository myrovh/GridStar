using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour
{
    public List<Edge> EdgeListAll = new List<Edge>();
    public List<Edge> EdgeListShort = new List<Edge>(); 

    public float GizmoDrawRadius = 0.5f;

    void Update()
    {
        CullEdges();
    }

    public void CullEdges()
    {
        EdgeListShort.Clear();

        foreach (Edge e in EdgeListAll)
        {
            if (!e.isColliding)
            {
                EdgeListShort.Add(e);
            }
        }
    }

    public void AddEdge(GameObject e)
    {
        Edge eScript = e.GetComponent<Edge>();
        if (!EdgeListAll.Contains(eScript))
        {
            EdgeListAll.Add(eScript);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, GizmoDrawRadius);
    }
}
