using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingCamera : MonoBehaviour
{
    public GameObject particleEffect;
    private Vector2 touchpos;
    private RaycastHit hit;
    private Camera cam;
    private int _count = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount <= 0) return;
        touchpos = Input.GetTouch(0).position;
        var ray = cam.ScreenPointToRay(touchpos);
        if (Physics.Raycast(ray, out hit))
        {
            var hitObj = hit.collider.gameObject;
            if (hitObj.CompareTag("Enemy"))
            {
                Destroy(hitObj);
                _count--;
            }
        }
    }
}
