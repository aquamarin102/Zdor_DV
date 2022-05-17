using System;
using UnityEngine;
using UnityEngine.AI;

namespace Quest
{
    [RequireComponent(typeof(NavMeshAgent))]
    
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField] private float _damage = 1f;
        
        private NavMeshAgent _agent; 
        private HeroMove _player;
        private Animator _anim;
        
        private string _isAttack = "isAttack";
        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _anim = GetComponent<Animator>();
        }

        private void Update()
        {
            if(_player != null)
                _agent.SetDestination(_player.transform.position);
            
        }
        
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.TryGetComponent(out HeroHealth health))
            {
                _anim.SetBool(_isAttack, true);
                health.Hit(_damage);

            }
        }

        private void OnTriggerExit(Collider other)
        {
            _anim.SetBool(_isAttack, false);
        }

        public void SetData(HeroMove player)
        {
            _player = player;
        }
    }
}
