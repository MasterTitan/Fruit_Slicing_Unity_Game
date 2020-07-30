using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FruitSpawner : MonoBehaviour
{



    public List<Transform> allFruits;

    public Transform bombPrefab;

    public bool spawnZeeFruits = true;

    AudioSource fruitLunchAudio;

    [Range(1,7)]
    public int difficulty = 1;

    int numberOfFruits = 2;

    // Start is called before the first frame update
    void Start()
    {

        fruitLunchAudio = gameObject.GetComponent<AudioSource>();
        StartCoroutine(SpawnARandomFruit());
        StartCoroutine(IncreaseDifficulty());
        
    }


    IEnumerator SpawnARandomFruit() {

        while (spawnZeeFruits) {

            if (difficulty > 5)
            {
                numberOfFruits = UnityEngine.Random.Range(3, 7);
            }
            else if (difficulty > 3)
            {
                numberOfFruits = UnityEngine.Random.Range(2, 5);
            }
            else if (difficulty > 1)
            {
                numberOfFruits = UnityEngine.Random.Range(1, 5);
            }
            else {
                numberOfFruits = UnityEngine.Random.Range(1, 3);
            }



            for (int i = 0; i < numberOfFruits; i++) {

                Spawn(-1.5F + (UnityEngine.Random.Range(0,7)*0.5F), 
                    0.0F + (0.5F * i));

            }


            fruitLunchAudio.pitch = UnityEngine.Random.Range(0.7F, 1.3F);
            fruitLunchAudio.Play();


            if (UnityEngine.Random.Range(1, 9) <= difficulty) {
                SpawnBomb(0.0F, -5.5F);
            }


            yield return new WaitForSeconds(2.0F);
        
        }
    
    }

    private void Spawn(float xPos, float zPos)
    {
        //spawn    
        int randomFruitNumber = UnityEngine.Random.Range(0, allFruits.Capacity - 1);

        Instantiate(allFruits[randomFruitNumber], new Vector3(xPos, -9.0F, zPos), Quaternion.identity);
    }





    private void SpawnBomb(float xPos, float zPos)
    {
        //spawn    
        

        Instantiate(bombPrefab, new Vector3(xPos, -10.0F, zPos), Quaternion.identity);
    }



    IEnumerator IncreaseDifficulty() {
        yield return new WaitForSeconds(7);
        while (difficulty < 7) {
            difficulty++;
            yield return new WaitForSeconds(11);
        }
    }


    public void ResetLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
