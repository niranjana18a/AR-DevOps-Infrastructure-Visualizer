from fastapi import FastAPI

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