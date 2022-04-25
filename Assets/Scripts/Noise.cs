using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour
{

    public bool origin = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
     

     StartCoroutine(wait());

            

        


    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3);

        Destroy(gameObject);
    }

}
