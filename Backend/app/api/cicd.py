from fastapi import APIRouter

from app.models.cicd import CICDPipeline


router = APIRouter(
    prefix="/api/cicd",
    tags=["CI/CD"]
)


cicd_data = {
    "id": "pipeline-1",
    "name": "AR DevOps Pipeline",
    "status": "Success",
    "stages": [
        {
            "id": "commit",
            "name": "Commit",
            "status": "Success",
            "duration": 12,
            "message": "Source code committed successfully"
        },
        {
            "id": "build",
            "name": "Build",
            "status": "Success",
            "duration": 45,
            "message": "Application built successfully"
        },
        {
            "id": "test",
            "name": "Test",
            "status": "Success",
            "duration": 38,
            "message": "All tests passed"
        },
        {
            "id": "deploy",
            "name": "Deploy",
            "status": "Success",
            "duration": 60,
            "message": "Application deployed successfully"
        }
    ]
}


@router.get("/", response_model=CICDPipeline)
def get_cicd_pipeline():
    return cicd_data