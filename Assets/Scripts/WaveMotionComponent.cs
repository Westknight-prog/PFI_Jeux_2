using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class WaveMotionComponent : MonoBehaviour
{
    [SerializeField] float waveHeight = 0.5f;
    [SerializeField] float speed = 3.0f;
    Vector3[] baseVertices;

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
            vertex.z += Mathf.Sin(Time.time * speed + baseVertices[i].x) * waveHeight;
            vertices[i] = vertex;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}