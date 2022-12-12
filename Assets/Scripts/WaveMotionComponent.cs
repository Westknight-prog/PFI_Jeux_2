using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class WaveMotionComponent : MonoBehaviour
{
    [SerializeField] float amplitude = 1;
    [SerializeField] float radStepPerSecond;
    [SerializeField] Space space;
    float waveHeight = 0.5f;
    float speed = 3.0f;
    Vector3[] baseVertices;
    float radTotal = 0;
    void Start()
    {

    }

    void Update()
    {
        Waving();
    }

    public void Waving()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        baseVertices = baseVertices == null ? mesh.vertices : baseVertices;

        var vertices = new Vector3[baseVertices.Length];
        for (var i = 0; i < vertices.Length; i++)
        {
            var vertex = baseVertices[i];
            vertex.y += Mathf.Sin(Time.time * speed + baseVertices[i].x) * waveHeight;
            vertices[i] = vertex;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}