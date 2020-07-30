using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIsappearSplash : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    Color myColor;
    public float fadeSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        myColor = spriteRenderer.color;

        StartCoroutine(FadeColor());
    }

    IEnumerator FadeColor() {

        yield return new WaitForSeconds(5.0F);

        while (true) {


            if (myColor.a - fadeSpeed <= 0.0F) { 
                Destroy(gameObject); 
                break; 
            }

            myColor = new Color(myColor.r, myColor.g, myColor.b, myColor.a - fadeSpeed);

            spriteRenderer.color = myColor;



            yield return new WaitForSeconds(0.05F);
        }
    
    }
}
