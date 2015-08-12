using UnityEngine;
using System.Collections;

public class Edge : MonoBehaviour
{
    private GameObject connectionFirst;
    private GameObject connectionSecond;

    public bool isColliding;

    public void SetConnections(GameObject first, GameObject second)
    {
        connectionFirst = first;
        connectionSecond = second;
    }

    public bool CheckMatchingEdge(GameObject first, GameObject second)
    {
        if ((connectionFirst == first && connectionSecond == second) || (connectionFirst == second && connectionSecond == first))
        {
            return true;
        }
        return false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(connectionFirst.transform.position, connectionSecond.transform.position);
    }
}
