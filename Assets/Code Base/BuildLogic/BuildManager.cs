using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField] private Color startColor;
    [SerializeField] private Color hoverColor;
    [SerializeField] private GameObject[] Turrets;
    
    
    private GameObject hoverObject;
    
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit))
        {
            if (raycastHit.collider.gameObject.CompareTag("Node"))
            {
                hoverObject = raycastHit.collider.gameObject;
                hoverObject.GetComponent<MeshRenderer>().material.color = hoverColor;
            }
            else
            {
                if (hoverObject != null)
                {
                    hoverObject.GetComponent<MeshRenderer>().material.color = startColor;
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            hoverObject.GetComponent<NodeBuildSettings>().StartBuild(Turrets, 0, 0.35f, 15);
        }
    }
}
