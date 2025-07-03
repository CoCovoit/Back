# Back

Cette image Docker contient l'API .NET et expose également les métriques Prometheus via **node_exporter**.

Le serveur d'API écoute sur le port `80` et les métriques sont disponibles sur le port `9100`.

Dans `docker-compose.yml`, ces ports sont mappés respectivement sur `44318` et `9100`.
