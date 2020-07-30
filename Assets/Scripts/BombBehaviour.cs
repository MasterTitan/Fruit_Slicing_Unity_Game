using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    public float verticalSpeedAtStart = 19.0F;
    public float maxHorizontalSpeedAtStart = 3.0F;
    public float gravity = 15.0F;
    public float maxRotationAtStart = 190;

    bool explodeTriggred = false;


    Vector3 moveVector = Vector3.zero;
    Vector3 rotateVector = Vector3.zero;

    public GameObject explodeParticles;



    // Start is called before the first frame update
    void Start()
    {

        moveVector.y = verticalSpeedAtStart + Random.Range(-3.0F, 1.0F);
        moveVector.x = Random.Range(-maxHorizontalSpeedAtStart, maxHorizontalSpeedAtStart);


        rotateVector.x = Random.Range(-maxRotationAtStart, maxRotationAtStart);
        rotateVector.y = Random.Range(-maxRotationAtStart, maxRotationAtStart);
        rotateVector.z = Random.Range(-maxRotationAtStart, maxRotationAtStart);


        Invoke("DestroyGameObj", 9.0F);

    }

    // Update is called once per frame
    void Update()
    {

        if (!explodeTriggred)
        {
            transform.Translate(moveVector * Time.deltaTime, Space.World);
            transform.Rotate(rotateVector * Time.deltaTime, Space.World);

            moveVector.y -= (gravity * Time.deltaTime);
        }
        
        
    }


    public void SetExplodeTriggred(bool arg_explodeTriggred) {
        explodeTriggred = arg_explodeTriggred;
    }


    void DestroyGameObj()
    {

        Destroy(gameObject);

    }
}
