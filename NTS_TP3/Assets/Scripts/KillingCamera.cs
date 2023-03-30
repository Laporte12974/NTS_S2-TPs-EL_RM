using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TP3
{

    public class KillingCamera : MonoBehaviour
    {
        [SerializeField] GameObject arorigin;
        AppManager _appManager;
        private Vector2 touchpos;
        private RaycastHit hit;
        private Camera cam;
        public int _count = 0;
        public Text text;

        // Start is called before the first frame update
        void Start()
        {
            _appManager = arorigin.GetComponent<AppManager>();
            cam = GetComponent<Camera>();
        }

        // Update is called once per frame
        void Update()
        {
            text.text = "Ennemies killed: " + _count;
            if (Input.touchCount <= 0) return;
            touchpos = Input.GetTouch(0).position;
            var ray = cam.ScreenPointToRay(touchpos);
            if (Physics.Raycast(ray, out hit))
            {
                var hitObj = hit.collider.gameObject;
                if (hitObj.CompareTag("Enemy"))
                {
                    Destroy(hitObj);
                    _count++;
                    _appManager.SpawnEnemy();
                }
            }
        }
    }
}