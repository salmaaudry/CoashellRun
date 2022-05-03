using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaShell : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerManager.numberOfCoins += 1;
            Debug.Log("SeaShells : " + PlayerManager.numberOfCoins);
            Destroy(gameObject);
        }
    }
}
