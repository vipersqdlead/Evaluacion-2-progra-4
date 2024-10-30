using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mov_x = Input.GetAxis("Horizontal") * Time.deltaTime * 60;
        float mov_y = Input.GetAxis("Vertical") * Time.deltaTime * 60;

        transform.position = transform.position + new Vector3 (mov_x, 0, mov_y);
    }
}
