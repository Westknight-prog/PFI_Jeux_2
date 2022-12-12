using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class CreateFlagComponent : MonoBehaviour
{
    [SerializeField] float largeurTotal = 1;
    [SerializeField] float hauteurTotal = 1;
    [SerializeField] float nbSommetLargeur = 1;
    [SerializeField] float nbSommetHauteur = 1;
    void Awake()
    {
        GetComponent<MeshFilter>().mesh = CreateFlag();
    }

    private Mesh CreateFlag()
    {
        float largeurSommet = largeurTotal / nbSommetLargeur;
        float hauteurSommet = hauteurTotal / nbSommetHauteur;
        float largeurUV = 1 / (nbSommetLargeur - 1);
        float hauteurUV = 1 / (nbSommetHauteur - 1);
        int nbSommetsTotal = (int)nbSommetLargeur * (int)nbSommetHauteur;
        Mesh flagMesh = new Mesh();
        List<Vector3> listVertices = new List<Vector3>();
        List<int> listTriangle = new List<int>();
        List<Vector2> listUV = new List<Vector2>();

        for (int index = 0; index <= 1; index++)
        {
            for (int i = 0; i < nbSommetHauteur; i++)
            {
                for (int l = 0; l < nbSommetLargeur; l++)
                {
                    listVertices.Add(new Vector3(x: largeurSommet * l, y: hauteurSommet * i, z: 0));

                    if (index == 0)
                    {
                        listUV.Add(new Vector2(largeurUV * l, hauteurUV * i));
                    }
                    else
                    {
                        listUV.Add(new Vector2(1 - largeurUV * l, hauteurUV * i));
                    }
                }
            }

            for (int i = 0; i < ((nbSommetHauteur - 1) * nbSommetLargeur) - 1; i += (int)nbSommetLargeur)
            {
                for (int l = 0; l < nbSommetLargeur - 1; l++)
                {
                    if (index == 0)
                    {
                        listTriangle.Add(l + i + nbSommetsTotal * index);
                        listTriangle.Add(l + (int)nbSommetLargeur + i + nbSommetsTotal * index);
                        listTriangle.Add(l + 1 + i + nbSommetsTotal * index);

                        listTriangle.Add(l + (int)nbSommetLargeur + i + nbSommetsTotal * index);
                        listTriangle.Add(l + 1 + (int)nbSommetLargeur + i + nbSommetsTotal * index);
                        listTriangle.Add(l + 1 + i + nbSommetsTotal * index);
                    }
                    else
                    {
                        listTriangle.Add(l + 1 + (int)nbSommetLargeur + i + nbSommetsTotal * index);
                        listTriangle.Add(l + i + nbSommetsTotal * index);
                        listTriangle.Add(l + 1 + i + nbSommetsTotal * index);

                        listTriangle.Add(l + 1 + (int)nbSommetLargeur + i + nbSommetsTotal * index);
                        listTriangle.Add(l + (int)nbSommetLargeur + i + nbSommetsTotal * index);
                        listTriangle.Add(l + i + nbSommetsTotal * index);
                    }
                }
            }
        }

        flagMesh.name = "FlagMesh";
        flagMesh.vertices = listVertices.ToArray();
        flagMesh.triangles = listTriangle.ToArray();
        flagMesh.uv = listUV.ToArray();
        flagMesh.RecalculateNormals();

        return flagMesh;
    }
    
}
