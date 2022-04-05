using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    public class CloseDoor : Door
    {
        void Start()
        {
            _open = false;
        }

        void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && !_open)
            {
                var player = other.GetComponent<Player>();
                if (player.inv.Find(item => item.Contains("Key")) == "Key")
                {
                    _open = true;
                    _door.Rotate(Vector3.up, 90);
                }
            }
        }
    }
}