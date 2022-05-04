using UnityEngine;

namespace Quest
{
    [RequireComponent(typeof(FindTarget))]

    public class LookTarget : MonoBehaviour
    {
        private FindTarget _findTarget;
        [SerializeField] private float _rotationSpeed = 5f;

        private void Start()
        {
            _findTarget = GetComponent<FindTarget>();
        }

        private void FixedUpdate()
        {
            if (!_findTarget.HasTarget)
            {
                return;
            }
            var direction = _findTarget.Target.position - transform.position;
            var step = Vector3.RotateTowards(transform.forward, direction, _rotationSpeed * Time.fixedDeltaTime, 0f);

            transform.rotation = Quaternion.LookRotation(step);
        }
    }
}