using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Quest
{
    public class ColdToHot : MonoBehaviour
    {
        private ColorGrading _colorGrading;
        
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.TryGetComponent(out SphereCollider PPV))
            {
                _colorGrading = ScriptableObject.CreateInstance<ColorGrading>();
                _colorGrading.enabled.Override(true);
                _colorGrading.temperature.Override(100); 
                var settings = new PostProcessEffectSettings[] { _colorGrading };
                PostProcessManager.instance.QuickVolume(gameObject.layer, 1, settings);
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            _colorGrading.temperature.Override(-100); 
            var settings = new PostProcessEffectSettings[] { _colorGrading };
            PostProcessManager.instance.QuickVolume(gameObject.layer, 1, settings);
        }


    }
}