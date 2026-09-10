# 06-Go

Go learning — mini HTTP server.

## Contents

```
Go-Lang/
└── src/go-server/
    ├── main.go          # http.FileServer + /form, /submit handlers (port :8080)
    └── static/
        ├── index.html   # static welcome page
        └── form.html    # POST form
```

## Run (requires Go)

```bash
cd "06-Go/Go-Lang/src/go-server"
go run .
# open http://localhost:8080
```