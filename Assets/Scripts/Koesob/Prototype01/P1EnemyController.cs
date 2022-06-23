using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace prototype01
{
    public class P1EnemyController : MonoBehaviour
    {
        [SerializeField] private P1Player target;
        [SerializeField] private P1Enemy character;
        private Vector3 direction;
        private Vector2 normalizedDirection;

        void FixedUpdate()
        {
            direction = target.transform.position - this.transform.position;
            normalizedDirection = new Vector2(direction.z, direction.x).normalized;
            
            character.Move(normalizedDirection);
        }

        public void Initialize(P1Player _player)
        {
            this.target = _player;
            this.character = this.gameObject.GetComponent<P1Enemy>();
        }
    }

}
