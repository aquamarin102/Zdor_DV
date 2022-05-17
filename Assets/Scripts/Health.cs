using UnityEngine;

namespace Quest
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _maxHealth = 10f;
        [SerializeField] private float _curHealth;
        private void Awake()
        {
            _curHealth = _maxHealth;
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
            Destroy(gameObject);
        }
    }
}
