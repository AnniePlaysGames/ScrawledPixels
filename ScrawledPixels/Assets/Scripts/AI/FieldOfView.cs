using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float ViewRadius => _viewRadius;
    [SerializeField] private float _viewRadius;
    public float ViewAngle => _viewAngle;
    [Range(0, 360)] [SerializeField] private float _viewAngle;
    
    public List<Transform> VisibleTargets => _visibleTargets;
    private List<Transform> _visibleTargets = new List<Transform>();
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private LayerMask _obstacleMask;
    [SerializeField] private float _delay;

    [SerializeField] private float _meshResoultion;

    private void Start()
    {
        StartCoroutine(FindTargetWithDelay());
    }
    

    private void FindVisibleTargets()
    {
        _visibleTargets.Clear();
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, _viewRadius, _targetMask);
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;
            float angleToTarget = Vector2.Angle(transform.right ,directionToTarget);
            
            if (angleToTarget < _viewAngle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                
                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, _obstacleMask))
                {
                    _visibleTargets.Add(target);
                }
            }
        }
    }

    IEnumerator FindTargetWithDelay()
    {
        while (true)
        {
            FindVisibleTargets();
            yield return new WaitForSeconds(_delay);
        }
    }
    
    private ViewCastInfo ViewCast(float globalAngle)
    {
        Vector3 direction = DirFromAngle(globalAngle, true);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, _viewRadius, _obstacleMask);

        if (hit.collider != null)
        {
            return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
        }
        else
        {
            return new ViewCastInfo(false, transform.position + direction * _viewRadius, _viewRadius, globalAngle);
        }
    }

    private struct ViewCastInfo
    {
        public bool IsHit;
        public Vector3 Point;
        public float Distance;
        public float Angle;

        public ViewCastInfo(bool isHit, Vector3 point, float distance, float angle)
        {
            IsHit = isHit;
            Point = point;
            Distance = distance;
            Angle = angle;
        }
    }
    

    private Vector3 DirFromAngle(float angle, bool isGlobal)
    {
        var resultQuatern = Quaternion.AngleAxis(angle, Vector3.forward);
        if (!isGlobal)
        {
            return resultQuatern * transform.right;
        }
        
        return resultQuatern * Vector3.forward;
    }
}