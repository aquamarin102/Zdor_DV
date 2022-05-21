
using UnityEngine;

[RequireComponent((typeof(Animator)))]
public class IKControl : MonoBehaviour
{
   
   [SerializeField] private bool _ikActive;
   [SerializeField] private Transform _leftHandPoint;
   [SerializeField] private Transform _lookPoint;
   [SerializeField] private float _radiusLooking = 2 ;

   private Animator _animator;
   private void Awake()
   {
      _animator = GetComponent<Animator>();
      
   }

   private void OnAnimatorIK(int layerIndex)
   {
       
       if (_ikActive)
       {
           Vector3 distanceForLookPoint = _lookPoint.position - transform.position;
           if (distanceForLookPoint.x <= _radiusLooking && distanceForLookPoint.x >= -_radiusLooking && distanceForLookPoint.y <= _radiusLooking && distanceForLookPoint.y >= -_radiusLooking && distanceForLookPoint.z <= _radiusLooking && distanceForLookPoint.z >= -_radiusLooking)
           {
               _animator.SetLookAtWeight(1);
               _animator.SetLookAtPosition(_lookPoint.position);
           }

           _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
           _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
           _animator.SetIKPosition(AvatarIKGoal.LeftHand, _leftHandPoint.position);
           _animator.SetIKRotation(AvatarIKGoal.LeftHand, _leftHandPoint.rotation);
           
       }
       else
       {
           _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
           _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
           _animator.SetLookAtWeight(0);
       }
   }

   
}
