using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisRenderer : MonoBehaviour
{
    public enum VisMode {Bonk, Lida, Cam, XRay };

    public float _viewRadius;
    public float _viewAngle;

    public MeshFilter _viewMeshFilter;
    public Mesh _viewMesh;

    public float _meshResolution;

    public float _maskDilation = 0.8f;

    public VisMode _visMode;

    void DrawFieldOfView()
    {
        int stepCount = Mathf.RoundToInt(_viewAngle * _meshResolution);
        float stepAng = _viewAngle / stepCount;
        List<Vector3> viewPts = new List<Vector3>();
        for ( int i = 0; i <= stepCount; i++)
        {
            float ang = transform.localEulerAngles.z - _viewAngle / 2 + stepAng * i;
            //Debug.DrawLine(transform.position, transform.position + dirFromAngle(ang, true) * _viewRadius, Color.red);
            ViewCastData cast = viewCast(ang, _visMode != VisMode.XRay);
            viewPts.Add(cast._point);
        }

        int vertCount = viewPts.Count + 1;
        Vector3[] verts=new Vector3[1]; 
        int[] tris = new int[3]; 

        
        if (_visMode == VisMode.Cam || _visMode == VisMode.XRay)
        {
            verts = new Vector3[vertCount];
            tris = new int[(vertCount - 2) * 3];
            verts[0] = Vector3.zero;
            for (int i = 0; i < vertCount - 1; i++)
            {
                verts[i + 1] = transform.InverseTransformPoint(viewPts[i]) + Vector3.up * _maskDilation;
                if (i < vertCount - 2)
                {
                    tris[i * 3] = 0;
                    tris[i * 3 + 1] = i + 2;
                    tris[i * 3 + 2] = i + 1;
                }
            }
        }
        if( _visMode == VisMode.Lida)
        {
            verts = new Vector3[vertCount*3];
            tris = new int[vertCount*3];
            for (int i = 0; i < vertCount-1; i++)
            {
                verts[i * 3] = transform.InverseTransformPoint(viewPts[i]);
                verts[i*3 + 1] = transform.InverseTransformPoint(viewPts[i]) + (Vector3.up +Vector3.right) *_maskDilation*0.3f;
                verts[i*3 + 2] = transform.InverseTransformPoint(viewPts[i]) + (Vector3.up +Vector3.left ) *_maskDilation*0.3f;
                
                tris[i * 3] = i*3;
                tris[i * 3 + 1] = i*3 + 2;
                tris[i * 3 + 2] = i*3 + 1;

            }
        }

        _viewMesh.Clear();
        _viewMesh.vertices = verts;
        _viewMesh.triangles = tris;
        _viewMesh.RecalculateNormals();
    }

    ViewCastData viewCast(float globAng, bool colide)
    {
        Vector3 dir = dirFromAngle(globAng, true);
        if (colide)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position[0], transform.position[1]) + new Vector2(dir[0], dir[1]) * GetComponent<CircleCollider2D>().radius * 1.01f, dir, _viewRadius);
            if (hit.collider != null)
                return new ViewCastData(true, hit.point, hit.distance, globAng);
        }

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
    void LateUpdate()
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
