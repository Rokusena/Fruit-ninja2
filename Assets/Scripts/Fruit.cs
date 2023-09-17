using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public float lifetime = 5;
    public float rotationSpeed = 30.0f;
    

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    private void Update()
    { 
        Vector3 rotation = new Vector3(1.0f, 1.0f, 1.0f) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);
    }

    void RotateAndKill(Transform obj)
    {
        Vector3 rotation = new Vector3(1.0f, 1.0f, 1.0f) * rotationSpeed * Time.deltaTime;
        obj.Rotate(rotation);
        Destroy(obj.gameObject, lifetime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Cursor"))
        {

            if (gameObject.transform.CompareTag("Fruit"))
            {
                Score.inst.Addscore(1);
                var velocity = GetComponent<Rigidbody>().velocity;

                var children = new List<Transform>();
                foreach (Transform child in transform)
                {
                    children.Add(child);
                }

                var direction = Vector3.right;
                foreach (var child in children)
                {
                    var rb = child.gameObject.AddComponent<Rigidbody>();
                    rb.velocity = velocity;



                    RotateAndKill(child);
                    rb.AddForce(direction, ForceMode.Impulse);
                    direction *= -1;

                    child.parent = null;
                }
            }
            else if (gameObject.transform.CompareTag("Bomb"))
            { 
                SceneManager.LoadScene(2);
            }
            
            Destroy(gameObject);
        }
    }
}
