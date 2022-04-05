using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    public class Mine : MonoBehaviour
    {
        public void Init(float mineLive)
        {
            Destroy(gameObject, mineLive);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
