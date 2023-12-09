using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cube;
    public GameObject RedCube;
    public AudioClip song;

    public AudioSource audioSource;

    public Vector3 spawnOffset = new Vector3(0.0f, 1.5f, 1.0f);
    public float xRange = 0.8f;
    public float yRange = 0.3f;
    public float minDistance = 12f; // Minimum distance from the player
    public float minSpawnDelay = 1.5f;
    public float maxSpawnDelay = 2.0f;

    public float beat = 60 / 105;
    private float timer;
    private int beatIndex = 0;

    private float lastSpawnTime;
    private bool canSpawn = true; // Variable to control spawning

    public float endTime = 60f; // Set the default end time

    public float[] beats = {
    0.191377f, 0.510339f, 0.820188f, 1.120924f, 1.412546f,
    1.740622f, 2.041357f, 2.351206f, 2.560810f, 2.952678f,
    3.253413f, 3.572375f, 3.873111f, 4.173847f, 4.501922f,
    4.802658f, 4.994035f, 5.404129f, 5.704865f, 6.005601f,
    6.351902f, 6.643525f, 6.926034f, 7.244996f, 7.454600f,
    7.846468f, 8.165430f, 8.484392f, 8.776014f, 9.085863f,
    9.404825f, 10.051863f, 10.981521f, 11.843864f, 12.484898f,
    13.393029f, 13.660691f, 14.324055f, 14.789568f, 15.842695f,
    16.598199f, 17.346072f, 18.277097f, 19.192860f, 19.803368f,
    20.734394f, 21.535686f, 22.191983f, 23.161165f, 24.130347f,
    24.626385f, 27.175258f, 29.685974f, 30.319377f, 30.952779f,
    31.998275f, 35.218707f, 39.499898f, 40.133300f, 40.797228f,
    41.911406f, 44.376334f, 49.298559f, 49.924330f, 50.534838f,
    51.137715f, 52.358732f, 53.572118f, 54.800766f, 56.006520f,
    57.280957f, 58.463817f, 59.081957f, 59.692465f, 60.089296f
};

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = Time.time;

        audioSource = GetComponent<AudioSource>();
        // Delay the start of the song playback by a certain amount of time (adjust as needed)
        float delay = 9.3f; // Adjust this delay as needed
        Invoke("StartSongPlayback", delay);
    }

    void StartSongPlayback()
    {
        // Start playing the song when the delay is over
        audioSource.clip = song;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // if (beatIndex >= beats.Count) // we have reached the end of the array
        if (beatIndex >= beats.Length)
        {
            canSpawn = false;
            // Debug.Log("BEAT INDEX: " + beatIndex + "beats lenght: " + beats.Length);
        }
        else if (timer > beats[beatIndex])
        {
            // Debug.Log("Beatindex: " + beatIndex + "beats[Beatindex]: " + beats[beatIndex] + "timer: " + timer);

            // if (canSpawn && CanSpawnCube())
            if (canSpawn) 
            {
                SpawnCube();
            }

            beatIndex++;

            timer = 0f;
            // timer -= beat;
        }

        timer += Time.deltaTime;

        // Check if the 'Q' key is pressed or 'B' key is pressed
        if (Input.GetKeyDown(KeyCode.Q) || OVRInput.GetDown(OVRInput.RawButton.B))
        {
            // Toggle spawning when the 'Q' key is pressed
            ToggleSpawn();
        }

        // Calculate the end time dynamically based on the last beat in the array
        endTime = Mathf.Max(endTime, beats[beats.Length - 1]);
    }

/*    bool CanSpawnCube()
    {
        float elapsedTimeSinceLastSpawn = Time.time - lastSpawnTime;
        float randomSpawnDelay = UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay);
        
        return elapsedTimeSinceLastSpawn > randomSpawnDelay;
    } */

    void SpawnCube()
    {
        float x = UnityEngine.Random.Range(-xRange, xRange);
        float y = UnityEngine.Random.Range(-yRange / 2.0f, yRange);

        float xr = UnityEngine.Random.Range(-xRange, xRange);
        float yr = UnityEngine.Random.Range(-yRange / 2.0f, yRange);

        Vector3 spawnPos = transform.position - new Vector3(0.0f, 0.0f, spawnOffset.z);
        Vector3 directionToPlayer = (transform.position - spawnPos).normalized;
        Vector3 initialPos = new Vector3(x, y, 0.0f) + directionToPlayer * minDistance;
        
        Vector3 initialPosRed = new Vector3(xr, yr, 0.0f) + directionToPlayer * minDistance;

        // BlueCube is Cube
        GameObject blue = Instantiate(cube, initialPos, Quaternion.identity);
        blue = blue.transform.Find("Cube").gameObject;

        blue.transform.Rotate(transform.forward, 90 * UnityEngine.Random.Range(0, 4));

        Rigidbody rbBlue = blue.GetComponent<Rigidbody>();
        rbBlue.useGravity = false;

        // RedCube is Cube
        GameObject red = Instantiate(RedCube, initialPosRed, Quaternion.identity);
        red = red.transform.Find("Cube").gameObject;

        red.transform.Rotate(transform.forward, 90 * UnityEngine.Random.Range(0, 4));

        Rigidbody rbRed = red.GetComponent<Rigidbody>();
        rbRed.useGravity = false;


        float theta = UnityEngine.Random.Range((float)(Math.PI / 4.0f), (float)(3.0f * Math.PI / 4.0f));
        // float mag = UnityEngine.Random.Range(1.0f, 3.0f);
        float mag = 1.0f;
        Vector3 addedVelocity = -directionToPlayer * mag;

        rbBlue.AddForce(addedVelocity, ForceMode.VelocityChange);
        rbRed.AddForce(addedVelocity, ForceMode.VelocityChange);
        
        
        float scale = UnityEngine.Random.Range(0.1f, 0.25f);
        blue.transform.localScale = new Vector3(scale, scale, scale);
        red.transform.localScale = new Vector3(scale, scale, scale);

        lastSpawnTime = Time.time;
    }

    // Method to toggle spawning on/off
    public void ToggleSpawn()
    {
        canSpawn = !canSpawn;
    }
}

