using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollect : MonoBehaviour
{

    //could add code here to make sure the player is the one touching

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
