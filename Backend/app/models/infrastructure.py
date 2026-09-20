from pydantic import BaseModel


class Infrastructure(BaseModel):
    id: str
    name: str
    type: str
    status: str
    cpu: float
    memory: float