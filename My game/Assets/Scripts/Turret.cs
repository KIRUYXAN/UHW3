using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private GameObject head;
        [SerializeField] private float _speedr = 0.6f;
        [SerializeField] private float viewr;


        [SerializeField] private GameObject bulletp;
        [SerializeField] private Transform spawnp;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float bulletRange;
        [SerializeField] private float fireRate;
        private float nextFire;
        void Start()
        {
            _player = FindObjectOfType<Player>();
        }

        void FixedUpdate()
        {
            var direction = _player.transform.position - head.transform.position;
            var step = Vector3.RotateTowards(head.transform.forward, direction, _speedr * Time.fixedDeltaTime, 0f);

            if (Vector3.Distance(transform.position, _player.transform.position) < viewr)
            {
                head.transform.rotation = Quaternion.LookRotation(step);
                if (Time.time >= nextFire)
                {
                    spawn(bulletp);
                    nextFire = Time.time + fireRate;
                }
            };
        }
        private void spawn(GameObject bulletp)
        {
            var bulletObj = Instantiate(bulletp, spawnp.position, spawnp.rotation);
            var bullet = bulletObj.GetComponent<Ammo>();
            bullet.Init(bulletRange, bulletSpeed);
        }
    }
}
