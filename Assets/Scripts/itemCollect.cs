using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollect : MonoBehaviour
{

    //could add code to identify player

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
