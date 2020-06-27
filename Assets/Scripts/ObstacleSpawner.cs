using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    public GameObject obstacleObj;
    public int count = 4;
    public float separation = 4;

    List<ObstacleController> obstacles = new List<ObstacleController>();

	// Use this for initialization
	void Start () {
        for (int i = 0; i < count; i++)
        {
            var obstacle = Instantiate(obstacleObj) as GameObject;
            obstacle.transform.position += Vector3.right * separation * i;
            obstacle.transform.parent = transform;

            obstacles.Add(obstacle.GetComponent<ObstacleController>());
        }
	}
	
	// Update is called once per frame
	void Update () {
        var first = obstacles[0];
        var last = obstacles[obstacles.Count - 1];

        if (first.isOffscreen())
        {
            obstacles.Remove(first);
            first.transform.position = last.transform.position + Vector3.right * separation;
            first.SetHeight();
            obstacles.Add(first);
        }
	}
}
