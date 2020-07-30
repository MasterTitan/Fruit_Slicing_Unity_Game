using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeSlashBehaviour : MonoBehaviour
{


    Plane fruitPlane;
    Vector3 touchPointOnPlane = Vector3.zero;

    private Vector3 previousPosition = Vector3.zero;
    public FruitSpawner fruitSpawnerr;

    public Animator cameraAnimator;
    public Animator pannelAnimator;

    public Text scoreText;
    public Text missedText;

    int score = 0;
    int missed = 0;


    // Start is called before the first frame update
    void Start()
    {
        fruitPlane = new Plane(Vector3.back, Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButton(0)) {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            float distance = 0;

            if (fruitPlane.Raycast(ray, out distance)) {
                touchPointOnPlane = ray.GetPoint(distance);

                transform.SetPositionAndRotation(touchPointOnPlane, Quaternion.identity);

                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject gameObjectHit = hit.transform.gameObject;

                    if (gameObjectHit.CompareTag("Fruit"))
                    {


                        ///////////// OLD CODE
                        /*  
                         * 
                        float dX = previousPosition.x - transform.position.x;

                        float dY = previousPosition.y - transform.position.y;

                        float theta = 0.0F;

                        if (dX == 0.0F)
                        {
                            if (dY > 0.0F) { theta = 90.0F; }
                            else { theta = 270.0F; }
                        }
                        else {

                            float tanTheta = dY / dX;

                            theta = Mathf.Atan(tanTheta);

                            theta = (tanTheta * 180) / Mathf.PI;

                        }
                        */

                        ///////////// NEW CODE /////////////

                        Vector3 targetDir = previousPosition - transform.position;

                        float theta = Vector3.SignedAngle(targetDir, Vector3.right, Vector3.back);

                        ///////////// -------- /////////////



                        gameObjectHit.GetComponent<FruitBeforeCut>().InitiateTheFruitAfterCut(theta);


                        score++;
                        // use string builder instead (for optimised code). Im not doing it coz lazy
                        scoreText.text = "Score: " + score;

                        Destroy(gameObjectHit);

                    }

                    if (gameObjectHit.CompareTag("bomb"))
                    {
                        gameObjectHit.GetComponent<BombBehaviour>().SetExplodeTriggred(true);
                        gameObjectHit.GetComponent<BombBehaviour>().explodeParticles.SetActive(true);
                        fruitSpawnerr.spawnZeeFruits = false;

                        cameraAnimator.SetTrigger("shake");
                        pannelAnimator.SetTrigger("white");
                        Invoke("UnsetTrigger", 0.2F);

                    }

                }

            }



        }

        previousPosition = transform.position;

    }


    void UnsetTrigger() {
        cameraAnimator.ResetTrigger("shake");
        pannelAnimator.ResetTrigger("white");
    }


    public void IncrementMissed() {
        missed++;
        missedText.text = "Missed: " + missed;


        if (missed >=3) {
            //game over
            fruitSpawnerr.spawnZeeFruits = false;

            //cameraAnimator.SetTrigger("shake");
            pannelAnimator.SetTrigger("white");
            Invoke("UnsetTrigger", 0.2F);
        }
    }
}
