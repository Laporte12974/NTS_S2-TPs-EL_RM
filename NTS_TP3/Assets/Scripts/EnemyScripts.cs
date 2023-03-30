using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScripts : MonoBehaviour
{
    private Transform camera;
    public Transform Propeller;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(camera);
        transform.rotation = Quaternion.Euler(Propeller.transform.rotation.eulerAngles.x, Propeller.transform.rotation.eulerAngles.y +10, Propeller.transform.rotation.eulerAngles.z);;
    }
}
