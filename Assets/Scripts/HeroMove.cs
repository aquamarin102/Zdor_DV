using UnityEngine;

namespace Quest
{
    [RequireComponent(typeof(AudioSource))]
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _runspeed = 10f;
        [SerializeField] private float _gravity = -9.8f;

        private string _horizontal = "Horizontal";
        private string _vertical = "Vertical";
        private string _run = "Run";
        private string _isMove = "isMove";

        private Vector3 _direction;
        private bool _isRunning;
        private float _deltaX, _deltaZ;
        private CharacterController _characterController;
        
        private Animator _anim;

        [SerializeField] private AudioSource _source;
        
        private void Start()
        {
            _source = GetComponent<AudioSource>();
            _anim = GetComponent<Animator>();
            _characterController = GetComponent<CharacterController>();
        }
        
        void Update()
        {

            _deltaX = Input.GetAxis(_horizontal) * (_isRunning ? _runspeed : _speed);
            _deltaZ = Input.GetAxis(_vertical) * (_isRunning ? _runspeed : _speed);

            _direction = new Vector3(_deltaX, 0, _deltaZ);
            _direction = Vector3.ClampMagnitude(_direction, (_isRunning ? _runspeed : _speed));
            _direction.y = _gravity;
            _direction *= Time.deltaTime;
            _direction = transform.TransformDirection(_direction);
            _characterController.Move(_direction);
        }

        private void FixedUpdate()
        {

            if (Input.GetButton(_vertical) || Input.GetButton(_horizontal))
            {
                
                _anim.SetBool(_isMove, true);
            }
            else
            {
                _anim.SetBool(_isMove, false);
                _source.Play();
            }
            _isRunning = Input.GetButton(_run);
            
        }
    }
}