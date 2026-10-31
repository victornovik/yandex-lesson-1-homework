# Warmhouse REST API

## Спецификации OpenAPI

| Сервис            | Спецификация                                                     | Основные операции                                                                         |
| ----------------- | ---------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| Automation        | [automation-service.yaml](automation-service.yaml)               | CRUD сценариев                                                                            |
| Device Management | [device-management-service.yaml](device-management-service.yaml) | CRUD устройств, отправка и получение статуса команды                                      |
| Home Management   | [home-management-service.yaml](home-management-service.yaml)     | Список, создание и просмотр домов, добавление участника, изменение роли, проверка доступа |
| Telemetry         | [telemetry-service.yaml](telemetry-service.yaml)                 | Получение свежих показаний по дому и устройствам, получение истории показаний             |

## Особенности работы

### Внутренний API

- `/internal` route используется только для межсервисного API, не экспозируется наружу через API Gateway.

### Проверка доступа

- Для проверки доступа к дому сервисы вызывают внутреннее API `/api/internal/homes/{homeId}/access-checks`.

### Device Management API

- **deviceId** - это глобально-уникальный UUID, сквозной для всех домов.
- **commandId** - это глобально-уникальный UUID, сквозной для всех домов и устройств.
  <br>
- `POST /homes/{homeId}/devices/{deviceId}/commands` возвращает `202 Accepted` и JSON с `commandId` и `status`, что означает принятие асихнронной команды на обработку, а не её выполнение. Инициатор запроса может прочитать статус выполнения через GET команды.

### Telemetry API

- Telemetry API работает только на чтение. By design.
