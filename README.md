# Demo Chaos Engineering

Projeto composto por uma API C# e um FrontEnd Blazor, que permite a inclusão/edição/exclusão de carros.

Objetivo é demonstrar alguns cenários de aplicação da engenharia do caos, utilizando a ferramenta Chaos Mesh (https://chaos-mesh.org).

### Tecnologias utilizadas:
 - Backend: API .NET 6
 - Frontend: .NET Blazor
 - Banco de dados: SQL Server
 - Monitoramento: Application Insights
 - Ferramenta Chaos Engineering: Chaos Mesh
 
 ### Instalação do Chaos Mesh no cluster kubernetes (https://chaos-mesh.org/docs/quick-start/):
 
```
helm repo add chaos-mesh https://charts.chaos-mesh.org
kubectl create ns chaos-testing
helm install chaos-mesh chaos-mesh/chaos-mesh -n=chaos-testing --set chaosDaemon.runtime=containerd --set chaosDaemon.socketPath=/run/containerd/containerd.sock --version 2.3.0
kubectl port-forward -n chaos-testing svc/chaos-dashboard 2333:2333
```
