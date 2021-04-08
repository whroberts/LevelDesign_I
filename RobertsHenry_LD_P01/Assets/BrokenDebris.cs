using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenDebris : MonoBehaviour
{

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 spot = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
        rb.AddExplosionForce(0.9f, transform.position, 2f, 3f);
        StartCoroutine("DestroyDebris");
    }

    IEnumerator DestroyDebris()
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));
        Destroy(this.gameObject);
    }
}
