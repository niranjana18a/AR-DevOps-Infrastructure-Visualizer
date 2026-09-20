pipeline {
    agent any

    environment {
        PYTHON = 'C:\\Users\\PRATHIBAN\\AppData\\Local\\Programs\\Python\\Python313\\python.exe'
    }

    stages {

        stage('Checkout') {
            steps {
                echo 'Checking out project source code...'
                checkout scm
            }
        }

        stage('Python Environment') {
            steps {
                echo 'Checking Python installation...'
                bat '%PYTHON% --version'

                echo 'Creating Jenkins Python environment...'
                bat '%PYTHON% -m venv Backend\\venv'

                echo 'Installing backend dependencies...'
                bat 'Backend\\venv\\Scripts\\python.exe -m pip install -r Backend\\requirements.txt'

                echo 'Installing testing dependencies...'
                bat 'Backend\\venv\\Scripts\\python.exe -m pip install pytest httpx'
            }
        }

        stage('Backend Validation') {
            steps {
                echo 'Validating FastAPI backend structure...'
                bat 'dir Backend'
                bat 'dir Backend\\app'
            }
        }

        stage('API Import Test') {
            steps {
                echo 'Testing FastAPI application import...'
                bat 'cd Backend && venv\\Scripts\\python.exe -c "from app.main import app; print(app.title)"'
            }
        }

        stage('Automated API Tests') {
            steps {
                echo 'Running automated FastAPI API tests...'
                bat 'cd Backend && venv\\Scripts\\python.exe -m pytest tests\\test_api.py -v'
            }
        }

        stage('CI Success') {
            steps {
                echo 'AR DevOps Infrastructure Visualizer CI pipeline completed successfully!'
            }
        }
    }

    post {
        success {
            echo 'BUILD SUCCESSFUL'
        }

        failure {
            echo 'BUILD FAILED'
        }
    }
}