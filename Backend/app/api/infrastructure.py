from fastapi import APIRouter

from app.models.infrastructure import Infrastructure


router = APIRouter(
    prefix="/api/infrastructure",
    tags=["Infrastructure"]
)


infrastructure_data = [
    {
        "id": "cloud",
        "name": "Cloud",
        "type": "Cloud Infrastructure",
        "status": "Online",
        "cpu": 45,
        "memory": 62
    },
    {
        "id": "load-balancer",
        "name": "Load Balancer",
        "type": "Load Balancer",
        "status": "Online",
        "cpu": 32,
        "memory": 48
    },
    {
        "id": "web-server-1",
        "name": "Web Server 1",
        "type": "Web Server",
        "status": "Online",
        "cpu": 58,
        "memory": 67
    },
    {
        "id": "web-server-2",
        "name": "Web Server 2",
        "type": "Web Server",
        "status": "Online",
        "cpu": 51,
        "memory": 61
    },
    {
        "id": "database",
        "name": "Database",
        "type": "Database",
        "status": "Online",
        "cpu": 42,
        "memory": 73
    }
]


@router.get("/", response_model=dict)
def get_infrastructure():
    return {
        "count": len(infrastructure_data),
        "infrastructure": infrastructure_data
    }


@router.get("/{infrastructure_id}", response_model=Infrastructure)
def get_infrastructure_by_id(infrastructure_id: str):

    for item in infrastructure_data:
        if item["id"] == infrastructure_id:
            return item

    return {
        "error": "Infrastructure object not found"
    }