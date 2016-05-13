using UnityEngine;
using System.Collections;

public class WaterDeformDemo : MonoBehaviour {

	MeshFilter mf; // used by Unity as a "model picker"
	Vector3[] unmodifiedVerts;

	public float waveFrequency = 1f;
	public float waveHeight = 0.5f;

	// Use this for initialization
	void Start () {
		mf = GetComponent<MeshFilter>();

		// tell Unity to optimize for constant updates
		mf.mesh.MarkDynamic();

		// save a copy of the Plane before we start distorting it
		unmodifiedVerts = mf.mesh.vertices.Clone() as Vector3[];
	}

	void Update () {
		// start with a blank, unmodified copy of the Plane
		Vector3[] vertices = unmodifiedVerts.Clone() as Vector3[];

		// go through every vertex and apply sine to the vertex position
		for ( int i=0; i<vertices.Length; i++ ) {
			vertices[i] += Vector3.up * Mathf.Sin( (Time.time + i) * waveFrequency ) * waveHeight;
		}

		// put the vertices back into the mesh
		mf.mesh.vertices = vertices;

		// recalculate which way each triangle is pointing
		mf.mesh.RecalculateNormals();

		// "bounds" tell a camera whether to render something or not
		mf.mesh.RecalculateBounds();

		// put the new mesh into the MeshCollider
		GetComponent<MeshCollider>().sharedMesh = mf.mesh;
	}
}
