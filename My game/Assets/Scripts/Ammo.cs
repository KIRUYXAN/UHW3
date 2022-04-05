using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    public class Ammo : MonoBehaviour
    {
        private float _speed;

        public void Init(float range, float speed)
        {
            _speed = speed;
            Destroy(gameObject, range);
        }

        void FixedUpdate()
        {
            transform.position += transform.up * _speed * Time.fixedDeltaTime;
        }
    }
}