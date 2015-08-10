using UnityEngine;
using System.Collections;

public class Graph : MonoBehaviour
{
    public float XGridBounds = 8;
    public float ZGridBounds = 8;
    public float YGridBounds = 3;
    public float GridInterval = 1;
    public GameObject WaypointPrefab;

    private void Start()
    {
        BuildGraph();
    }

    public void BuildGraph()
    {
        int nodeCount = 0;
        for (float y = YGridBounds; y >= 0; y -= GridInterval)
        {
            for (float x = XGridBounds; x >= 0 ; x -= GridInterval)
            {
                for (float z = ZGridBounds; z >= 0; z -= GridInterval)
                {
                    nodeCount++;
                    GameObject tempObject =
                        (GameObject) Instantiate(WaypointPrefab, new Vector3(x, y, z), Quaternion.identity);
                    tempObject.name = "node_" + nodeCount;
                    tempObject.transform.parent = gameObject.transform;
                }
            }
        }
        Debug.Log("Graph Generation Finished");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + new Vector3(XGridBounds / 2.0f, YGridBounds / 2.0f, ZGridBounds / 2.0f), new Vector3(XGridBounds, YGridBounds, ZGridBounds));
    }
}