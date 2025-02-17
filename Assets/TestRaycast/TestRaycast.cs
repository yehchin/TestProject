using UnityEngine;
using UnityEngine.SceneManagement;

namespace Demo
{
    public class TestRaycast : MonoBehaviour
    {
        public Rigidbody _rigidbody;
        public CapsuleCollider _capsuleCollider;

        private Scene testScene;
        private PhysicsScene testPhysicsScene;

        private Collider collider1;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            testScene = SceneManager.CreateScene($"Simualte", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
            testPhysicsScene = testScene.GetPhysicsScene();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Transform testTransform = _rigidbody.transform;
                Vector3 p1 = testTransform.position + _capsuleCollider.center;
                Vector3 p2 = p1 + Vector3.up * _capsuleCollider.height;

                if (Physics.CheckCapsule(p1, p2, _capsuleCollider.radius, Physics.AllLayers, QueryTriggerInteraction.Ignore))
                {
                    Debug.Log("AAAA");
                    Collider[] colliders = Physics.OverlapCapsule(p1, p2, _capsuleCollider.radius, Physics.AllLayers);

                    float tdis = 0;
                    collider1 = null;

                    foreach (Collider collider in colliders)
                    {
                        if (collider.transform.IsChildOf(testTransform))
                        {
                            continue;
                        }


                        // 使用 ClosestPoint 獲取碰撞點
                        Vector3 collisionPoint = collider.ClosestPoint(p1 + Vector3.up * _capsuleCollider.height * 0.5f);
                        Vector3 a = (p1 + Vector3.up * _capsuleCollider.height * 0.5f);
                        float td = Vector3.Distance(a, collisionPoint);
                        if (collider1 == null)
                        {
                            tdis = td;
                            collider1 = collider;
                        }
                        else if (td < tdis)
                        {
                            tdis = td;
                            collider1 = collider;
                        }
                    }

                    Debug.Log(collider1);

                    if (collider1)
                    {
                        Vector3 collisionPoint = collider1.ClosestPoint(p1 + Vector3.up * _capsuleCollider.height * 0.5f);
                        Vector3 a = (p1 + Vector3.up * _capsuleCollider.height * 0.5f);
                        collisionPoint.y = 0;
                        a.y = 0;
                        Vector3 dir = (a - collisionPoint).normalized;
                        float dis = _capsuleCollider.radius - Vector3.Distance(a, collisionPoint);
                        Vector3 move = dir * dis;

                        Debug.Log(move);
                        Debug.Log(testTransform.position + move);
                        _rigidbody.MovePosition(testTransform.position + move);
                    }

                };
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                SceneManager.MoveGameObjectToScene(_rigidbody.gameObject, testScene);
            }
        }

        void OnDrawGizmos()
        {
            if (_rigidbody == null)
            {
                return;
            }

            Transform testTransform = _rigidbody.transform;
            Vector3 p1 = testTransform.position + _capsuleCollider.center - Vector3.up * _capsuleCollider.height * 0.5f + Vector3.up * _capsuleCollider.radius;
            Vector3 p2 = p1 + Vector3.up * _capsuleCollider.height - Vector3.up * _capsuleCollider.radius- Vector3.up * _capsuleCollider.radius ;
            Gizmos.color = Color.green;
            Gizmos.DrawLine(p1, p2);
            Gizmos.DrawSphere(p1, _capsuleCollider.radius);
            Gizmos.DrawSphere(p2, _capsuleCollider.radius);
            if (Physics.CheckCapsule(p1, p2, _capsuleCollider.radius, Physics.AllLayers, QueryTriggerInteraction.Ignore))
            {
                Collider[] colliders = Physics.OverlapCapsule(p1, p2, _capsuleCollider.radius, Physics.AllLayers);

                foreach (Collider collider in colliders)
                {
                    if (collider.transform.IsChildOf(testTransform))
                    {
                        continue;
                    }
                    // 使用 ClosestPoint 獲取碰撞點
                    Vector3 collisionPoint = collider.ClosestPoint(p1 + Vector3.up * _capsuleCollider.height * 0.5f);

                    // Debug: 顯示碰撞點
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere(collisionPoint, 0.1f);
                    Gizmos.DrawLine(collisionPoint, ((p1 + Vector3.up * _capsuleCollider.height * 0.5f)));
                    // Gizmos.DrawRay(collisionPoint, ((p1 + Vector3.up * _capsuleCollider.height * 0.5f) - collisionPoint).normalized * _capsuleCollider.radius);
                }
            };
        }
    }
}
