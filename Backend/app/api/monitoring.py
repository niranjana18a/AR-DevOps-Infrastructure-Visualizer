from fastapi import APIRouter

from app.models.monitoring import MonitoringMetrics


router = APIRouter(
    prefix="/api/monitoring",
    tags=["Monitoring"]
)


monitoring_data = {
    "cpu": 56,
    "memory": 64,
    "network": 42,
    "disk": 38
}


@router.get("/", response_model=MonitoringMetrics)
def get_monitoring_metrics():
    return monitoring_data