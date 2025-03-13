# Player management

Typical Approach:

When the player logs in (submits a username), generate a unique session ID on the server.
Send that session ID back to the client as a cookie.
On each request (or socket connection) from the browser, check the cookie to identify the same session.
How it helps:

If the user opens a new tab in the same browser, the session cookie is automatically sent along with each request. This allows the server to identify the same player regardless of how many tabs are open.

```mermaid
sequenceDiagram
    autonumber

    participant U as User (Browser)
    participant F as Frontend Code
    participant B as Backend Server

    Note over U: 1. User opens the game page

    U->>F: Enter Username
    F->>B: Send username to server (HTTP POST /login)

    B->>B: Generate session ID<br/>Store session data<br/>Link to the user
    B->>F: Return response with<br/>Set-Cookie: sessionID=xyz

    Note over F: 2. Frontend has sessionID in the cookie<br/>automatically stored by the browser

    U->>F: User opens another tab<br/>or refreshes page
    F->>B: Any new request includes<br/>Cookie: sessionID=xyz

    B->>B: Look up session based on sessionID
    B-->>F: Return game data or relevant response<br/>knowing it's the same user

    Note over B,F: Both requests are identified as<br/>the same user via the session cookie.
```
