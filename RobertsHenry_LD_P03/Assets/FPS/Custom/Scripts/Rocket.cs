using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private void OnDestroy()
    {
        Collider[] hit = Physics.OverlapSphere(this.transform.position, 1);

        foreach (var collider in hit)
        {
            if (collider.gameObject.CompareTag("Breakable"))
            {
                collider.gameObject.SetActive(false);
            }
        }
    }
}
