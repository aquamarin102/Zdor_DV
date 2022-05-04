using UnityEngine;
using UnityEngine.AI;

namespace Quest
{
    [RequireComponent(typeof(NavMeshAgent))]
    
    public class FollowPlayer : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private HeroMove _player;

        [SerializeField] private float _damage = 1f;
        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _player = FindObjectOfType<HeroMove>();
        }

        private void Update()
        {
            _agent.SetDestination(_player.transform.position); 
        }
        
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.TryGetComponent(out HeroHealth health))
            {
                health.Hit(_damage);
                
            }
        }
    }
}
