from fastapi import FastAPI
from fastapi.responses import PlainTextResponse
import random

from app.api.infrastructure import router as infrastructure_router
from app.api.kubernetes import router as kubernetes_router
from app.api.cicd import router as cicd_router
from app.api.monitoring import router as monitoring_router
from app.api.alert import router as alert_router


app = FastAPI(
    title="AR DevOps Infrastructure Visualizer API",
    description="Backend API for the AR DevOps Infrastructure Visualizer",
    version="1.0.0"
)


app.include_router(infrastructure_router)
app.include_router(kubernetes_router)
app.include_router(cicd_router)
app.include_router(monitoring_router)
app.include_router(alert_router)


@app.get("/")
def root():
    return {
        "message": "AR DevOps Infrastructure Visualizer API is running",
        "status": "online"
    }


@app.get("/health")
def health_check():
    return {
        "status": "healthy"
    }


@app.get("/metrics", response_class=PlainTextResponse)
def metrics():

    # Simulated live monitoring values for development/demo
    cpu = random.randint(20, 90)
    memory = random.randint(30, 85)
    network = random.randint(10, 80)
    disk = random.randint(20, 75)

    return f"""# HELP ar_devops_cpu_usage Current CPU usage percentage
# TYPE ar_devops_cpu_usage gauge
ar_devops_cpu_usage {cpu}

# HELP ar_devops_memory_usage Current memory usage percentage
# TYPE ar_devops_memory_usage gauge
ar_devops_memory_usage {memory}

# HELP ar_devops_network_usage Current network usage percentage
# TYPE ar_devops_network_usage gauge
ar_devops_network_usage {network}

# HELP ar_devops_disk_usage Current disk usage percentage
# TYPE ar_devops_disk_usage gauge
ar_devops_disk_usage {disk}
"""