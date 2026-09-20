from pydantic import BaseModel


class Alert(BaseModel):
    id: str
    type: str
    severity: str
    message: str
    status: str