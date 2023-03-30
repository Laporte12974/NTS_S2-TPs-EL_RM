using System;
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
        public Text timer;
  
        public AudioClip[] _explosionSounds;
        public AudioClip laserSound;
        public ParticleSystem _explosionParticles;

        // Start is called before the first frame update
        void Start()
        {
            _appManager = arorigin.GetComponent<AppManager>();
            cam = GetComponent<Camera>();
       
            _explosionSounds[0] = Resources.Load<AudioClip>("SoundEffects/explosion.wav");
            _explosionSounds[1] = Resources.Load<AudioClip>("SoundEffects/synthetic_explosion_1.flac");
            _explosionSounds[2] = Resources.Load<AudioClip>("SoundEffects/Chunky Explosion.mp3");
            laserSound = Resources.Load<AudioClip>("SoundEffects/laser5.wav");
        }

        // Update is called once per frame
        public float tmpTime = 120;
        int minutes, seconds;
        void Update()
        {
            
            tmpTime = tmpTime - Time.deltaTime;
 
            minutes = (int) tmpTime / 60;
 
            seconds = (int) tmpTime % 60;
            
            timer.text = "Time remaining: " + minutes+":"+Math.Round((double)seconds);
            text.text = "Ennemies killed: " + _count;
            
            if (Input.touchCount <= 0) return;
            AudioSource.PlayClipAtPoint(laserSound, transform.position);
            touchpos = Input.GetTouch(0).position;
            var ray = cam.ScreenPointToRay(touchpos);
            
            if (Physics.Raycast(ray, out hit))
            {
                var hitObj = hit.collider.gameObject;
                if (hitObj.CompareTag("Enemy"))
                {
                    _explosionParticles.Play();
                    AudioSource.PlayClipAtPoint(_explosionSounds[Random.Range(0, _explosionSounds.Length)], hitObj.transform.position);
                    Destroy(hitObj);
                    _count++;
                    _appManager.SpawnEnemy();
                }
            }

        }
    }
}