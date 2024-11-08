using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Collisions : MonoBehaviour
{
    public List<GameObject> objects;

    public GameObject objectToFind;

    Vector3 min1;
    Vector3 min2;
    Vector3 max1;
    Vector3 max2;

    private void Awake()
    {
        objects = new List<GameObject>();

        objectToFind = GameObject.Find("dodecahedron");

        objects.Add(objectToFind);

        objectToFind = GameObject.Find("tetrahedron");

        objects.Add(objectToFind);

        objectToFind = GameObject.Find("icosahedron");

        objects.Add(objectToFind);

        objectToFind = GameObject.Find("cube");

        objects.Add(objectToFind);

        objectToFind = GameObject.Find("decahedron");

        objects.Add(objectToFind);

        objectToFind = GameObject.Find("octahedron");

        objects.Add(objectToFind);

        min1 = Vector3.zero;
        min2 = Vector3.zero;
        max1 = Vector3.zero;
        max2 = Vector3.zero;
    }

    void Update()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            for (int j = 0; j < objects.Count; j++)
            {
                if (i != j)
                {
                    min1 = objects[i].GetComponent<AABB>().minPoint;
                    max1 = objects[i].GetComponent<AABB>().maxPoint;

                    min2 = objects[j].GetComponent<AABB>().minPoint;
                    max2 = objects[j].GetComponent<AABB>().maxPoint;


                    if (max1.x > min2.x &&
                        min1.x < max2.x &&
                        max1.y > min2.y &&
                        min1.y < max2.y &&
                        max1.z > min2.z &&
                        min1.z < max2.z)
                    {
                        objects[i].GetComponent<AABB>().SetColor(Color.red);
                        objects[j].GetComponent<AABB>().SetColor(Color.red);
                    }

                }
            }

        }
    }
}
