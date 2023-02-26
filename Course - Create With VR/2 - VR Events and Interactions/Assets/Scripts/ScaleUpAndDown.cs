using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUpAndDown : MonoBehaviour
{
    public float SizeIncreaseMultiplier = 1.2f;
    public float SizeDecreaseMultiplier = 0.8f;
    public float Speed = 0.1f;

    private Vector3 startScale;
    private Vector3 increasedScale;
    private Vector3 decreasedScale;
    private int direction;

    // Start is called before the first frame update
    void Start()
    {
        startScale = gameObject.transform.localScale;
        increasedScale = startScale * SizeIncreaseMultiplier;
        decreasedScale = startScale * SizeDecreaseMultiplier;
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!(gameObject.transform.localScale.magnitude <= increasedScale.magnitude && gameObject.transform.localScale.magnitude >= decreasedScale.magnitude))
            direction *= -1;

       gameObject.transform.localScale *= 1 + Speed * direction * Time.deltaTime;
    }
}
