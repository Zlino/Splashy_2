﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLevel : MonoBehaviour
{
    public static bool gameIsRunning;

    public GameObject platformPrefab;
    public GameObject platformBumpPrefab;
    public GameObject lastPlatformPrefab;

    private float maxSpacingPlatformValue = 1.70f;
    private float spacingPlatformValue = 1.35f;
    private float z_minGameArea = -5;
    private float z_maxGameArea = 5;

#if UNITY_EDITOR
    public float Timescale = 1.5f;
#endif

    private void Awake()
    {
        gameIsRunning = false;
        Application.targetFrameRate = 60;
        Time.timeScale = 1.5f;
    }

    // Start is called before the first frame update
    void Start()
    {
        float x_spawnValue = spacingPlatformValue;
        float z_spawnValue = -0.538f;

        for (int i = 0; i < 1000; i++)
        {
            /*z_spawnValue += Random.Range(-maxSpacingPlatformValue, maxSpacingPlatformValue);
            z_spawnValue = Mathf.Min(z_maxGameArea, Mathf.Max(z_spawnValue, z_minGameArea));*/

            //80% chance to have a normal platform | 20% chance to have a bump platform
            if (Random.value <= 0.80f)
                Instantiate(platformPrefab, new Vector3(x_spawnValue, 0, z_spawnValue), Quaternion.identity);
            else
                Instantiate(platformBumpPrefab, new Vector3(x_spawnValue, 0, z_spawnValue), Quaternion.identity);

            // 25% chance to have a second platform spawn
            if (Random.value <= 1f)
            {
                //float z_bonusSpawn = z_spawnValue;
                float z_bonusSpawn = 0;
                if ((z_bonusSpawn + 1.35f) > z_maxGameArea)
                {
                    z_bonusSpawn += Random.Range((-maxSpacingPlatformValue - 1.3f), -1.35f);
                    z_bonusSpawn = Mathf.Min(z_maxGameArea, Mathf.Max(z_bonusSpawn, z_minGameArea));
                }
                else if((z_bonusSpawn - 1.35f) < z_minGameArea)
                {
                    z_bonusSpawn += Random.Range(1.35f, (maxSpacingPlatformValue + 1.3f));
                    z_bonusSpawn = Mathf.Min(z_maxGameArea, Mathf.Max(z_bonusSpawn, z_minGameArea));
                }
                else
                {
                    z_bonusSpawn += Random.Range(1.35f, (maxSpacingPlatformValue + 1.3f));
                    if (Random.value <= 0.5f)
                        z_bonusSpawn *= -1;
                    z_bonusSpawn = Mathf.Min(z_maxGameArea, Mathf.Max(z_bonusSpawn, z_minGameArea));
                }

                //80% chance to have a normal platform | 20% chance to have a bump platform
                if (Random.value <= 0.80f)
                    Instantiate(platformPrefab, new Vector3(x_spawnValue, 0, (z_spawnValue + z_bonusSpawn)), Quaternion.identity);
                else
                    Instantiate(platformBumpPrefab, new Vector3(x_spawnValue, 0, (z_spawnValue + z_bonusSpawn)), Quaternion.identity);
            }

            x_spawnValue += spacingPlatformValue;
        }

        z_spawnValue += Random.Range(-maxSpacingPlatformValue, maxSpacingPlatformValue);
        z_spawnValue = Mathf.Min(z_maxGameArea, Mathf.Max(z_spawnValue, z_minGameArea));

        Instantiate(lastPlatformPrefab, new Vector3(x_spawnValue, 0, z_spawnValue), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        Time.timeScale = Timescale;
#endif
    }
}
