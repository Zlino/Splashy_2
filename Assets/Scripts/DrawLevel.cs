﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLevel : MonoBehaviour
{
    public static bool gameIsRunning;

    public GameObject platformPrefab;
    public GameObject platformBonusPrefab;
    public GameObject platformBumpPrefab;
    public GameObject lastPlatformPrefab;
    public GameObject hourglassPrefab;

    private float maxSpacingPlatformValue = 1.38f;
    private float spacingPlatformValue = 1.35f;
    private float z_minGameArea = -5;
    private float z_maxGameArea = 5;
    private float platformNumber = 50;

    private void Awake()
    {
        gameIsRunning = false;
        Application.targetFrameRate = 60;
        Time.timeScale = 2f;
    }

    // Start is called before the first frame update
    void Start()
    {
        float x_spawnValue = spacingPlatformValue;
        float z_spawnValue = -0.538f;
        float randomValue = 0;

        for (int i = 0; i < platformNumber; i++)
        {
            z_spawnValue += Random.Range(-maxSpacingPlatformValue, maxSpacingPlatformValue);
            z_spawnValue = Mathf.Min(z_maxGameArea, Mathf.Max(z_spawnValue, z_minGameArea));

            //88% chance to have a normal platform | 6% chance to have a bump platform | 6% chance to have a bonus platform
            if ((platformNumber - i) > 5)
            {
                randomValue = Random.value;
                if (randomValue <= 0.88f)
                {
                    //7% chance to have a SlowBonus
                    if (Random.value <= 0.07f)
                    {
                        GameObject instantiatePlatform = Instantiate(platformPrefab, new Vector3(x_spawnValue, 0, z_spawnValue), Quaternion.identity);
                        Transform floorInstantiatePlatform = instantiatePlatform.transform.GetChild(0).transform;
                        Instantiate(hourglassPrefab, new Vector3(floorInstantiatePlatform.transform.position.x, 0.140f, floorInstantiatePlatform.transform.position.z), Quaternion.identity, instantiatePlatform.transform);
                    }
                    else
                        Instantiate(platformPrefab, new Vector3(x_spawnValue, 0, z_spawnValue), Quaternion.identity);
                }
                else if (randomValue <= 0.94f)
                    Instantiate(platformBumpPrefab, new Vector3(x_spawnValue, 0, z_spawnValue), Quaternion.identity);
                else
                    Instantiate(platformBonusPrefab, new Vector3(x_spawnValue, 0, z_spawnValue), Quaternion.identity);
            }
            //7% chance to have a SlowBonus
            else if (Random.value <= 0.07f)
            {
                GameObject instantiatePlatform = Instantiate(platformPrefab, new Vector3(x_spawnValue, 0, z_spawnValue), Quaternion.identity);
                Transform floorInstantiatePlatform = instantiatePlatform.transform.GetChild(0).transform;
                Instantiate(hourglassPrefab, new Vector3(floorInstantiatePlatform.transform.position.x, 0.140f, floorInstantiatePlatform.transform.position.z), Quaternion.identity, instantiatePlatform.transform);
            }
            else
                Instantiate(platformPrefab, new Vector3(x_spawnValue, 0, z_spawnValue), Quaternion.identity);

            // 40% chance to have a second platform spawn
            if (Random.value <= 0.40f)
            {
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

                //88% chance to have a normal platform | 6% chance to have a bump platform | 6% chance to have a bonus platform
                if ((platformNumber - i) > 5)
                {
                    randomValue = Random.value;
                    if (randomValue <= 0.88f)
                    {
                        //7% chance to have a SlowBonus
                        if (Random.value <= 0.07f)
                        {
                            GameObject instantiatePlatform = Instantiate(platformPrefab, new Vector3(x_spawnValue, 0, (z_spawnValue + z_bonusSpawn)), Quaternion.identity);
                            Transform floorInstantiatePlatform = instantiatePlatform.transform.GetChild(0).transform;
                            Instantiate(hourglassPrefab, new Vector3(floorInstantiatePlatform.transform.position.x, 0.140f, floorInstantiatePlatform.transform.position.z), Quaternion.identity, instantiatePlatform.transform);
                        }
                        else
                            Instantiate(platformPrefab, new Vector3(x_spawnValue, 0, (z_spawnValue + z_bonusSpawn)), Quaternion.identity);
                    }
                    else if (randomValue <= 0.94f)
                        Instantiate(platformBumpPrefab, new Vector3(x_spawnValue, 0, (z_spawnValue + z_bonusSpawn)), Quaternion.identity);
                    else
                        Instantiate(platformBonusPrefab, new Vector3(x_spawnValue, 0, (z_spawnValue + z_bonusSpawn)), Quaternion.identity);
                }
                //7% chance to have a SlowBonus
                else if (Random.value <= 0.07f)
                {
                    GameObject instantiatePlatform = Instantiate(platformPrefab, new Vector3(x_spawnValue, 0, (z_spawnValue + z_bonusSpawn)), Quaternion.identity);
                    Transform floorInstantiatePlatform = instantiatePlatform.transform.GetChild(0).transform;
                    Instantiate(hourglassPrefab, new Vector3(floorInstantiatePlatform.transform.position.x, 0.140f, floorInstantiatePlatform.transform.position.z), Quaternion.identity, instantiatePlatform.transform);
                }
                else
                    Instantiate(platformPrefab, new Vector3(x_spawnValue, 0, (z_spawnValue + z_bonusSpawn)), Quaternion.identity);
            }

            x_spawnValue += spacingPlatformValue;
        }

        z_spawnValue += Random.Range(-maxSpacingPlatformValue, maxSpacingPlatformValue);
        z_spawnValue = Mathf.Min(z_maxGameArea, Mathf.Max(z_spawnValue, z_minGameArea));

        Instantiate(lastPlatformPrefab, new Vector3(x_spawnValue, 0, z_spawnValue), Quaternion.identity);
    }
}
