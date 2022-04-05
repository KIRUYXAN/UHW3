using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    public class Player : MonoBehaviour, ITakeItem
    {
        [SerializeField] private float speed = 1.5f;
        [SerializeField] private float speedr = 25f;
        private Vector3 _direction;
        private bool _activated;
        private bool _sprint;

        [HideInInspector] public List<string> inv;
        private bool _inv;

        [SerializeField] private float mineRate = 25f;
        [SerializeField] private Transform spawnm;
        [SerializeField] private GameObject minep;
        private float nextMine;

        void Start()
        {
            inv = new List<string>() {"Empty"};
        }
        void Update()
        {
            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");
            _sprint = Input.GetButton("Sprint");
            _activated = Input.GetButton("Activate");
            _inv = Input.GetButtonDown("Inventory");
            inventory();
        }

        void FixedUpdate()
        {
            move(Time.fixedDeltaTime);
            smine(minep);

            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * speedr, 0));
        }
        public void Item(string name)
        {
            inv.Remove("Empty");
            inv.Add(name);
        }

        private void inventory()
        {
            if (_inv)
            {
                foreach (string invs in inv)
                {
                    Debug.Log(invs);
                }
            }
        }
        private void move(float delta)
        {
            var fixedDirection = transform.TransformDirection(_direction.normalized);
            transform.position += fixedDirection * (_sprint ? speed * 2 : speed) * delta;
        }
        private void smine(GameObject minep)
        {
            if (_activated && Time.time >= nextMine)
            {
                var mineObj = Instantiate(minep, spawnm.position, spawnm.rotation);
                var mine = mineObj.GetComponent<Mine>();
                mine.Init(15f);
                nextMine = Time.time + mineRate;
            }
        }
    }
}
