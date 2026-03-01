using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{

    [SerializeField]
    Transform holdPoint;
    [SerializeField]
    Transform DropGround;

    GameObject Item;
    GameObject clone;

    [SerializeField]
    float distance = 5.0f;

    [SerializeField]
    Transform bagSlot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastChecking();
    }

    void RaycastChecking()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance))
        {

            if (Item == null)
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(hit.collider.name == "Bag")
                    {
                        clone = hit.collider.gameObject;
                        Item = clone;

                        clone.transform.SetPositionAndRotation(holdPoint.transform.position, holdPoint.transform.rotation);

                        clone.transform.SetParent(holdPoint);

                    }
                    else
                    {
                        clone = Instantiate(hit.collider.gameObject);
                        Item = hit.collider.gameObject;

                        clone.transform.SetPositionAndRotation(holdPoint.transform.position, holdPoint.transform.rotation);

                        clone.transform.SetParent(holdPoint);

 

                    }
                }

            }
        }
        if (Item != null)
            {
                if (Input.GetKeyDown(KeyCode.Q) && clone.transform.parent == holdPoint)
                {
                    clone.transform.SetParent(DropGround);
                    Rigidbody rb = clone.AddComponent<Rigidbody>();
                    rb.mass = 1f;
                    rb.useGravity = true;
                    rb.isKinematic = false;
                    Item = null;
                }
                if (Input.GetKeyDown(KeyCode.E) && hit.collider.name == "Bag" && Item.name != "Bag")
                {
                    clone.transform.SetParent(bagSlot);
                    Destroy(clone.GetComponent<Collider>());
                    Destroy(clone.GetComponent<MeshRenderer>());



                    Item = null;
                }
            }


    }
}
