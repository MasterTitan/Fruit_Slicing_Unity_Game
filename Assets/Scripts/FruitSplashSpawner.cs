using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSplashSpawner : MonoBehaviour
{

    public List<Transform> allSplashes;
    private Quaternion rotation;

    public void SpawnARandomSplash(float arg_angle, Vector3 arg_spawn_position, Color arg_splashColor) {

        int aRandomIndex = Random.Range(0, allSplashes.Capacity-1);

        rotation = Quaternion.identity;

        rotation.eulerAngles = new Vector3(0,0, arg_angle - 45.0F);

        Transform obj = Instantiate(allSplashes[aRandomIndex], arg_spawn_position, rotation);

        obj.gameObject.GetComponent<SpriteRenderer>().color = arg_splashColor;


    }

}
