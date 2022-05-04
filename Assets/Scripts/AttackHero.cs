using UnityEngine;

namespace Quest
{
    public class AttackHero : MonoBehaviour
    {
        private float _timeBtwAttack;
        [SerializeField] private float _startTimeBtwAtack;

        private string _animAttack = "attack";

        [SerializeField] private Transform _attackPos;
        [SerializeField] private LayerMask _enemy;
        [SerializeField] private float _attackRange;
        [SerializeField] private int _damage;
        [SerializeField] private Animator _anim;

        private void Update()
        {
            if (_timeBtwAttack <= 0)
            {
                if (Input.GetMouseButton(0))
                {
                    _anim.SetTrigger(_animAttack);
                    Collider[] enemies = Physics.OverlapSphere(_attackPos.position, _attackRange, _enemy);
                    for (int i = 0; i < enemies.Length; i++)
                    {
                        enemies[i].GetComponent<Health>().Hit(_damage);
                    }
                }
                _timeBtwAttack = _startTimeBtwAtack;
            }
            else
            {
                _timeBtwAttack -= Time.deltaTime;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(_attackPos.position, _attackRange);
        }
    }
}