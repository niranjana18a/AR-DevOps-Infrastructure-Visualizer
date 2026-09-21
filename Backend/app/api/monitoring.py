import os
import requests

from fastapi import APIRouter

router = APIRouter(
    prefix="/api/monitoring",
    tags=["Monitoring"]
)

PROMETHEUS_URL = os.getenv(
    "PROMETHEUS_URL",
    "http://localhost:9090"
)


def query_prometheus(metric_name: str):
    try:
        response = requests.get(
            f"{PROMETHEUS_URL}/api/v1/query",
            params={"query": metric_name},
            timeout=5
        )

        response.raise_for_status()

        data = response.json()

        if data["status"] != "success":
            return None

        results = data["data"]["result"]

        if not results:
            return None

        return float(results[0]["value"][1])

    except requests.RequestException:
        return None


@router.get("/")
def get_monitoring_metrics():
    return {
        "cpu": query_prometheus("ar_devops_cpu_usage"),
        "memory": query_prometheus("ar_devops_memory_usage"),
        "network": query_prometheus("ar_devops_network_usage"),
        "disk": query_prometheus("ar_devops_disk_usage")
    }


@router.get("/prometheus")
def get_prometheus_metrics():
    return {
        "source": "Prometheus",
        "cpu": query_prometheus("ar_devops_cpu_usage"),
        "memory": query_prometheus("ar_devops_memory_usage"),
        "network": query_prometheus("ar_devops_network_usage"),
        "disk": query_prometheus("ar_devops_disk_usage")
    }