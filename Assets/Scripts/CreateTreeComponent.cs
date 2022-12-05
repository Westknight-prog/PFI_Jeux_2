using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class CreateTreeComponent : MonoBehaviour
{
    [SerializeField] int hauteurMax;
    [SerializeField] int hauteurMin;
    int hauteur;

    void Awake()
    {
        hauteur = Random.Range(hauteurMin, hauteurMax);
        GetComponent<MeshFilter>().mesh = CreateTree();
        Debug.Log(hauteur);
    }

    private Mesh CreateTriangle()
    {
        //Créer Mesh
        Mesh triangleMesh = new Mesh();
        //Créer Sommets
        triangleMesh.vertices = new Vector3[]
        {
            //Avant
            new Vector3(x: 0,y: hauteur,z: 0),
            new Vector3(x: 1,y: -1,z: -1),
            new Vector3(x: -1,y: -1,z: -1),

            //Arrière
            new Vector3(x: 0,y: hauteur,z: 0),
            new Vector3(x: -1,y: -1,z: 1),
            new Vector3(x: 1,y: -1,z: 1),

            //Gauche
            new Vector3(x: 0,y: hauteur,z: 0),
            new Vector3(x: -1,y: -1,z: -1),
            new Vector3(x: -1,y: -1,z: 1),

            //droite       
            new Vector3(x: 0,y: hauteur,z: 0),
            new Vector3(x: 1,y: -1,z: 1),
            new Vector3(x: 1,y: -1,z: -1), 
         

            //Bas            
            new Vector3(x: 1,y: -1,z: 1),
            new Vector3(x: -1,y: -1,z: 1),
            new Vector3(x: -1,y: -1,z: -1),
            new Vector3(x: 1,y: -1,z: -1),

            new Vector3(x: 1,y: -3,z: 1),
            new Vector3(x: -1,y: -3,z: 1),
            new Vector3(x: -1,y: -3,z: -1),
            new Vector3(x: 1,y: -3,z: -1),

        };
        
        //Créer triangle
        triangleMesh.triangles = new int[]
        {
            0,1,2,
            3,4,5,
            6,7,8,
            9,10,11,
            12,13,14,
            12,14,15
        };

        triangleMesh.name = "Tree";
        triangleMesh.RecalculateNormals();
        return triangleMesh;
    }

    private Mesh CreateTree()
    {
        Mesh treeMesh = new Mesh();

        treeMesh.vertices = new Vector3[]
        {
            //Droite
            new Vector3(x:-0.5f,y:0,z:-0.5f),
            new Vector3(x:-0.5f,y:hauteur,z:-0.5f),
            new Vector3(x:0.5f,y:hauteur,z:-0.5f),
            new Vector3(x:0.5f,y:0,z:-0.5f),
            //Gauche
            new Vector3(x:-0.5f,y:0,z:0.5f),
            new Vector3(x:-0.5f,y:hauteur,z:0.5f),
            new Vector3(x:0.5f,y:hauteur,z:0.5f),
            new Vector3(x:0.5f,y:0,z:0.5f),
            //Bas
            new Vector3(x:0.5f,y:0,z:0.5f),
            new Vector3(x:-0.5f,y:0,z:0.5f),
            new Vector3(x:-0.5f,y:0,z:-0.5f),
            new Vector3(x:0.5f,y:0,z:-0.5f),
            //Haut
            new Vector3(x:-0.5f,y:hauteur,z:0.5f),
            new Vector3(x:0.5f,y:hauteur,z:0.5f),
            new Vector3(x:0.5f,y:hauteur,z:-0.5f),
            new Vector3(x:-0.5f,y:hauteur,z:-0.5f),
            //Face
            new Vector3(x:-0.5f,y:0,z:0.5f),
            new Vector3(x:-0.5f,y:hauteur,z:0.5f),
            new Vector3(x:-0.5f,y:hauteur,z:-0.5f),
            new Vector3(x:-0.5f,y:0,z:-0.5f),
            //Derriere
            new Vector3(x:0.5f,y:0,z:-0.5f),
            new Vector3(x:0.5f,y:hauteur,z:-0.5f),
            new Vector3(x:0.5f,y:hauteur,z:0.5f),
            new Vector3(x:0.5f,y:0,z:0.5f),

        };
        treeMesh.triangles = new int[]
        {
            0,1,2,
            2,3,0,
            7,6,5,
            5,4,7,
            8,9,10,
            10,11,8,
            12,13,14,
            14,15,12,
            16,17,18,
            18,19,16,
            20,21,22,
            22,23,20

        };
        treeMesh.RecalculateNormals();
        
        return treeMesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
