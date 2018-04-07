using UnityEngine;

namespace Assets.Scripts
{
	public class Footsteps : MonoBehaviour {
		private Movement _cc;
		private AudioSource _audioSource;

		private void Start ()
		{
			_cc = GetComponent<Movement>();
			_audioSource = GetComponent<AudioSource>();
		}

		private void Update ()
		{
			if(!_cc.InJump && _cc.movement.magnitude > 0.04f && _audioSource.isPlaying == false)
			{
				_audioSource.volume = Random.Range(0.8f, 1);
				_audioSource.pitch = Random.Range(0.8f, 1.1f);
				_audioSource.Play();
			}
		}
	}
}
