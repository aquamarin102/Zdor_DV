using UnityEngine;
using UnityEngine.UI;

namespace Quest
{
    public class HeroHealth : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 10f;
        [SerializeField] private float curHealth;
        private float _sliderValue;
        private void Awake()
        {
            curHealth = maxHealth;
        }
        private void Update()
        {
            _sliderValue = (curHealth/maxHealth);
        }
        public void Hit(float damage)
        {
            curHealth -= damage;
            if (curHealth <= 0)
            {
                Die();
            }
        }
        public void Heal(float hp)
        {
            curHealth += hp;
            if (curHealth <= 0)
            {
                return;
            }
        }
        private void Die()
        {
            Destroy(gameObject);
        }
        private void OnGUI()
        {
            _sliderValue = GUI.HorizontalSlider(new Rect(25, 25, 300, 60), _sliderValue, 0, 1);
        }
    }
}
