using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    float rateTime = 1f;
    public float nextTime = 0;

    Material material;
    Rigidbody rb;

    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        material = Renderer.material;
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);

        rb = GetComponent<Rigidbody>();
        InvokeRepeating("forceOverTime", 1,2);
    }
    
    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);

        changeColorOverTime();
        
    }

    void changeColorOverTime()
    {
        float color1 = Random.Range(0f, 1f);
        float color2 = Random.Range(0f, 1f);
        float color3 = Random.Range(0f, 1f);

        if(nextTime<Time.time)
        {
            nextTime = nextTime + rateTime;

            material.color = new Color(color1, color2, color3, 0.4f);
        }
        


    }

    void forceOverTime()
    {
        rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
    }
}
