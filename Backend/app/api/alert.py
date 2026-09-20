from fastapi import APIRouter

from app.models.alert import Alert


router = APIRouter(
    prefix="/api/alerts",
    tags=["Alerts"]
)


alerts_data = [
    {
        "id": "alert-1",
        "type": "CPU",
        "severity": "Warning",
        "message": "CPU usage is above normal threshold",
        "status": "Active"
    },
    {
        "id": "alert-2",
        "type": "Memory",
        "severity": "Warning",
        "message": "Memory usage is above normal threshold",
        "status": "Active"
    }
]


@router.get("/", response_model=list[Alert])
def get_alerts():
    return alerts_data