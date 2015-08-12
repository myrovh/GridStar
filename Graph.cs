using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class Graph : MonoBehaviour
{
    private List<GameObject> NodeList = new List<GameObject>();
    private List<GameObject> EdgeList = new List<GameObject>();

    public float XGridBounds = 8;
    public float ZGridBounds = 8;
    public float YGridBounds = 3;
    public float GridInterval = 1;
    public GameObject NodePrefab;
    public GameObject EdgePrefab;

    private void Start()
    {
        BuildGraph();
    }

    public void BuildGraph()
    {
        CleanOldGraph();

        int nodeCount = 0;
        for (float y = YGridBounds; y >= 0; y -= GridInterval)
        {
            for (float x = XGridBounds; x >= 0; x -= GridInterval)
            {
                for (float z = ZGridBounds; z >= 0; z -= GridInterval)
                {
                    nodeCount++;
                    GameObject tempObject =
                        (GameObject)Instantiate(NodePrefab, new Vector3(x, y, z) + transform.position, Quaternion.identity);
                    tempObject.name = "node_" + nodeCount;
                    tempObject.transform.parent = gameObject.transform;
                    NodeList.Add(tempObject);
                }
            }
        }

        ConnectEdges();

        Debug.Log("Graph Generation Finished");
    }

    public void ConnectEdges()
    {
        int edgeCount = 0;
        foreach (GameObject first in NodeList)
        {
            foreach (GameObject other in NodeList)
            {
                Vector3 nodeDistance = first.transform.position - other.transform.position;
                if (nodeDistance.magnitude <= GridInterval && CheckDuplicateEdge(first, other))
                {
                    edgeCount++;
                    GameObject tempObject = (GameObject) Instantiate(EdgePrefab, first.transform.position, Quaternion.identity); //Generate edge from prefab
                    tempObject.transform.parent = gameObject.transform; //Set parent of edge to graph
                    Edge edgeScript = tempObject.GetComponent<Edge>(); //Get edge script
                    edgeScript.SetConnections(first, other); //Assign references to first and second node
                    tempObject.name = "edge_" + edgeCount; //Name Edge
                    EdgeList.Add(tempObject); //add to graph list
                    first.GetComponent<Node>().AddEdge(tempObject); //Add to both nodes
                    other.GetComponent<Node>().AddEdge(tempObject);
                }
            }
        }
    }

    private bool CheckDuplicateEdge(GameObject first, GameObject second)
    {
        if (first == second)
        {
            return false;
        }

        foreach (GameObject e in EdgeList)
        {
            Edge edgeScript = e.GetComponent<Edge>();
            if (edgeScript.CheckMatchingEdge(first, second))
            {
                return false;
            }
        }
        return true;
    }

    private void CleanOldGraph()
    {
        foreach (var variable in EdgeList)
        {
            Destroy(variable);
        }
        foreach (var variable in NodeList)
        {
            Destroy(variable);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + new Vector3(XGridBounds / 2.0f, YGridBounds / 2.0f, ZGridBounds / 2.0f), new Vector3(XGridBounds, YGridBounds, ZGridBounds));
    }
}