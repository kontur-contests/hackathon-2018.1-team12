using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Movement : MonoBehaviour {
        public float Speed = 6f;
        public float JumpForce = 500f;

        private bool dead = false;

        public Animator animator;

        public Vector3 movement;
        private Rigidbody elonRigidbody;

        public bool InJump;

        public GameObject gameOver;
        public GameObject playerMesh;
        public MK.Glow.MKGlowFree glow;
        private Health health;

        private void Awake() {
            elonRigidbody = GetComponent<Rigidbody>();
            health = GetComponent<Health>();
        }

        private void Update()
        {
            if (health.HP <= 0)
            {
                gameOver.SetActive(true);
                glow.GlowType = MK.Glow.GlowType.Selective;
                Destroy(playerMesh);
                dead = true;
            }
        }

        private void FixedUpdate() {
            if (!dead) {
                float h = Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");
                float rx = Input.GetAxis("Mouse X");
                float ry = Input.GetAxis("Mouse Y");

                gameObject.transform.Rotate(-ry, rx, 0f);
                var angle = gameObject.transform.rotation.eulerAngles;
                var x = ClampAngle(angle.x, -30f, 30f);

                gameObject.transform.rotation = Quaternion.Euler(x, angle.y, 0f);

                Move(h, v);
                if (Input.GetKey(KeyCode.Space) && !InJump) {
                    Jump();
                }

                animator.SetBool("Moving", movement.sqrMagnitude != 0);
            }
        }

        private void Move(float h, float v) {
            movement.Set(h, 0, v);
            movement = Quaternion.Euler(0f, gameObject.transform.rotation.eulerAngles.y, 0f) * movement.normalized * Speed * Time.deltaTime;
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

        static float ClampAngle(float angle, float min, float max)
        {
            if (min < 0 && max > 0 && (angle > max || angle < min)) {
                angle -= 360;
                if (angle > max || angle < min) {
                    if (Mathf.Abs(Mathf.DeltaAngle(angle, min)) < Mathf.Abs(Mathf.DeltaAngle(angle, max))) {
                        return min;
                    }
                    else {
                        return max;
                    }
                }
            }
            else if (min > 0 && (angle > max || angle < min)) {
                angle += 360;
                if (angle > max || angle < min) {
                    if (Mathf.Abs(Mathf.DeltaAngle(angle, min)) < Mathf.Abs(Mathf.DeltaAngle(angle, max))) {
                        return min;
                    }
                    else {
                        return max;
                    }
                }
            }

            if (angle < min) {  return min; }
            else if (angle > max) { return max; }
            else { return angle; }
        }
    }
}
