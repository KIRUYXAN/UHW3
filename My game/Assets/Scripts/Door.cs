using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    public class Door : MonoBehaviour
    {
        [SerializeField] public Transform _door;
        [HideInInspector] public bool _open = true;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && _open)
            {
                _door.Rotate(Vector3.up, 90);
            };
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") && _open)
            {
                _door.Rotate(Vector3.up, -90);
            };
        }
    }
}