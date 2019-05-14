using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDestroy : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Path"))
        {
            Destroy(other.gameObject);
        }

    }
}
