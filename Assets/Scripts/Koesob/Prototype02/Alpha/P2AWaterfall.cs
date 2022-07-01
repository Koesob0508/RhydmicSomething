using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype02
{
    public class P2AWaterfall : P2AttackRange
    {
        float axisZ = 0f;
        public float rotateSpeed;

        private void FixedUpdate()
        {
            axisZ += Time.fixedDeltaTime * rotateSpeed;
            transform.rotation = Quaternion.Euler(0f, 0f, axisZ);
        }
    }
}

