using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour
{
    public float GizmoDrawRadius = 0.5f;
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, GizmoDrawRadius);
    }
}
