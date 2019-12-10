using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetButtonDown("Fire1"))
        {
            Ray mouseRay = GetComponentInChildren<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;
            if (Physics.Raycast(mouseRay, out hitInfo))
            {
                if (hitInfo.transform.GetComponent<ObjectInGame>())
                {
                    if (hitInfo.transform.tag == "Properties")
                    {
                        hitInfo.transform.GetComponent<ObjectInGame>().properties.Action();
                    }
                }
            }
        }
    }
}
