using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    public class Item : MonoBehaviour
    {
        private void OnTriggerEnter(Collider colission)
        {
            if (colission.gameObject.TryGetComponent(out ITakeItem takeItem))
            {
                takeItem.Item(name);
                Destroy(gameObject);
            }
        }
    }
}
