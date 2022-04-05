using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    public class Fire : MonoBehaviour
    {
        public GameObject ammop;
        public Transform spawnp;
        public float ammoSpeed;
        public float ammoRange;
        public float fireRate;
        private float nextFire;
        private bool _spawn;
        void Update()
        {
            if (Input.GetButton("Fire1")) _spawn = true;
        }
        private void FixedUpdate()
        {
            if (_spawn && Time.time > nextFire)
            {
                _spawn = false;
                nextFire = Time.time + fireRate;
                spawn(ammop);
            }
            else _spawn = false;
        }
        private void spawn(GameObject ammop)
        {
            var ammoObj = Instantiate(ammop, spawnp.position, spawnp.rotation);
            var ammo = ammoObj.GetComponent<Ammo>();
            ammo.Init(ammoRange, ammoSpeed);
        }
    }
}