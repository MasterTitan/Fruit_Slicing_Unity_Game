using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBeforeCut : MonoBehaviour
{

    public float verticalSpeedAtStart = 19.0F;
    public float maxHorizontalSpeedAtStart = 3.0F;
    public float gravity = 15.0F;
    public float maxRotationAtStart = 150;

    public float missedDistance = -5.65F;


    Vector3 moveVector = Vector3.zero;
    Vector3 rotateVector = Vector3.zero;


    public Transform fruitAfterCutObject;
    KnifeSlashBehaviour knifeSlashBehaviourr;

    // Start is called before the first frame update
    void Start()
    {

        moveVector.y = verticalSpeedAtStart + Random.Range(-3.0F, 1.0F);
        moveVector.x = Random.Range(-maxHorizontalSpeedAtStart, maxHorizontalSpeedAtStart);


        rotateVector.x = Random.Range(-maxRotationAtStart, maxRotationAtStart);
        rotateVector.y = Random.Range(-maxRotationAtStart, maxRotationAtStart);
        rotateVector.z = Random.Range(-maxRotationAtStart, maxRotationAtStart);

        knifeSlashBehaviourr = GameObject.Find("KnifeSlash").GetComponent<KnifeSlashBehaviour>();



      

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveVector * Time.deltaTime, Space.World);
        transform.Rotate(rotateVector * Time.deltaTime, Space.World);

        moveVector.y -= (gravity * Time.deltaTime);

        if (moveVector.y < 0.0F && transform.position.y < missedDistance) {
            DestroyGameObj();
        }
    }

    public void InitiateTheFruitAfterCut(float arg_cutAngle) {


        Transform obj = Instantiate(fruitAfterCutObject, transform.position, Quaternion.identity);
        
        obj.gameObject.GetComponent<FruitAfterCutBehaviour>().SetMotionAccToAngle(arg_cutAngle);

    }



    void DestroyGameObj()
    {

        if (gameObject.activeSelf) {
            knifeSlashBehaviourr.IncrementMissed();
        }

        Destroy(gameObject);

    }

}
