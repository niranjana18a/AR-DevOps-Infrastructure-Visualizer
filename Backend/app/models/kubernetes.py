from pydantic import BaseModel
from typing import List


class Container(BaseModel):
    id: str
    name: str
    status: str


class Pod(BaseModel):
    id: str
    name: str
    status: str
    containers: List[Container]


class Node(BaseModel):
    id: str
    name: str
    status: str
    cpu: float
    memory: float
    pods: List[Pod]


class KubernetesCluster(BaseModel):
    id: str
    name: str
    status: str
    nodes: List[Node]