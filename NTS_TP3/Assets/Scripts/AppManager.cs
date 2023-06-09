using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TP3
{

    public class AppManager : MonoBehaviour
    {
        public GameObject enemyPrefab;
        public Transform cam;
        public float spawnRange = 1f;
        

        // Start is called before the first frame update
        void Start()
        {
            SpawnEnemy();
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void SpawnEnemy()
        {
            var x = cam.transform.position.x + Random.Range(-spawnRange, spawnRange);
            var y = cam.transform.position.y + Random.Range(-spawnRange, spawnRange);
            var z = cam.transform.position.z + Random.Range(-spawnRange, spawnRange);
            var spawnPos = new Vector3(x, y, z);
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}