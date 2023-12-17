using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometCaveVisible : MonoBehaviour
{
    public GameObject targetCheck;
    public bool renderit;
    public List<GameObject> caveObjects;
    // Start is called before the first frame update
    void Start()
    {
        caveObjects = AllChilds(gameObject);
        RenderThings(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (targetCheck.GetComponent<Checkpoint>().Active == true)
        {
            RenderThings(true);

  
    
            

        }
       


    }
    private void RenderThings(bool yn)
    {
        GameObject.Find("FrontMeshObj").GetComponent<MeshRenderer>().enabled = !yn;
        GameObject.Find("FMO2").GetComponent<MeshRenderer>().enabled = !yn;
        GameObject.Find("Goal").transform.Find("Cylinder").GetComponent<SkinnedMeshRenderer>().enabled = yn;
        gameObject.GetComponent<MeshRenderer>().enabled = yn;
        gameObject.GetComponent<Collider>().enabled = yn;
        foreach (GameObject child in caveObjects)
        {
            if (child.TryGetComponent(out MeshRenderer meshrenderer))
            {
                child.GetComponent<MeshRenderer>().enabled = yn;
            }
            
            if (child.TryGetComponent(out Collider collider))
            { 
             child.GetComponent<Collider>().enabled = yn;
            }
        }
        
        
    }

       

    
    // gray24's code
    public List<GameObject> AllChilds(GameObject root)
    {
        List<GameObject> result = new List<GameObject>();
        if (root.transform.childCount > 0)
        {
            foreach (Transform VARIABLE in root.transform)
            {
                Searcher(result, VARIABLE.gameObject);
            }
        }
        return result;
    }

    private void Searcher(List<GameObject> list, GameObject root)
    {
        list.Add(root);
        if (root.transform.childCount > 0)
        {
            foreach (Transform VARIABLE in root.transform)
            {
                Searcher(list, VARIABLE.gameObject);
            }
        }
    }
    // end
}
