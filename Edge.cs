using UnityEngine;
using System.Collections;

public class Edge : MonoBehaviour
{
    private GameObject connectionFirst;
    private GameObject connectionSecond;

    public bool isColliding;

    public void Update()
    {
        CheckCollision();
    }

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

    public void CheckCollision()
    {
        //If collision
        bool forwardTest = Physics.Linecast(connectionFirst.transform.position, connectionSecond.transform.position);
        bool backwardTest = Physics.Linecast(connectionSecond.transform.position, connectionFirst.transform.position);
        if (forwardTest || backwardTest)
        {
            isColliding = true;
        }
        else
        {
            isColliding = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = isColliding ? Color.blue : Color.green;
        Gizmos.DrawLine(connectionFirst.transform.position, connectionSecond.transform.position);
    }
}
