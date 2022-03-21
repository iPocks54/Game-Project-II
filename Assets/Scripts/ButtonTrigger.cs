using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public List<GameObject> objectsToDisable;
    private BoxCollider buttonCollider;
    // Start is called before the first frame update
    void Start()
    {
       buttonCollider = this.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("ça collide frerot");
        if (other.gameObject.CompareTag("Player")) {
            foreach (GameObject gameObject in objectsToDisable)
            {
                gameObject.gameObject.SetActive(false);
            }
        }
    }
}
