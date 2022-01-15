using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    public float health = 100f;

    [Tooltip("Point de spawn des ia")]
    public Transform spawnPoint;

    [System.Serializable]
    public class Wave
    {
        public int nbSpawn;
        public Transform prefabSpawn;
    }

    [Tooltip("Vagues d'ennemis")]
    public Wave[] waves = new Wave[0];
    private int currentWave = 0;
    private int nbSpawned = 0;


    private float timeSpawn = 0;
    [Range(0, 15)]
    public float timeNextSpawn = 1;
    private float timeWave = 0;
    [Range(10, 50)]
    public float timeNextWave = 1;
    public ParticleSystem activationParticles;

    void Start()
    {
        currentWave = 0;
        nbSpawned = 0;
    }

    Transform SpawnAI(Transform prefabAI)
    {
        Transform ai = GameObject.Instantiate<Transform>(prefabAI);
        ai.position = spawnPoint.position;
        ai.rotation = spawnPoint.rotation;
        return ai;
    }

    void AddImpulse(Transform ai, Vector3 impulse)
    {
        Rigidbody rb = ai.GetComponent<Rigidbody>();
        rb.AddForce(impulse, ForceMode.Impulse);
    }

    public float time = 0;
    [Range(0, 15)]
    public float timeMax = 1;

    private Vector3 lastImpulse;

    // Update is called once per frame
    void Update()
    {
        timeWave += Time.deltaTime;
        if (timeWave >= timeNextWave)
        {
            timeWave = 0;
            currentWave++;
            nbSpawned = 0;
        }

        if (currentWave < waves.Length)
        {
            Wave waveNow = waves[currentWave];
            int nbToSpawn = waveNow.nbSpawn;
            if (nbSpawned < nbToSpawn)
            {
                timeSpawn = timeSpawn + Time.deltaTime;
                if (timeSpawn >= timeNextSpawn)
                {
                    Transform ai = SpawnAI(waveNow.prefabSpawn);
                    nbSpawned++;
                    Vector3 impulse = ai.forward * 5;
                    impulse.x += Random.Range(-2.0f, 2.0f);
                    impulse.y += Random.Range(0.0f, 2.0f);

                    AddImpulse(ai, impulse);
                    lastImpulse = impulse;
                    timeSpawn = 0;

                }
            }
        }
    }
}