using UnityEngine;
using System.Collections;

public class Graph : MonoBehaviour
{
    public float XGridBounds = 8;
    public float YGridBounds = 8;
    public float ZGridBounds = 3;
    public float GridInterval = 1;
    public GameObject WaypointPrefab;

    private void Start()
    {
        BuildGraph();
    }

    public void BuildGraph()
    {
        Debug.Log("Graph Generation Starting");
        int nodeCount = 0;
        for (float z = ZGridBounds; z > -ZGridBounds; z -= GridInterval)
        {
            for (float x = XGridBounds; x > -XGridBounds; x -= GridInterval)
            {
                for (float y = YGridBounds; y > -YGridBounds; y -= GridInterval)
                {
                    nodeCount++;
                    GameObject tempObject =
                        (GameObject) Instantiate(WaypointPrefab, new Vector3(x, z, y), Quaternion.identity);
                    tempObject.name = "node_" + nodeCount;
                    tempObject.transform.parent = gameObject.transform;
                }
            }
        }
        Debug.Log("Graph Generation Ending");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(XGridBounds * GridInterval, YGridBounds * GridInterval, ZGridBounds * GridInterval));
    }
}