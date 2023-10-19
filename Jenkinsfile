pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                checkout([$class: 'GitSCM', branches: [[name: '*/main']], doGenerateSubmoduleConfigurations: false, extensions: [], submoduleCfg: [], userRemoteConfigs: [[credentialsId: 'jenkins_1', url: 'https://username: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@github.com/phamhaiddc/API_Application']]])            
            }           
        }
        
        stage('Build') {
            steps {
                script {
                    // Restoring NuGet packages
                        bat 'dotnet restore'
                        bat 'dotnet build'

                    // Building the .NET project
                }
            }
        }



        stage('Publish') {
            steps {
                script {
                    // Publishing the application
                    bat 'dotnet publish --no-restore --configuration Release --output ./publish'
                }
            }
        }
    }

    post {
        success {
            archiveArtifacts artifacts: '**/publish/**', allowEmptyArchive: true
        }
    }
}
