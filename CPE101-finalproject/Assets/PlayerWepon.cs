using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWepon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.right = direction;

        Vector2 Scale = transform.localScale;
        if(direction.x < 0)
        {
            Scale.y = -1;
        }
        else if (direction.x > 0)
        {
            Scale.y = 1;
        }
        transform.localScale = Scale;
    }
}
