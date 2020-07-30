using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitAfterCutBehaviour : MonoBehaviour
{

    public Transform part1;
    public Transform part2;


    Vector3 moveVectorPart1 = Vector3.zero;
    Vector3 moveVectorPart2 = Vector3.zero;

    Vector3 rotateVetorPart1 = Vector3.zero;
    Vector3 rotateVetorPart2 = Vector3.zero;



    public float maxRotationAtStart = 150.0F;
    float verticalSpeedAtStart = 3.0F;

    public float gravity = 15.0F;
    public float fruitSplitSpeed = 5.0F;


     public Color splashColor;



    // Start is called before the first frame update
    void Start()
    {

        rotateVetorPart1.x = Random.Range(-maxRotationAtStart, maxRotationAtStart);
        rotateVetorPart1.y = Random.Range(-maxRotationAtStart, maxRotationAtStart);
        rotateVetorPart1.z = Random.Range(-maxRotationAtStart, maxRotationAtStart);

        rotateVetorPart2.x = Random.Range(-maxRotationAtStart, maxRotationAtStart);
        rotateVetorPart2.y = Random.Range(-maxRotationAtStart, maxRotationAtStart);
        rotateVetorPart2.z = Random.Range(-maxRotationAtStart, maxRotationAtStart);


        moveVectorPart1.y += verticalSpeedAtStart;
        moveVectorPart2.y += verticalSpeedAtStart;

        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.pitch = Random.Range(0.7F, 1.3F);

        Invoke("DestroyGameObj", 9.0F);

    }

    // Update is called once per frame
    void Update()
    {
        part1.transform.Translate(moveVectorPart1 * Time.deltaTime, Space.World);
        part2.transform.Translate(moveVectorPart2 * Time.deltaTime, Space.World);

        part1.transform.Rotate(rotateVetorPart1 * Time.deltaTime, Space.World);
        part2.transform.Rotate(rotateVetorPart2 * Time.deltaTime, Space.World);

        moveVectorPart1.y -= gravity * Time.deltaTime;
        moveVectorPart2.y -= gravity * Time.deltaTime;

    }


    public void SetMotionAccToAngle(float arg_angle) {
        
        Vector3 splashPosition = transform.position;
        splashPosition.z = 9.0F;
        FruitSplashSpawner splashSpawner = GameObject.Find("GameManager").GetComponent<FruitSplashSpawner>();
        splashSpawner.SpawnARandomSplash(arg_angle, splashPosition, splashColor);

        transform.Rotate(new Vector3(0, 0, arg_angle));

        float radianAngle = (arg_angle * Mathf.PI) / 180;

        moveVectorPart1.x -= Mathf.Sin(radianAngle) * fruitSplitSpeed;
        moveVectorPart1.y += Mathf.Cos(radianAngle) * fruitSplitSpeed;

        moveVectorPart2.x += Mathf.Sin(radianAngle) * fruitSplitSpeed;
        moveVectorPart2.y -= Mathf.Cos(radianAngle) * fruitSplitSpeed;

    }




    void DestroyGameObj() {

        Destroy(gameObject);
    
    }

}
