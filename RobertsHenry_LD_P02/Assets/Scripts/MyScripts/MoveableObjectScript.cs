using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class MoveableObjectScript : MonoBehaviour
{
    [SerializeField] Transform _collectionSpot = null;

    public PlayerController _playerController;
    public LookAtScript _lookAtScript;


    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _lookAtScript = FindObjectOfType<LookAtScript>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var p = other.gameObject.GetComponent<PlayerController>();
        if (p != null && !_playerController._boxCollected)
        {
            Collect();
        }
    }

    void Collect()
    {
        Debug.Log("Pickedup Box");
        _playerController._boxCollected = true;
        Destroy(this.gameObject);
        GameObject clone = Instantiate(this.gameObject, _collectionSpot, true);
        BoxCollider2D bc = clone.GetComponent<BoxCollider2D>();
        bc.enabled = true;
    }

    public void Leave(Transform buttonTransform)
    {
        Debug.Log("Dropped Box");
        Destroy(this.gameObject);
        GameObject clone = Instantiate(this.gameObject,buttonTransform,true);
        BoxCollider2D bc = clone.GetComponent<BoxCollider2D>();
        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
        bc.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
    }

    public void ThroughPortal(Collider2D other, Transform outPortal)
    {
        Debug.Log("Box went through the portal");
        Destroy(this.gameObject);
        GameObject clone = Instantiate(other.gameObject);
        BoxCollider2D bc = clone.GetComponent<BoxCollider2D>();
        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        bc.enabled = true;
        bc.isTrigger = false;
        StartCoroutine(_lookAtScript.MoveTo(clone.transform));
        clone.transform.position = outPortal.position;
    }
}
