using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float Speed = 6f;
    public float JumpForce = 500f;

    Vector3 movement;
    Animator animator;
    Rigidbody elonRigidbody;

    bool inJump = false;

    void Awake() {
        animator = GetComponent<Animator>();
        elonRigidbody = GetComponent<Rigidbody>();
	}

    void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Move(h, v);
        if (Input.GetKey(KeyCode.Space) && !inJump) {
            Jump();
        }
    }

    void Move(float h, float v) {
        movement.Set(h, 0, v);
        movement = movement.normalized * Speed * Time.deltaTime;
        elonRigidbody.MovePosition(transform.position + movement);
    }

    void Jump() {
        inJump = true;

        var jumpVector = new Vector3(0, JumpForce, 0);
        elonRigidbody.AddForce(jumpVector);
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Terrain") {
            inJump = false;
        }
    }
}
