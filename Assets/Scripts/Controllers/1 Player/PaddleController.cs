using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PaddleController : MonoBehaviour
{
    public Camera cam;
    public UnityEngine.Transform target;

    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            transform.position = new Vector2(transform.position.x, touchPosition.y);
        }

        Vector3 screenPos = cam.WorldToScreenPoint(target.position);

    }
}

