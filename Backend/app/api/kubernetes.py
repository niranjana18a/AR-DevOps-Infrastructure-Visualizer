from fastapi import APIRouter

from app.models.kubernetes import KubernetesCluster


router = APIRouter(
    prefix="/api/kubernetes",
    tags=["Kubernetes"]
)


kubernetes_data = {
    "id": "cluster-1",
    "name": "Kubernetes Cluster",
    "status": "Running",
    "nodes": [
        {
            "id": "node-1",
            "name": "Node 1",
            "status": "Running",
            "cpu": 48,
            "memory": 61,
            "pods": [
                {
                    "id": "pod-1",
                    "name": "Pod 1",
                    "status": "Running",
                    "containers": [
                        {
                            "id": "container-1",
                            "name": "Container 1",
                            "status": "Running"
                        }
                    ]
                },
                {
                    "id": "pod-2",
                    "name": "Pod 2",
                    "status": "Running",
                    "containers": [
                        {
                            "id": "container-2",
                            "name": "Container 2",
                            "status": "Running"
                        }
                    ]
                }
            ]
        },
        {
            "id": "node-2",
            "name": "Node 2",
            "status": "Running",
            "cpu": 52,
            "memory": 67,
            "pods": [
                {
                    "id": "pod-3",
                    "name": "Pod 3",
                    "status": "Running",
                    "containers": [
                        {
                            "id": "container-3",
                            "name": "Container 3",
                            "status": "Running"
                        }
                    ]
                },
                {
                    "id": "pod-4",
                    "name": "Pod 4",
                    "status": "Running",
                    "containers": [
                        {
                            "id": "container-4",
                            "name": "Container 4",
                            "status": "Running"
                        }
                    ]
                }
            ]
        }
    ]
}


@router.get("/", response_model=KubernetesCluster)
def get_kubernetes_cluster():
    return kubernetes_data