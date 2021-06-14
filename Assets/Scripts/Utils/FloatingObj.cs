using UnityEngine;
using System.Collections;

public class FloatingObj : MonoBehaviour
{
    public float XdegreesPerSecond = 15.0f;
    public float YdegreesPerSecond = 15.0f;
    public float ZdegreesPerSecond = 15.0f;

    public float amplitude = 0.5f;
    public float frequency = 1f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    void Start()
    {
        posOffset = transform.position;

        if (XdegreesPerSecond == -1)
            XdegreesPerSecond = Random.Range(-0, 45);
        if (YdegreesPerSecond == -1)
            YdegreesPerSecond = Random.Range(-0, 45);
        if (ZdegreesPerSecond == -1)
            ZdegreesPerSecond = Random.Range(-0, 45);

        if (amplitude == -1)
            amplitude = Random.Range(-0, 3);
        if (frequency == -1)
            frequency = Random.Range(-0, 3);
    }

    void Update()
    {
        transform.Rotate(new Vector3(Time.deltaTime * XdegreesPerSecond, Time.deltaTime * YdegreesPerSecond, Time.deltaTime * ZdegreesPerSecond), Space.World);

        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}
