using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    static public Spawner S;
    static public List<Boid> boids;

    [Header("Set in Insepctor: Spawning")]
    public GameObject boidPrefab;
    public Transform boidAnchor;
    public int numBoids = 100;
    public float spawnRadius = 100f;
    public float spawnDelay = 0.1f;

    [Header("Set in Insepctor: Boids")]
    public float velocity = 30;
    public float neighborDist = 30;
    public float collDist = 4;
    public float velMatching = 0.25f;
    public float flockCentering = 0.2f;
    public float collAvoid = 2;
    public float attractPull = 2;
    public float attractPush = 2;
    public float attractPushDist = 5;

    void Awake()
    {
        // Set singleton
        S = this;
        boids = new List<Boid>();
        InstantiateBoid();
    }

    public void InstantiateBoid()
    {
        GameObject go = Instantiate(boidPrefab);
        Boid b = go.GetComponent<Boid>();
        b.transform.SetParent(boidAnchor);
        boids.Add(b);
        if (boids.Count < numBoids)
        {
            Invoke("InstantiateBoid", spawnDelay);
        }
    }
}
