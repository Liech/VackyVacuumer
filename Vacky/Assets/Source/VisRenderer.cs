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

  public float _viewRadiusBonk = 1;
  public float _viewAngleBonk = 360;
  public float _viewRadiusLida = 12;
  public float _viewAngleLida = 120;
  public float _viewRadiusCam = 120;
  public float _viewAngleCam = 15;
  public float _viewRadiusXRay = 15;
  public float _viewAngleXRay = 360;
  public VisMode _visMode;

  void DrawFieldOfView()
  {
    int stepCount = Mathf.RoundToInt(_viewAngle * _meshResolution);
    int stepCountBase = Mathf.RoundToInt(360 * _meshResolution);
    float stepAng = _viewAngle / stepCount;
    List<ViewCastData> viewPts = new List<ViewCastData>();
    List<Vector3> basicView = new List<Vector3>();
    basicView.Add(Vector3.zero);
    for (int i = 0; i <= stepCountBase; i++)
    {
      float ang = transform.localEulerAngles.z - _viewAngle / 2 + stepAng * i;
      basicView.Add(transform.position + dirFromAngle(ang, true) * _viewRadiusBonk);
    }  

    for (int i = 0; i <= stepCount; i++)
    {
      float ang = transform.localEulerAngles.z - _viewAngle / 2 + stepAng * i;
      //Debug.DrawLine(transform.position, transform.position + dirFromAngle(ang, true) * _viewRadius, Color.red);
      ViewCastData cast = viewCast(ang, _visMode != VisMode.XRay);
      viewPts.Add(cast);
    }

    int vertCount = viewPts.Count + 1;
    Vector3[] verts = new Vector3[1];
    int[] tris = new int[3];


    if (_visMode == VisMode.Cam || _visMode == VisMode.XRay || _visMode == VisMode.Bonk)
    {
      verts = new Vector3[vertCount+basicView.Count];
      tris = new int[(vertCount - 2) * 3 + (basicView.Count-2)*3];
      verts[0] = Vector3.zero;
      for (int i = 0; i < vertCount - 1; i++)
      {
        verts[i + 1] = transform.InverseTransformPoint(viewPts[i]._point) - transform.InverseTransformDirection(viewPts[i]._targetNormal) * _maskDilation;
        if (i < vertCount - 2)
        {
          tris[i * 3] = 0;
          tris[i * 3 + 1] = i + 2;
          tris[i * 3 + 2] = i + 1;
        }
      }
    }
    if (_visMode == VisMode.Lida)
    {
      verts = new Vector3[vertCount * 3 + basicView.Count];
      tris = new int[vertCount * 3 + (basicView.Count - 2) * 3];
      for (int i = 0; i < vertCount - 1; i++)
      {
        verts[i * 3] = transform.InverseTransformPoint(viewPts[i]._point);
        verts[i * 3 + 1] = transform.InverseTransformPoint(viewPts[i]._point) + (Vector3.up + Vector3.right) * _maskDilation * 0.3f;
        verts[i * 3 + 2] = transform.InverseTransformPoint(viewPts[i]._point) + (Vector3.up + Vector3.left) * _maskDilation * 0.3f;

        tris[i * 3] = i * 3;
        tris[i * 3 + 1] = i * 3 + 2;
        tris[i * 3 + 2] = i * 3 + 1;

      }
    }

    int offset =  _visMode == VisMode.Lida ? vertCount*3: vertCount;
    int triOffset = _visMode == VisMode.Lida ? vertCount * 3 : (vertCount - 2) * 3;
    for (int i = 0; i<basicView.Count; i++)
    {
      if(i==0)
        verts[i + offset] = basicView[i];
      else
        verts[i + offset] = transform.InverseTransformPoint(basicView[i]);

      if (i < basicView.Count - 2)
      {
        tris[i * 3 + triOffset] = offset;
        tris[i * 3 + 1 + triOffset] = i + 2 + offset;
        tris[i * 3 + 2 + triOffset] = i + 1 + offset;
      }
    }

    _viewMesh.Clear();
    _viewMesh.vertices = verts;
    _viewMesh.triangles = tris;
    _viewMesh.RecalculateNormals();
  }

  public void upgrade()
  {
    if (_visMode == VisMode.Bonk)
    {
      GetComponent<Bonk>().turnOff();
      _visMode = VisMode.Lida;
      _viewAngle = _viewAngleLida;
      _viewRadius = _viewRadiusLida;
      _maskDilation = 0.3f;

    }
    else if (_visMode == VisMode.Lida)
    {
      _visMode = VisMode.Cam;
      _viewAngle = _viewAngleCam;
      _viewRadius = _viewRadiusCam;
      _maskDilation = 0.8f;
    }
    else if (_visMode == VisMode.Cam)
    {
      _visMode = VisMode.XRay;
      _viewAngle = _viewAngleXRay;
      _viewRadius = _viewRadiusXRay;
      _maskDilation = 0.8f;
    }
  }

    ViewCastData viewCast(float globAng, bool colide)
    {
        Vector3 dir = dirFromAngle(globAng, true);
        if (colide)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position[0], transform.position[1]) + new Vector2(dir[0], dir[1]) * GetComponent<CircleCollider2D>().radius * 1.01f, dir, _viewRadius);
            if (hit.collider != null && !hit.collider.isTrigger)
                return new ViewCastData(true, hit.point, hit.distance, globAng, hit.normal);
        }
        
        return new ViewCastData(false, transform.position + dir * _viewRadius, _viewRadius, globAng, dir);
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
    if (_visMode == VisMode.Bonk)
    {
      GetComponent<Bonk>().turnOn();
      _viewAngle = _viewAngleBonk;
      _viewRadius = _viewRadiusBonk;
      _maskDilation = 0.05f;

    }
    else if (_visMode == VisMode.Lida)
    {
      GetComponent<Bonk>().turnOff();
      _viewAngle = _viewAngleLida;
      _viewRadius = _viewRadiusLida;
      _maskDilation = 0.3f;
    }
    else if (_visMode == VisMode.Cam)
    {
      GetComponent<Bonk>().turnOff();
      _viewAngle = _viewAngleCam;
      _viewRadius = _viewRadiusCam;
      _maskDilation = 0.8f;
    }
    else if (_visMode == VisMode.XRay)
    {
      GetComponent<Bonk>().turnOff();
      _viewAngle = _viewAngleXRay;
      _viewRadius = _viewRadiusXRay;
      _maskDilation = 0.8f;
    }

      DrawFieldOfView();   
  }


    public struct ViewCastData
    {
        public bool _hit;
        public Vector3 _point;
        public float _dst;
        public float _angle;
        public Vector3 _targetNormal;

        public ViewCastData(bool hit, Vector3 pnt, float dst, float ang, Vector3 targetNormal)
        {
            _hit = hit;
            _point = pnt;
            _dst = dst;
            _angle = ang;
            _targetNormal = targetNormal;
        }
    }
}
