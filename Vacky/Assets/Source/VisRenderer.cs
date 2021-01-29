using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisRenderer : MonoBehaviour
{
    public float _viewRadius;
    public float _viewAngle;

    public MeshFilter _viewMeshFilter;
    public Mesh _viewMesh;

    public float _meshResolution;

    void DrawFieldOfView()
    {
        int stepCount = Mathf.RoundToInt(_viewAngle * _meshResolution);
        float stepAng = _viewAngle / stepCount;
        List<Vector3> viewPts = new List<Vector3>();
        for ( int i = 0; i <= stepCount; i++)
        {
            float ang = transform.localEulerAngles.z - _viewAngle / 2 + stepAng * i;
            Debug.DrawLine(transform.position, transform.position + dirFromAngle(ang, true) * _viewRadius, Color.red);
            ViewCastData cast = viewCast(ang);
            viewPts.Add(cast._point);
        }

        int vertCount = viewPts.Count + 1;
        Vector3[] verts = new Vector3[vertCount];
        int[] tris = new int[(vertCount - 2) * 3];

        verts[0] = Vector3.zero;
        for(int i = 1; i<vertCount; i++)
        {
            verts[i] = viewPts[i];
            if (i < vertCount - 1)
            {
                tris[i * 3] = 0;
                tris[i * 3 + 1] = i;
                tris[i * 3 + 2] = i + 1;
            }
        }
    }

    ViewCastData viewCast(float globAng)
    {
        Vector3 dir = dirFromAngle(globAng, true);
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position[0], transform.position[1]), dir, _viewRadius);
        if (hit.collider != null)
            return new ViewCastData(true, hit.point, hit.distance, globAng);

        return new ViewCastData(false, transform.position + dir * _viewRadius, _viewRadius, globAng);
    }


    public Vector3 dirFromAngle(float angInDeg, bool angIsGlob)
    {
        if (!angIsGlob)
            angInDeg += transform.localEulerAngles.z;
        angInDeg += 90;
        return new Vector3(Mathf.Cos(angInDeg * Mathf.Deg2Rad), Mathf.Sin(angInDeg * Mathf.Deg2Rad),0);
    }
    
    void Start()
    {
        _viewMesh = new Mesh();
        _viewMesh.name = "View Mesh";
        _viewMeshFilter.mesh = _viewMesh;
    }

    // Update is called once per frame
    void Update()
    {
        DrawFieldOfView();   
    }


    public struct ViewCastData
    {
        public bool _hit;
        public Vector3 _point;
        public float _dst;
        public float _angle;

        public ViewCastData(bool hit, Vector3 pnt, float dst, float ang)
        {
            _hit = hit;
            _point = pnt;
            _dst = dst;
            _angle = ang;
        }
    }
}
