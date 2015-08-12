using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour
{
    public List<GameObject> EdgeListAll = new List<GameObject>();

    public float GizmoDrawRadius = 0.5f;

    /* Collider method of edge connections
    public float ColliderRadius = 1.1f;
    public string targetTag = "";
    public List<Node> objectsInRange;
    void Start()
    {
        SphereCollider c = gameObject.AddComponent<SphereCollider>();
        c.radius = ColliderRadius;
        c.isTrigger = true;
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == targetTag)
        {
            if (c.GetComponent<Node>() != null)
            {
                objectsInRange.Add(c.GetComponent<Node>());
            }
            else
            {
                Debug.LogWarning("Tagged Object " + c.name + " does not have a node component");
            }
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.tag == targetTag)
        {
            if (c.GetComponent<Node>() != null)
            {
                objectsInRange.Remove(c.GetComponent<Node>());
            }
        }
    }
    */

    public void AddEdge(GameObject e)
    {
        if (!EdgeListAll.Contains(e))
        {
            EdgeListAll.Add(e);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, GizmoDrawRadius);
    }
}
