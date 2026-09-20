from pydantic import BaseModel
from typing import List


class PipelineStage(BaseModel):
    id: str
    name: str
    status: str
    duration: float
    message: str


class CICDPipeline(BaseModel):
    id: str
    name: str
    status: str
    stages: List[PipelineStage]