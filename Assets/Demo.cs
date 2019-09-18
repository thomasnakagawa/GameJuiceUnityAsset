using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Juice.HitStun(0.5f);
            StartCoroutine(
                PrintAfter(1f, "one")
            //.Then(PrintAfter(1f, "two"))
            //.Then(PrintAfter(2f, "three"))
            );

            StartCoroutine(
                HitStunSeconds(0.1f)
                .Then(Wait(0.1f))
                .Then(() => Debug.Log("yeet"))
                .Then(Wait(0.1f))
            );
        }*/

        /*
        StartCoroutine(
            Tween.Quaternion(Quaternion.Euler(Vector3.one), Quaternion.Euler(Vector3.zero), 5f, null, q => transform.rotation = q)
                .Then(
            
        );*/
        /*
        StartCoroutine(Tween.Vector3(Vector3.zero, Vector3.zero, 4f, EasingFunctions.Linear, vec => transform.position = vec)
            .Then(() => {
                Debug.Log("done");
            }
        ));
        */
    }
}
