from pydantic import BaseModel


class MonitoringMetrics(BaseModel):
    cpu: float
    memory: float
    network: float
    disk: float