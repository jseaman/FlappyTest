using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {
    public float flapForce = 200;

    private bool flapping = false;
    private bool isDead = false;

    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private BoxCollider2D _collider;

	// Use this for initialization
	void Start () {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isDead)
            return;

        if (Input.GetButton("Jump") || Input.GetMouseButtonDown(0))        
            flapping = true;

        CalculateBirdRotation();
    }

    void CalculateBirdRotation()
    {
        var angle = _rigidBody.velocity.y / 10 * 90;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void FixedUpdate()
    {
        if (isDead)
            return;

        if (flapping)
        {            
            _rigidBody.velocity = Vector2.zero;

            var force = Vector2.up * flapForce * _rigidBody.mass;
            _rigidBody.AddForce(force);
            flapping = false;            

            _animator.SetTrigger("Flap");
        }
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        isDead = true;
        GameManager.gameManager.GameOver();
    }

    public bool isPlayerDead ()
    {
        return isDead;
    }
}
