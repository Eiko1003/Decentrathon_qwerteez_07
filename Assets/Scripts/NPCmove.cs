using UnityEngine;
using UnityEngine.AI;

public class NPCmove : MonoBehaviour
{
    private Transform[] endPositions;
    private NavMeshAgent agent;

    private System.Random rand = new();
    private int aim;

    void Start()
    {
        GameObject[] points = GameObject.FindGameObjectsWithTag("Point");
        endPositions = new Transform[points.Length];
        
        for(int i = 0; i < points.Length; i++)
        {
            endPositions[i] = points[i].transform;
        }
        agent = GetComponent<NavMeshAgent>();
        FindPosition();
    }

    private void FindPosition()
    {
        aim = rand.Next(endPositions.Length);
        agent.SetDestination(endPositions[aim].position);
    }

    private bool Reach()
    {
        if (transform.position.x + 1 > endPositions[aim].position.x && endPositions[aim].position.x > transform.position.x - 1 && transform.position.z + 1 > endPositions[aim].position.z && endPositions[aim].position.z > transform.position.z - 1) { return true; }
        return false;
    }

    private void FixedUpdate()
    {
        if(Reach())
        {
            FindPosition();
        }
    }
}
