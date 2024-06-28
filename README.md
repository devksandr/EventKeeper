# Event keeper API

## Description
API to manipulate `Event` enteties.

`Event` has fields:
- `Name` (event name)
- `Value` (event weight)
- `Timestamp` (add date to DB)

Available `Event` API:
- `Add`
- `Get` (filtered by date range)

## Development technologies
Backend: ASP.Net.Core WEB API + Entity Framework Core + SQLite

## API
### Add
`Add` require `POST` request with body like:
```json
{
  "name": "EVENT_NAME",
  "value": 100
}
```

Field `Timestamp` for `Event` entity set automatically when request sended

### Get
`Get` require `GET` request with parameters like:
```
https://localhost:7221/api/event?startRange=2024-06-13T21:15:32&endRange=2024-06-13T21:16:03
```

Fields:
- `startRange`
- `endRange`

`Event` entities with `Timestamp` field that fall within this range will be selected

<details>
  <summary>Example (Client - Postman)</summary>
  <img src="test_data_example.png">
</details>

#### Rounding
Input range values can contains seconds therefore it's necessary to make a decision how to calculate time filter
In this API:
- `startRange` - round down (seconds are discarded)
- `endRange` - round up (to a whole minute)

Example:
```
Before - [19:29:32 - 19:31:03]
After - [19:29:00 - 19:32:00]
```


