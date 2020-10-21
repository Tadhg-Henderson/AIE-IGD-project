using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;

    public Light SpotLight;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            SpotLight.enabled = !SpotLight.enabled;
        }
    }
 
}
