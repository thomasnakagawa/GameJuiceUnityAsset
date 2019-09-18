using GameJuice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClickTween : MonoBehaviour
{
    [SerializeField] private EasingFunction TurningEasingFunction = default;
    [SerializeField] private EasingFunction MovingEasingFunction = default;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100.0f))
            {
                Vector3 targetPosition = hit.point;
                StopAllCoroutines();
                StartCoroutine(
                    Tween.Quaternion(
                        transform.rotation,
                        Quaternion.LookRotation(targetPosition - transform.position, Vector3.up),
                        0.5f,
                        TurningEasingFunction.Evaluate,
                        quat => transform.rotation = quat
                    ).Then(Tween.Vector3(
                        transform.position,
                        targetPosition,
                        1f,
                        MovingEasingFunction.Evaluate,
                        vec3 => transform.position = vec3
                    ))
                );
            }
        }
    }
}
