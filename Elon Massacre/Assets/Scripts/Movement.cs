using UnityEngine;

namespace Assets.Scripts
{
    public class Movement : MonoBehaviour {
        private const float Speed = 6f;
        private const float JumpForce = 500f;

        public Vector3 movement;
        private Animator animator;
        private Rigidbody elonRigidbody;

        public bool InJump;

        private void Awake() {
            animator = GetComponent<Animator>();
            elonRigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate() {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            float r = Input.GetAxis("Mouse X");

            gameObject.transform.Rotate(0f, r, 0f);

            //gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, Quaternion.Euler(0f, gameObject.transform.rotation.eulerAngles.y + r, 0f), 0.5f);

            Move(h, v);
            if (Input.GetKey(KeyCode.Space) && !InJump) {
                Jump();
            }
        }

        private void Move(float h, float v) {
            movement.Set(h, 0, v);
            movement = gameObject.transform.rotation * movement.normalized * Speed * Time.deltaTime;
            gameObject.transform.position += movement;
        }

        private void Jump() {
            InJump = true;

            var jumpVector = new Vector3(0, JumpForce, 0);
            elonRigidbody.AddForce(jumpVector);
        }

        private void OnCollisionEnter(Collision other) {
            if (other.gameObject.tag == "Terrain") {
                InJump = false;
            }
        }
    }
}
