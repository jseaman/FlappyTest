using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {
    public float heightRange = 2;
    public float speed = 2;

    private BirdController bird;

    bool offscreen = false;

	// Use this for initialization
	void Start () {
        var player = GameObject.FindGameObjectWithTag("Player") as GameObject;
        bird = player.GetComponent<BirdController>();

        //transform.position += Vector3.up * Random.Range(-heightRange, heightRange);
        SetHeight();
	}

    public void SetHeight()
    {
        var y = Random.Range(-heightRange, heightRange);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        if (bird.isPlayerDead())
            return;

        transform.position += Vector3.right * -Time.deltaTime * speed;

        var screenEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2;

        offscreen = transform.position.x < screenEdge;           
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if (bird.isPlayerDead())
            return;

        ScoreManager.scoreManager.UpdateScore(1);
    }

    public bool isOffscreen()
    {
        return offscreen;
    }

}
