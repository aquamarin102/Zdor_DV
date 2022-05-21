using UnityEngine;

namespace Quest
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _maxHealth = 10f;
        [SerializeField] private float _curHealth;
        
        private Rigidbody[] _rigidbodies;
        private FollowPlayer _followPlayer;
        private void Awake()
        {
            _curHealth = _maxHealth;
            _rigidbodies = GetComponentsInChildren<Rigidbody>();
            _followPlayer = GetComponent<FollowPlayer>();
            foreach (Rigidbody rb in _rigidbodies)
            {
                rb.isKinematic = true;
            }
        }
        
        public void Hit(float damage)
        {
            _curHealth -= damage;
            if (_curHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            RegdollON();
                _followPlayer.enabled = false;

        }
        
        private void RegdollON()
        {
            foreach (Rigidbody rb in _rigidbodies)
            {
                rb.isKinematic = false;
                GetComponent<Animator>().enabled = false;
            }
        }
    }
}
