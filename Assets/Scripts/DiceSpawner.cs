using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DiceSpawner : MonoBehaviour
{
    public GameObject dicePrefab;
    public Camera mainCamera;

    public GameObject FinalOutputPannel;
    public bool rPaused = false;


    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (GameObject.FindWithTag("Dice") == null)
            {
                if (rPaused == false)
                {
                    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        SpawnDice(hit.point);
                    }
                }   
            }
            else
            {
                Debug.Log("Dice already exists, cannot spawn another one.");
            }
        }
    }
   
    void SpawnDice(Vector3 spawnPosition)
    {
        GameObject dice = Instantiate(dicePrefab, spawnPosition + Vector3.up * 2, Quaternion.identity);
        Rigidbody rb = dice.GetComponent<Rigidbody>();

        // Generate random direction and magnitude for force
        float forceMagnitude = Random.Range(3f, 8f); // Randomize force strength
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(0.5f, 1f), Random.Range(-1f, 1f)).normalized;
        Vector3 randomForce = randomDirection * forceMagnitude;

        // Generate random torque (spin) for the dice
        Vector3 randomTorque = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));

        // Apply the random force and torque
        rb.AddForce(randomForce, ForceMode.Impulse);
        rb.AddTorque(randomTorque, ForceMode.Impulse);
        
        Invoke("outputEnable", 1.5f);
    }

    public void outputEnable()
    {

        FinalOutputPannel.gameObject.SetActive(true);
        rPaused = true;
    }

    public void outputDisable()
    {
        FinalOutputPannel.gameObject.SetActive(false);
        rPaused = false;
    }
}

