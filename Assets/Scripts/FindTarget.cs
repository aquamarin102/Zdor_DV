using UnityEngine;

namespace Quest
{
    public class FindTarget : MonoBehaviour
    {
        private Transform _target;
        public Transform Target => _target;
        public bool HasTarget => _target != null;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out HeroHealth health))
            {
                _target = other.transform;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out HeroHealth health))
            {
                _target = null;
            }
        }
    }

}
