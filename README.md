# Back

Cette image Docker contient l'API .NET et expose également les métriques Prometheus via **node_exporter**.

Le serveur d'API écoute sur le port `80` et les métriques sont disponibles sur le port `9100`.

Dans `docker-compose.yml`, ces ports sont mappés respectivement sur `44318` et `9100`.

L'image intègre également **Grafana Alloy** afin d'envoyer les logs de l'application vers une instance Loki. L'URL de Loki doit être fournie via la variable d'environnement `LOKI_URL`.
Les logs de l'API sont écrits dans `/var/log/cocovoit/api.log` et sont exportés via Alloy.
Alloy collecte aussi les journaux système présents dans `/var/log` pour les transmettre à Loki.
