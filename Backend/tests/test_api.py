from fastapi.testclient import TestClient

from app.main import app


client = TestClient(app)


def test_root():
    response = client.get("/")
    assert response.status_code == 200

    data = response.json()

    assert data["status"] == "online"


def test_health():
    response = client.get("/health")
    assert response.status_code == 200

    data = response.json()

    assert data["status"] == "healthy"


def test_infrastructure():
    response = client.get("/api/infrastructure/")
    assert response.status_code == 200

    data = response.json()

    assert "count" in data
    assert "infrastructure" in data
    assert data["count"] == 5
    assert isinstance(data["infrastructure"], list)
    assert len(data["infrastructure"]) == 5


def test_kubernetes():
    response = client.get("/api/kubernetes/")
    assert response.status_code == 200

    data = response.json()

    assert data["status"] == "Running"
    assert len(data["nodes"]) == 2


def test_cicd():
    response = client.get("/api/cicd/")
    assert response.status_code == 200

    data = response.json()

    assert data["status"] == "Success"
    assert len(data["stages"]) == 4


def test_monitoring():
    response = client.get("/api/monitoring/")
    assert response.status_code == 200

    data = response.json()

    assert "cpu" in data
    assert "memory" in data
    assert "network" in data
    assert "disk" in data


def test_alerts():
    response = client.get("/api/alerts/")
    assert response.status_code == 200

    data = response.json()

    assert isinstance(data, list)

def test_prometheus_monitoring():
    response = client.get("/api/monitoring/prometheus")

    assert response.status_code == 200

    data = response.json()

    assert data["source"] == "Prometheus"

    assert "cpu" in data
    assert "memory" in data
    assert "network" in data
    assert "disk" in data

    if data["cpu"] is not None:
        assert isinstance(data["cpu"], (int, float))

    if data["memory"] is not None:
        assert isinstance(data["memory"], (int, float))

    if data["network"] is not None:
        assert isinstance(data["network"], (int, float))

    if data["disk"] is not None:
        assert isinstance(data["disk"], (int, float))