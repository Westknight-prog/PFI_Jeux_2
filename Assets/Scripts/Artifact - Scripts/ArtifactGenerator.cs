using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactGenerator : MonoBehaviour
{
    [SerializeField] int HauteurMax = 1;
    [SerializeField] Texture mats;
    int lastHauteurMax;
    Mesh triangleMesh;
    List<GameObject> containerList = new List<GameObject>();

    float elapsedTime = 0;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(GeneratePortal());
    }

    IEnumerator GeneratePortal()
    {
        while (true)
        {
            foreach (Transform child in this.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            CreateCubes();
            yield return new WaitForSeconds(0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateCubes()
    {
        int compteur = 1;
        int previousTexture = 1;
        int hauteurMax = HauteurMax;
        for (int h = 1; h <= hauteurMax; h++)
        {
            previousTexture = GetRandomTextureNumber(previousTexture);
            GameObject cube = new GameObject();
            cube.name = "Cube";
            cube.AddComponent<MeshFilter>().mesh = CreateTriangle(h, previousTexture);
            cube.AddComponent<MeshRenderer>().material.mainTexture = mats;
            cube.transform.SetParent(this.transform);
            compteur++;
        }

        lastHauteurMax = HauteurMax;
    }

    int GetRandomTextureNumber(int previousTexture)
    {
        int luckyNumber = Random.Range(0, 2);
        int textureMax;
        if (luckyNumber == 0)
            textureMax = previousTexture;
        else
            textureMax = 5;
        return Random.Range(1, textureMax);
    }

    private Mesh CreateTriangle(int nbHaut, int texture)
    {
        //créer un Mesh
        triangleMesh = new Mesh();

        //donner des sommets
        triangleMesh.vertices = new Vector3[]
        {
            // avant
            new Vector3(this.transform.position.x - 0.2f, (float)(nbHaut / 10f) - 0.1f, this.transform.position.z - 2),
            new Vector3(this.transform.position.x - 0.2f, (float)(nbHaut / 10f), this.transform.position.z - 2),
            new Vector3(this.transform.position.x, (float)(nbHaut / 10f), this.transform.position.z - 2),
            new Vector3(this.transform.position.x, (float)(nbHaut / 10f) - 0.1f, this.transform.position.z - 2),
            //arriere
            new Vector3(this.transform.position.x - 0.2f, (float)(nbHaut / 10f) - 0.1f, this.transform.position.z),
            new Vector3(this.transform.position.x - 0.2f, (float)(nbHaut / 10f), this.transform.position.z),
            new Vector3(this.transform.position.x, (float)(nbHaut / 10f), this.transform.position.z),
            new Vector3(this.transform.position.x, (float)(nbHaut / 10f) - 0.1f, this.transform.position.z),
            //gauche
            new Vector3(this.transform.position.x - 0.2f, (float)(nbHaut / 10f) - 0.1f, this.transform.position.z),
            new Vector3(this.transform.position.x - 0.2f, (float)(nbHaut / 10f), this.transform.position.z),
            new Vector3(this.transform.position.x - 0.2f, (float)(nbHaut / 10f), this.transform.position.z - 2),
            new Vector3(this.transform.position.x - 0.2f, (float)(nbHaut / 10f) - 0.1f, this.transform.position.z - 2),
            //droite
            new Vector3(this.transform.position.x, (float)(nbHaut / 10f) - 0.1f, this.transform.position.z),
            new Vector3(this.transform.position.x, (float)(nbHaut / 10f), this.transform.position.z),
            new Vector3(this.transform.position.x, (float)(nbHaut / 10f), this.transform.position.z - 2),
            new Vector3(this.transform.position.x, (float)(nbHaut / 10f) - 0.1f, this.transform.position.z - 2),
            //haut
            new Vector3(this.transform.position.x - 0.2f, (float)(nbHaut / 10f), this.transform.position.z),
            new Vector3(this.transform.position.x - 0.2f, (float)(nbHaut / 10f), this.transform.position.z - 2),
            new Vector3(this.transform.position.x, (float)(nbHaut / 10f), this.transform.position.z - 2),
            new Vector3(this.transform.position.x, (float)(nbHaut / 10f), this.transform.position.z),
            //bas
            new Vector3(this.transform.position.x - 0.2f, (float)(nbHaut / 10f) - 0.1f, this.transform.position.z),
            new Vector3(this.transform.position.x - 0.2f, (float)(nbHaut / 10f) - 0.1f, this.transform.position.z - 2),
            new Vector3(this.transform.position.x, (float)(nbHaut / 10f) - 0.1f, this.transform.position.z - 2),
            new Vector3(this.transform.position.x, (float)(nbHaut / 10f) - 0.1f, this.transform.position.z)
        };

        //créer les triangle
        triangleMesh.triangles = new int[]
        {
            0,1,2,
            2,3,0,

            6,5,4,
            4,7,6,

            8,9,10,
            8,10,11,

            13,12,15,
            13,15,14,

            16,19,18,
            16,18,17,

            20,22,23,
            20,21,22

        };
        // associer UV - permet de formater les images sur les faces

        switch (texture)
        {
            case 1:
                SetFirstTexture();
                break;
            case 2:
                SetSecondTexture();
                break;
            case 3:
                SetThirdTexture();
                break;
            case 4:
                SetFourthTexture();
                break;
            default:
                SetFirstTexture();
                break;
        }

        triangleMesh.name = "monTriangle";

        // rend leffet de lumiere possible sur notre triangle
        triangleMesh.RecalculateNormals();


        return triangleMesh;
    }
    
    private void SetFirstTexture()
    {
        triangleMesh.uv = new Vector2[]{
            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(0.25f, 1),
            new Vector2(0.25f, 0),

            new Vector2(0.25f, 0),
            new Vector2(0.25f, 1),
            new Vector2(0, 1),
            new Vector2(0, 0),

            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(0.25f, 1),
            new Vector2(0.25f, 0),

            new Vector2(0.25f, 0),
            new Vector2(0.25f, 1),
            new Vector2(0, 1),
            new Vector2(0, 0),

            new Vector2(0, 1),
            new Vector2(0, 0),
            new Vector2(0.25f, 0),
            new Vector2(0.25f, 1),

            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(0.25f, 1),
            new Vector2(0.25f, 0),

        };
    }
    private void SetSecondTexture()
    {
        triangleMesh.uv = new Vector2[]{
            new Vector2(0.25f, 0),
            new Vector2(0.25f, 1),
            new Vector2(0.5f, 1),
            new Vector2(0.5f, 0),

            new Vector2(0.5f, 0),
            new Vector2(0.5f, 1),
            new Vector2(0.25f, 1),
            new Vector2(0.25f, 0),

            new Vector2(0.25f, 0),
            new Vector2(0.25f, 1),
            new Vector2(0.5f, 1),
            new Vector2(0.5f, 0),

            new Vector2(0.5f, 0),
            new Vector2(0.5f, 1),
            new Vector2(0.25f, 1),
            new Vector2(0.25f, 0),

            new Vector2(0.25f, 1),
            new Vector2(0.25f, 0),
            new Vector2(0.5f, 0),
            new Vector2(0.5f, 1),

            new Vector2(0.25f, 0),
            new Vector2(0.25f, 1),
            new Vector2(0.5f, 1),
            new Vector2(0.5f, 0),

        };
    }

    private void SetThirdTexture()
    {
        triangleMesh.uv = new Vector2[]{
            new Vector2(0.5f, 0),
            new Vector2(0.5f, 1),
            new Vector2(0.75f, 1),
            new Vector2(0.75f, 0),

            new Vector2(0.75f, 0),
            new Vector2(0.75f, 1),
            new Vector2(0.5f, 1),
            new Vector2(0.5f, 0),

            new Vector2(0.5f, 0),
            new Vector2(0.5f, 1),
            new Vector2(0.75f, 1),
            new Vector2(0.75f, 0),

            new Vector2(0.75f, 0),
            new Vector2(0.75f, 1),
            new Vector2(0.5f, 1),
            new Vector2(0.5f, 0),

            new Vector2(0.5f, 1),
            new Vector2(0.5f, 0),
            new Vector2(0.75f, 0),
            new Vector2(0.75f, 1),

            new Vector2(0.5f, 0),
            new Vector2(0.5f, 1),
            new Vector2(0.75f, 1),
            new Vector2(0.75f, 0),

        };
    }

    private void SetFourthTexture()
    {
        triangleMesh.uv = new Vector2[]{
            new Vector2(0.75f, 0),
            new Vector2(0.75f, 1),
            new Vector2(1, 1),
            new Vector2(1, 0),

            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0.75f, 1),
            new Vector2(0.75f, 0),

            new Vector2(0.75f, 0),
            new Vector2(0.75f, 1),
            new Vector2(1, 1),
            new Vector2(1, 0),

            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0.75f, 1),
            new Vector2(0.75f, 0),

            new Vector2(0.75f, 1),
            new Vector2(0.75f, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),

            new Vector2(0.75f, 0),
            new Vector2(0.75f, 1),
            new Vector2(1, 1),
            new Vector2(1, 0),

        };
    }
}
