using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float minSpawnRadius;
    public float maxSpawnerRadius;
    public List<GameObject> spawanables;
    public int maxSpawnObjects = 5;
    public float timer = 5;

    private int totalSpawned = 0;


    void OnEnable()
    {
        this.GetComponent<SphereCollider>().radius = maxSpawnerRadius;
        InvokeRepeating("SpawnElement", 2, timer);
    }


    public Vector3 RandomNavSphere(Vector3 origin, float minDist, float maxDist, int layermask)
    {

        Vector2 randomDirection = Vector2.Scale(Random.insideUnitCircle, origin).normalized;

        Debug.Log("Direction " + randomDirection);
        randomDirection *= Random.Range(minDist, maxDist);

        Vector3 point = new Vector3(randomDirection.x + origin.x, origin.y, randomDirection.y + origin.z);

        Debug.Log(randomDirection);
        Debug.Log(point);


        UnityEngine.AI.NavMeshHit navHit;

        UnityEngine.AI.NavMesh.SamplePosition(point, out navHit, maxDist, layermask);

        return navHit.position;


    }

    private void SpawnElement()
    {
        if (totalSpawned < maxSpawnObjects)
        {
            Instantiate(spawanables[Random.Range(0, spawanables.Count)], RandomNavSphere(this.transform.position, minSpawnRadius, maxSpawnerRadius, -1), Quaternion.identity);
            totalSpawned++;
        }
    }
}
