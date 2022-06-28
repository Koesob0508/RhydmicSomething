using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype02
{
    public abstract class P2EnemyController : MonoBehaviour
    {
        [SerializeField] private P2Player targetPlayer;
        [SerializeField] private P2Enemy character;
        private Vector2 direction;
        private Vector2 normalizedDirection;

        void FixedUpdate()
        {
            direction = targetPlayer.transform.position - this.transform.position;
            normalizedDirection = new Vector2(direction.x, direction.y).normalized;

            character.Move(normalizedDirection);
        }

        public void Initialize(P2Player _player)
        {
            this.targetPlayer = _player;
            this.character = this.gameObject.GetComponent<P2Enemy>();
        }
    }

}

