# 📘 README.md — Golang Complete Developer Reference Guide

> **একটি Production-Ready, Beginner-Friendly Golang Tutorial ও Reference Guide**
> 
> এই README.md ফাইলটি এমনভাবে সাজানো যাতে আপনি Development, Coding, বা Tutorial এর সময় **দ্রুত reference** হিসেবে ব্যবহার করতে পারেন।

---

```markdown
# 🚀 Go Developer's Complete Handbook (বাংলা)

> Beginner থেকে Production-Level — একটি সম্পূর্ণ Reference Guide
> 
> **Version:** 1.0.0  
> **Last Updated:** 2025  
> **Language:** বাংলা  
> **Target Audience:** Beginner → Professional Backend Developer

---

## 📖 সূচিপত্র (Table of Contents)

1. [Go কী?](#১-go-কী)
2. [Installation ও Setup](#২-installation-ও-setup)
3. [Project Structure](#৩-project-structure)
4. [Essential Commands Cheat Sheet](#৪-essential-commands-cheat-sheet)
5. [Basic Syntax Quick Reference](#৫-basic-syntax-quick-reference)
6. [Data Types ও Variables](#৬-data-types-ও-variables)
7. [Control Flow](#৭-control-flow)
8. [Functions ও Methods](#৮-functions-ও-methods)
9. [Structs ও Interfaces](#৯-structs-ও-interfaces)
10. [Error Handling](#১০-error-handling)
11. [Concurrency](#১১-concurrency)
12. [Packages ও Modules](#১২-packages-ও-modules)
13. [Testing](#১৩-testing)
14. [REST API Development](#১৪-rest-api-development)
15. [Database (MySQL + GORM)](#১৫-database-mysql--gorm)
16. [JWT Authentication](#১৬-jwt-authentication)
17. [Docker](#১৭-docker)
18. [Production Best Practices](#১৮-production-best-practices)
19. [Common Errors ও Solutions](#১৯-common-errors-ও-solutions)
20. [Debugging Techniques](#২০-debugging-techniques)
21. [Useful Resources](#২১-useful-resources)

---

## ১. Go কী?

**Go (Golang)** হলো Google-এর তৈরি একটি **statically typed**, **compiled**, **concurrent** প্রোগ্রামিং ল্যাংগুয়েজ।

### 🎯 কেন Go ব্যবহার করবেন?

| Feature | সুবিধা |
|---------|-------|
| ⚡ **Fast Compilation** | সেকেন্ডে compile |
| 🚀 **High Performance** | C/C++ এর কাছাকাছি |
| 🔄 **Built-in Concurrency** | Goroutines & Channels |
| 📦 **Single Binary** | কোনো dependency নেই |
| 🧹 **Simple Syntax** | মাত্র ২৫টি keyword |
| 🛡️ **Strong Standard Library** | HTTP, JSON, Crypto built-in |
| 🌍 **Cross-Platform** | সব OS এর জন্য build |

### 📊 Go vs Other Languages

| Feature | Go | Python | Java | Node.js |
|---------|-----|--------|------|---------|
| Speed | ⚡⚡⚡ | 🐢 | ⚡⚡ | ⚡⚡ |
| Concurrency | ✅ Native | ⚠️ GIL | ✅ Threads | ⚠️ Event Loop |
| Learning Curve | সহজ | সহজ | কঠিন | সহজ |
| Production Ready | ✅ | ✅ | ✅ | ✅ |
| Binary Size | ছোট | N/A | বড় | মাঝারি |

---

## ২. Installation ও Setup

### 🖥️ Installation

**Windows:**
```bash
# https://go.dev/dl/ থেকে .msi ডাউনলোড করে install করুন
# Verify:
go version
```

**Linux:**
```bash
wget https://go.dev/dl/go1.22.0.linux-amd64.tar.gz
sudo tar -C /usr/local -xzf go1.22.0.linux-amd64.tar.gz

# ~/.bashrc বা ~/.zshrc
export PATH=$PATH:/usr/local/go/bin
export GOPATH=$HOME/go
export PATH=$PATH:$GOPATH/bin

source ~/.bashrc
go version
```

**macOS:**
```bash
brew install go
go version
```

### ⚙️ Essential Environment Variables

```bash
go env                    # সব env variable দেখুন
go env GOPATH             # GOPATH location
go env GOROOT             # Go installation directory
go env GOCACHE            # Build cache location
go env GOOS               # Current OS
go env GOARCH             # Current architecture

# Set custom:
export GOPATH=$HOME/go
export GOBIN=$HOME/go/bin
export GO111MODULE=on
```

### 🔧 IDE Setup (VS Code — Recommended)

**Extensions install করুন:**
- `golang.go` (Official Go extension)
- `golang.go-nightly` (optional)
- `premparihar.gotestexplorer` (testing)

**`.vscode/settings.json`:**
```json
{
    "go.formatTool": "gofmt",
    "go.formatFlags": ["-s"],
    "go.lintTool": "golangci-lint",
    "go.useLanguageServer": true,
    "editor.formatOnSave": true,
    "editor.codeActionsOnSave": {
        "source.organizeImports": "explicit"
    },
    "[go]": {
        "editor.insertSpaces": false,
        "editor.tabSize": 4
    }
}
```

---

## ৩. Project Structure

### 📁 Standard Production Structure

```
my-project/
│
├── cmd/                          # Application entry points
│   └── api/
│       └── main.go               # main() function
│
├── internal/                     # Private application code
│   ├── config/                   # Configuration
│   │   └── config.go
│   ├── handler/                  # HTTP handlers (controllers)
│   │   └── user_handler.go
│   ├── service/                  # Business logic
│   │   └── user_service.go
│   ├── repository/               # Data access layer
│   │   └── user_repository.go
│   ├── model/                    # Domain models
│   │   └── user.go
│   ├── dto/                      # Data Transfer Objects
│   │   └── user_dto.go
│   ├── middleware/               # HTTP middlewares
│   │   ├── auth.go
│   │   └── logger.go
│   └── router/                   # Route definitions
│       └── router.go
│
├── pkg/                          # Public reusable packages
│   ├── jwt/
│   ├── hash/
│   └── validator/
│
├── migrations/                   # Database migrations
│   └── 001_init.sql
│
├── docs/                         # Swagger/API docs
│   ├── docs.go
│   └── swagger.json
│
├── tests/                        # Integration tests
│   └── integration_test.go
│
├── deployments/                  # Docker, k8s files
│   ├── Dockerfile
│   └── docker-compose.yml
│
├── scripts/                      # Build/deploy scripts
│   └── build.sh
│
├── .env                          # Environment variables
├── .env.example                  # Template for .env
├── .gitignore
├── .golangci.yml                 # Linter config
├── Makefile                      # Build automation
├── go.mod                        # Module definition
├── go.sum                        # Dependency checksums
└── README.md
```

### 📌 Folder এর কাজ

| Folder | কাজ | উদাহরণ |
|--------|-----|--------|
| `cmd/` | Entry points | `main.go` |
| `internal/` | Private code (external import ব্লক) | Business logic |
| `pkg/` | Public reusable code | Utils, helpers |
| `config/` | Config loading | DB, env |
| `handler/` | HTTP request handling | `gin.Context` |
| `service/` | Business logic | Validation, rules |
| `repository/` | Database queries | GORM queries |
| `model/` | Database models | GORM structs |
| `dto/` | Request/Response structs | `UserRequest` |
| `middleware/` | Request interceptors | Auth, logger |
| `migrations/` | DB migrations | SQL files |
| `tests/` | Integration tests | End-to-end |

### 🎯 Clean Architecture Flow

```
┌────────────────────────────────────────────┐
│  HTTP Request (Client)                     │
└────────────────┬───────────────────────────┘
                 ▼
┌────────────────────────────────────────────┐
│  Handler (Controller)                       │
│  - Request parse, DTO bind                  │
│  - Response format                          │
└────────────────┬───────────────────────────┘
                 ▼
┌────────────────────────────────────────────┐
│  Service Layer (Business Logic)             │
│  - Validation                               │
│  - Business rules                           │
│  - Orchestration                            │
└────────────────┬───────────────────────────┘
                 ▼
┌────────────────────────────────────────────┐
│  Repository Layer (Data Access)             │
│  - Database queries                         │
│  - ORM operations                           │
└────────────────┬───────────────────────────┘
                 ▼
┌────────────────────────────────────────────┐
│  Database (MySQL)                           │
└────────────────────────────────────────────┘
```

---

## ৪. Essential Commands Cheat Sheet

### 🚀 Development Commands

```bash
# 📦 Module Management
go mod init github.com/user/project    # New module
go mod tidy                            # Add missing, remove unused
go mod download                        # Download dependencies
go mod verify                          # Verify checksums
go mod graph                           # Show dependency graph
go mod why <package>                   # Why is this dependency needed

# 🏃 Run Code
go run main.go                         # Run file
go run .                               # Run current package
go run ./cmd/api                       # Run specific package
go run main.go arg1 arg2               # Run with arguments
go run -race main.go                   # With race detector

# 🔨 Build
go build                               # Build current package
go build -o app main.go                # Named output
go build ./...                         # Build all packages
go build -o ./bin/api ./cmd/api        # Specific package

# 🎯 Production Build
CGO_ENABLED=0 go build -trimpath \
    -ldflags="-s -w -X main.Version=1.0.0" \
    -o ./bin/app ./cmd/api

# 🌍 Cross Compilation
GOOS=linux GOARCH=amd64 go build -o app-linux main.go
GOOS=windows GOARCH=amd64 go build -o app.exe main.go
GOOS=darwin GOARCH=arm64 go build -o app-mac main.go
go tool dist list                      # List all supported platforms

# 🧪 Testing
go test                                # Test current package
go test ./...                          # Test all packages
go test -v                             # Verbose
go test -run TestUserCreate            # Specific test
go test -cover                         # Coverage
go test -coverprofile=coverage.out     # Coverage file
go tool cover -html=coverage.out       # Coverage HTML
go test -race                          # Race detector
go test -bench=.                       # Run benchmarks
go test -timeout 30s ./...             # Custom timeout

# 🎨 Code Quality
gofmt -w .                             # Format all files
go fmt ./...                           # Format via go tool
go vet ./...                           # Static analysis
golangci-lint run                      # Advanced linting

# 📊 Dependency Inspection
go list -m all                         # All dependencies
go list -m -u all                      # Check for updates
go list -m -versions <package>         # Available versions

# 🧹 Cleanup
go clean                               # Clean build artifacts
go clean -cache                        # Clean build cache
go clean -testcache                    # Clean test cache
go clean -modcache                     # Clean module cache

# 📖 Documentation
go doc fmt                             # Package docs
go doc fmt.Println                     # Function docs
go doc -all fmt                        # All docs
godoc -http=:6060                      # Local docs server

# 🔍 Debugging
go env                                 # Show environment
go version                             # Show version
go vet ./...                           # Static check
dlv debug main.go                      # Debugger (install dlv first)
```

### 📝 Makefile Template

```makefile
.PHONY: help build run test clean fmt vet lint docker

APP_NAME := my-api
VERSION  ?= $(shell git describe --tags --always --dirty)
BUILD_TIME := $(shell date -u +%Y-%m-%dT%H:%M:%SZ)
GIT_COMMIT := $(shell git rev-parse --short HEAD)

LDFLAGS := -s -w \
    -X main.Version=$(VERSION) \
    -X main.BuildTime=$(BUILD_TIME) \
    -X main.GitCommit=$(GIT_COMMIT)

help:
	@echo "Available commands:"
	@grep -E '^[a-zA-Z_-]+:.*?## .*$$' $(MAKEFILE_LIST) | awk 'BEGIN {FS = ":.*?## "}; {printf "  \033[36m%-15s\033[0m %s\n", $$1, $$2}'

build: ## Build the application
	CGO_ENABLED=0 go build -trimpath -ldflags="$(LDFLAGS)" -o ./bin/$(APP_NAME) ./cmd/api

run: ## Run in development mode
	go run ./cmd/api

test: ## Run tests with coverage
	go test -race -cover -coverprofile=coverage.out ./...

cover: test ## Show test coverage
	go tool cover -html=coverage.out

fmt: ## Format code
	gofmt -s -w .

vet: ## Vet code
	go vet ./...

lint: ## Run linter
	golangci-lint run

tidy: ## Tidy dependencies
	go mod tidy

clean: ## Clean build artifacts
	rm -rf ./bin coverage.out

docker: ## Build Docker image
	docker build -t $(APP_NAME):$(VERSION) -f deployments/Dockerfile .

docker-run: ## Run Docker container
	docker run --rm -p 8080:8080 --env-file .env $(APP_NAME):$(VERSION)
```

---

## ৫. Basic Syntax Quick Reference

### 📝 Hello World

```go
package main

import "fmt"

func main() {
    fmt.Println("হ্যালো, Go!")
}
```

### 📦 Import Patterns

```go
// Single import
import "fmt"

// Multiple imports
import (
    "fmt"
    "os"
    "strings"
)

// Aliased import
import (
    f "fmt"
    _ "github.com/lib/pq"        // Blank — side effects only
    . "math"                      // Dot — direct access
)

// Import grouping (best practice)
import (
    // Standard library
    "fmt"
    "net/http"

    // Third-party
    "github.com/gin-gonic/gin"
    "gorm.io/gorm"

    // Internal
    "myapp/internal/service"
)
```

---

## ৬. Data Types ও Variables

### 📊 Basic Types

```go
// Boolean
var isActive bool = true

// Integer (signed)
var i8  int8  = 127
var i16 int16 = 32767
var i32 int32 = 2147483647
var i64 int64 = 9223372036854775807
var i   int   = 42              // Platform dependent (32 or 64)

// Integer (unsigned)
var u8  uint8  = 255
var u16 uint16 = 65535
var u32 uint32 = 4294967295
var u64 uint64 = 18446744073709551615

// Floating point
var f32 float32 = 3.14
var f64 float64 = 3.141592653589793

// Complex
var c64 complex64 = 1 + 2i
var c128 complex128 = 1 + 2i

// String
var name string = "রহিম"
var raw string = `Multi
line
string`                         // Raw string (backticks)

// Byte & Rune
var b byte = 'A'                // uint8 alias
var r rune = 'আ'                // int32 alias (Unicode)
```

### 📝 Variable Declaration (৫টি উপায়)

```go
// 1. Explicit with var
var name string = "রহিম"

// 2. With type inference
var age = 25

// 3. Multiple declaration
var (
    firstName string = "রহিম"
    lastName  string = "খান"
    age       int    = 25
)

// 4. Short declaration (function এর ভিতরে only)
name := "রহিম"

// 5. Multiple short
x, y := 10, 20
```

### 🔒 Constants

```go
// Basic
const PI = 3.14159
const AppName = "MyApp"

// Typed
const MaxSize int = 1024

// Grouped
const (
    StatusActive   = "active"
    StatusInactive = "inactive"
    StatusDeleted  = "deleted"
)

// iota — auto-increment
const (
    Sunday = iota    // 0
    Monday           // 1
    Tuesday          // 2
    Wednesday        // 3
)

// iota with expressions
const (
    _  = iota             // skip 0
    KB = 1 << (10 * iota) // 1024
    MB                    // 1048576
    GB                    // 1073741824
    TB                    // 1099511627776
)
```

### 🔄 Type Conversion

```go
// Explicit conversion (Go তে implicit নেই)
var i int = 42
var f float64 = float64(i)
var u uint = uint(f)

// String ↔ []byte
s := "hello"
b := []byte(s)
s2 := string(b)

// String ↔ []rune (Unicode safe)
s3 := "হ্যালো"
r := []rune(s3)
s4 := string(r)

// Integer ↔ String
import "strconv"

num, err := strconv.Atoi("123")         // string → int
str := strconv.Itoa(456)                // int → string
f, err := strconv.ParseFloat("3.14", 64)
```

### 🎯 Zero Values

```go
// Zero values — Go তে সব variable initialized
var i int       // 0
var f float64   // 0.0
var s string    // "" (empty)
var b bool      // false
var p *int      // nil
var sl []int    // nil
var m map[string]int  // nil
var c chan int  // nil
var fn func()   // nil

// Struct — সব field zero value
type User struct {
    Name string  // ""
    Age  int     // 0
    Active bool  // false
}
var u User       // {"" 0 false}
```

### 📦 Composite Types

```go
// Array (fixed size)
var arr [5]int = [5]int{1, 2, 3, 4, 5}
arr2 := [...]int{1, 2, 3}        // Compiler counts

// Slice (dynamic)
var sl []int = []int{1, 2, 3}
sl = append(sl, 4, 5)
sl2 := make([]int, 5, 10)        // len=5, cap=10

// Map
var m map[string]int = map[string]int{"a": 1, "b": 2}
m2 := make(map[string]int)

// Struct
type User struct {
    Name string
    Age  int
}
u := User{Name: "রহিম", Age: 25}

// Pointer
var p *int = &i
*p = 100
```

---

## ৭. Control Flow

### 🔀 If-Else

```go
// Basic
if x > 10 {
    fmt.Println("বড়")
} else if x > 5 {
    fmt.Println("মাঝারি")
} else {
    fmt.Println("ছোট")
}

// With initialization
if err := doSomething(); err != nil {
    return err
}

// No ternary operator in Go!
// Use if-else instead
```

### 🔄 Switch

```go
// Basic switch
switch day {
case "sat", "sun":
    fmt.Println("Weekend")
case "mon", "tue", "wed", "thu", "fri":
    fmt.Println("Weekday")
default:
    fmt.Println("Invalid")
}

// Switch without expression (if-else chain)
switch {
case x > 100:
    fmt.Println("Big")
case x > 10:
    fmt.Println("Medium")
default:
    fmt.Println("Small")
}

// Type switch
switch v := i.(type) {
case int:
    fmt.Println("int:", v)
case string:
    fmt.Println("string:", v)
default:
    fmt.Println("unknown")
}

// Fallthrough (explicit)
switch x {
case 1:
    fmt.Println("one")
    fallthrough
case 2:
    fmt.Println("two")     // Will run if x==1
}
```

### 🔁 Loops

```go
// Traditional for
for i := 0; i < 10; i++ {
    fmt.Println(i)
}

// While-style
i := 0
for i < 10 {
    i++
}

// Infinite loop
for {
    // break or return to exit
}

// Range over slice
for i, v := range []int{10, 20, 30} {
    fmt.Println(i, v)
}

// Range over map
for k, v := range map[string]int{"a": 1} {
    fmt.Println(k, v)
}

// Range over string (rune-safe)
for i, r := range "হ্যালো" {
    fmt.Printf("%d: %c\n", i, r)
}

// Range over channel
for v := range ch {
    fmt.Println(v)
}

// Range with blank identifier
for _, v := range items {
    fmt.Println(v)
}

// Labels (nested loop break)
outer:
for i := 0; i < 3; i++ {
    for j := 0; j < 3; j++ {
        if i == 1 && j == 1 {
            break outer
        }
        fmt.Println(i, j)
    }
}
```

### 🎯 Defer, Panic, Recover

```go
// Defer — শেষে execute হয় (LIFO order)
func readFile() {
    f, err := os.Open("file.txt")
    if err != nil {
        return
    }
    defer f.Close()                // ফাংশন শেষে close হবে
    // ... file use
}

// Multiple defer (reverse order)
defer fmt.Println("1")
defer fmt.Println("2")
defer fmt.Println("3")
// Output: 3, 2, 1

// Panic
func mustPositive(n int) {
    if n < 0 {
        panic("negative number!")
    }
}

// Recover
func safeFunction() {
    defer func() {
        if r := recover(); r != nil {
            fmt.Println("Recovered:", r)
        }
    }()
    panic("something bad")
}
```

---

## ৮. Functions ও Methods

### 🔧 Basic Functions

```go
// Simple
func add(a, b int) int {
    return a + b
}

// Multiple return values
func divide(a, b int) (int, error) {
    if b == 0 {
        return 0, errors.New("division by zero")
    }
    return a / b, nil
}

// Named returns
func minMax(nums []int) (min, max int) {
    min, max = nums[0], nums[0]
    for _, n := range nums {
        if n < min { min = n }
        if n > max { max = n }
    }
    return
}

// Variadic
func sum(nums ...int) int {
    total := 0
    for _, n := range nums {
        total += n
    }
    return total
}
// Call: sum(1, 2, 3) or sum(slice...)

// Anonymous function
greet := func(name string) {
    fmt.Println("হ্যালো", name)
}
greet("রহিম")

// Function as value
var op func(int, int) int = add

// Higher-order function
func apply(nums []int, fn func(int) int) []int {
    result := make([]int, len(nums))
    for i, n := range nums {
        result[i] = fn(n)
    }
    return result
}
```

### 🎯 Methods

```go
type User struct {
    Name string
    Age  int
}

// Value receiver — copy পায়
func (u User) Greet() string {
    return "হ্যালো, " + u.Name
}

// Pointer receiver — original modify করতে পারে
func (u *User) Birthday() {
    u.Age++
}

// Call
u := User{Name: "রহিম", Age: 25}
fmt.Println(u.Greet())     // হ্যালো, রহিম
u.Birthday()               // Age = 26
```

### 📌 Value vs Pointer Receiver

```go
// ✅ Pointer receiver ব্যবহার করুন যখন:
// 1. Struct modify করবেন
// 2. বড় struct (performance)
// 3. Consistency (একটি method pointer হলে সব pointer)

// ❌ Value receiver ব্যবহার করুন যখন:
// 1. Struct immutable
// 2. ছোট struct
// 3. Read-only operations

type Counter struct {
    Count int
}

func (c Counter) GetValue() int  { return c.Count }     // Read
func (c *Counter) Increment()    { c.Count++ }           // Modify
```

---

## ৯. Structs ও Interfaces

### 🏗️ Structs

```go
// Definition
type User struct {
    ID        uint      `json:"id" gorm:"primaryKey"`
    Name      string    `json:"name" validate:"required,min=3"`
    Email     string    `json:"email" validate:"required,email"`
    Age       int       `json:"age" validate:"gte=0,lte=150"`
    Password  string    `json:"-"`               // JSON এ hide
    CreatedAt time.Time `json:"created_at"`
    DeletedAt gorm.DeletedAt `json:"-"`           // Soft delete
}

// Initialization
u1 := User{Name: "রহিম", Age: 25}
u2 := User{
    Name:  "করিম",
    Email: "karim@example.com",
    Age:   30,
}

// Pointer
u3 := &User{Name: "সেলিম"}

// Access
fmt.Println(u1.Name)
u1.Age = 26

// Anonymous struct
point := struct {
    X, Y int
}{X: 10, Y: 20}

// Embedded struct (composition)
type Address struct {
    City    string
    Country string
}

type Customer struct {
    User                    // Embedded
    Address                 // Embedded
    Phone string
}

c := Customer{
    User:    User{Name: "রহিম"},
    Address: Address{City: "ঢাকা", Country: "BD"},
    Phone:   "01700000000",
}
fmt.Println(c.Name)         // Promoted from User
fmt.Println(c.City)         // Promoted from Address
```

### 🔌 Interfaces

```go
// Definition
type Shape interface {
    Area() float64
    Perimeter() float64
}

// Implementation
type Rectangle struct {
    Width, Height float64
}

func (r Rectangle) Area() float64      { return r.Width * r.Height }
func (r Rectangle) Perimeter() float64 { return 2 * (r.Width + r.Height) }

type Circle struct {
    Radius float64
}

func (c Circle) Area() float64      { return 3.14 * c.Radius * c.Radius }
func (c Circle) Perimeter() float64 { return 2 * 3.14 * c.Radius }

// Usage
func describe(s Shape) {
    fmt.Printf("Area: %.2f, Perimeter: %.2f\n", s.Area(), s.Perimeter())
}

describe(Rectangle{10, 5})
describe(Circle{7})
```

### 🎯 Common Interfaces

```go
// error
type error interface {
    Error() string
}

// Stringer
type Stringer interface {
    String() string
}

// io.Reader
type Reader interface {
    Read(p []byte) (n int, err error)
}

// io.Writer
type Writer interface {
    Write(p []byte) (n int, err error)
}

// Empty interface (any)
var anything interface{}
var anything2 any           // Go 1.18+ alias
```

### ✅ Type Assertion

```go
var i interface{} = "hello"

// Safe assertion
s, ok := i.(string)
if ok {
    fmt.Println(s)
}

// Type switch
switch v := i.(type) {
case int:
    fmt.Println("int:", v)
case string:
    fmt.Println("string:", v)
default:
    fmt.Printf("unknown: %T\n", v)
}
```

---

## ১০. Error Handling

### 🎯 Basic Pattern

```go
import "errors"

func divide(a, b int) (int, error) {
    if b == 0 {
        return 0, errors.New("division by zero")
    }
    return a / b, nil
}

// Usage
result, err := divide(10, 0)
if err != nil {
    log.Fatal(err)
}
fmt.Println(result)
```

### 🔍 Sentinel Errors

```go
var (
    ErrNotFound    = errors.New("resource not found")
    ErrUnauthorized = errors.New("unauthorized")
    ErrDuplicate   = errors.New("duplicate entry")
)

func getUser(id int) (*User, error) {
    // ...
    return nil, ErrNotFound
}

// Check
if errors.Is(err, ErrNotFound) {
    // Handle
}
```

### 📝 Custom Errors

```go
type ValidationError struct {
    Field   string
    Message string
}

func (e *ValidationError) Error() string {
    return fmt.Sprintf("%s: %s", e.Field, e.Message)
}

// Usage
func validateUser(u User) error {
    if u.Name == "" {
        return &ValidationError{Field: "name", Message: "required"}
    }
    return nil
}
```

### 🔗 Error Wrapping

```go
import "fmt"

func processFile(path string) error {
    data, err := os.ReadFile(path)
    if err != nil {
        return fmt.Errorf("reading %s: %w", path, err)
    }
    // ...
    return nil
}

// Unwrap
err := processFile("missing.txt")
if errors.Is(err, os.ErrNotExist) {
    fmt.Println("File does not exist")
}

// Extract
var pathErr *os.PathError
if errors.As(err, &pathErr) {
    fmt.Println("Path:", pathErr.Path)
}
```

### ⚠️ Panic vs Error

| Error | Panic |
|-------|-------|
| Predictable | Unpredictable |
| Recoverable | Not recoverable |
| Return value | Stack unwinding |
| Business logic | Programming bugs |
| ✅ Always use | ❌ Only for fatal |

```go
// ❌ ভুল: error এর জন্য panic
func getUser(id int) *User {
    if id <= 0 {
        panic("invalid id")     // Bad!
    }
    return nil
}

// ✅ সঠিক
func getUser(id int) (*User, error) {
    if id <= 0 {
        return nil, errors.New("invalid id")
    }
    return nil, nil
}
```

---

## ১১. Concurrency

### 🧵 Goroutines

```go
// Basic
go func() {
    fmt.Println("Running in goroutine")
}()

// With function
func worker(id int) {
    fmt.Printf("Worker %d\n", id)
}
go worker(1)

// Wait for completion
var wg sync.WaitGroup
for i := 1; i <= 5; i++ {
    wg.Add(1)
    go func(id int) {
        defer wg.Done()
        fmt.Printf("Worker %d\n", id)
    }(i)
}
wg.Wait()
```

### 📢 Channels

```go
// Unbuffered channel
ch := make(chan int)
go func() { ch <- 42 }()
value := <-ch

// Buffered channel
ch := make(chan int, 10)
ch <- 1
ch <- 2
close(ch)

// Range over channel
for v := range ch {
    fmt.Println(v)
}

// Select (multiplexing)
select {
case msg := <-ch1:
    fmt.Println("From ch1:", msg)
case msg := <-ch2:
    fmt.Println("From ch2:", msg)
case <-time.After(time.Second):
    fmt.Println("Timeout")
default:
    fmt.Println("No channel ready")
}

// Directional channels
func send(ch chan<- int)    { ch <- 42 }
func receive(ch <-chan int) { <-ch }
```

### 🔒 Mutex

```go
import "sync"

type Counter struct {
    mu    sync.Mutex
    count int
}

func (c *Counter) Increment() {
    c.mu.Lock()
    defer c.mu.Unlock()
    c.count++
}

func (c *Counter) Value() int {
    c.mu.Lock()
    defer c.mu.Unlock()
    return c.count
}

// RWMutex — read heavy workloads
type Cache struct {
    mu   sync.RWMutex
    data map[string]string
}

func (c *Cache) Get(key string) string {
    c.mu.RLock()
    defer c.mu.RUnlock()
    return c.data[key]
}

func (c *Cache) Set(key, val string) {
    c.mu.Lock()
    defer c.mu.Unlock()
    c.data[key] = val
}
```

### 🎯 Context (Cancellation & Timeout)

```go
import "context"

// Timeout
ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
defer cancel()

select {
case result := <-doWork(ctx):
    fmt.Println(result)
case <-ctx.Done():
    fmt.Println("Timeout:", ctx.Err())
}

// Cancellation
ctx, cancel := context.WithCancel(context.Background())
go func() {
    time.Sleep(2 * time.Second)
    cancel()
}()

// Pass context through call chain
func fetchUser(ctx context.Context, id int) (*User, error) {
    select {
    case <-ctx.Done():
        return nil, ctx.Err()
    default:
        // Actual work
    }
    return nil, nil
}
```

### 🏗️ Worker Pool Pattern

```go
func workerPool(jobs <-chan int, results chan<- int, workers int) {
    var wg sync.WaitGroup
    
    for i := 0; i < workers; i++ {
        wg.Add(1)
        go func() {
            defer wg.Done()
            for job := range jobs {
                results <- job * 2
            }
        }()
    }
    
    go func() {
        wg.Wait()
        close(results)
    }()
}

func main() {
    jobs := make(chan int, 100)
    results := make(chan int, 100)
    
    go workerPool(jobs, results, 5)
    
    go func() {
        for i := 1; i <= 20; i++ {
            jobs <- i
        }
        close(jobs)
    }()
    
    for r := range results {
        fmt.Println(r)
    }
}
```

---

## ১২. Packages ও Modules

### 📦 Package Rules

```go
// package name = directory name
// file: internal/service/user_service.go
package service

// Exported (public) — Capital letter
func GetUser() {}

// Unexported (private) — lowercase
func getUser() {}

// Same package এ files একে অপরকে access করতে পারে
```

### 📁 Module Commands

```bash
# Initialize
go mod init github.com/user/project

# Add dependency
go get github.com/gin-gonic/gin@v1.9.1
go get -u github.com/gin-gonic/gin        # Latest

# Remove unused
go mod tidy

# Vendor
go mod vendor                             # Local copy in vendor/
go build -mod=vendor                      # Use vendor

# Replace (local development)
go mod edit -replace github.com/foo/bar=../bar
```

### 📝 go.mod Example

```go
module github.com/yourname/my-api

go 1.22

require (
    github.com/gin-gonic/gin v1.9.1
    github.com/golang-jwt/jwt/v5 v5.2.0
    gorm.io/gorm v1.25.5
    gorm.io/driver/mysql v1.5.2
)

require (
    // Indirect dependencies
    github.com/bytedance/sonic v1.10.2 // indirect
    // ...
)

replace github.com/old/pkg => github.com/new/pkg v1.0.0
```

---

## ১৩. Testing

### 🧪 Basic Test

```go
// calculator.go
package calc

func Add(a, b int) int { return a + b }

// calculator_test.go
package calc

import "testing"

func TestAdd(t *testing.T) {
    result := Add(2, 3)
    expected := 5
    if result != expected {
        t.Errorf("Add(2, 3) = %d; want %d", result, expected)
    }
}
```

### 📊 Table-Driven Tests

```go
func TestAdd(t *testing.T) {
    tests := []struct {
        name     string
        a, b     int
        expected int
    }{
        {"positive", 2, 3, 5},
        {"negative", -2, -3, -5},
        {"zero", 0, 5, 5},
        {"mixed", -2, 3, 1},
    }
    
    for _, tt := range tests {
        t.Run(tt.name, func(t *testing.T) {
            result := Add(tt.a, tt.b)
            if result != tt.expected {
                t.Errorf("Add(%d, %d) = %d; want %d",
                    tt.a, tt.b, result, tt.expected)
            }
        })
    }
}
```

### 🎭 Mocking with Interfaces

```go
// repository.go
type UserRepository interface {
    FindByID(id int) (*User, error)
}

// service.go
type UserService struct {
    repo UserRepository
}

func (s *UserService) GetUser(id int) (*User, error) {
    return s.repo.FindByID(id)
}

// user_service_test.go
type MockUserRepository struct {
    users map[int]*User
}

func (m *MockUserRepository) FindByID(id int) (*User, error) {
    u, ok := m.users[id]
    if !ok {
        return nil, errors.New("not found")
    }
    return u, nil
}

func TestGetUser(t *testing.T) {
    mock := &MockUserRepository{
        users: map[int]*User{
            1: {ID: 1, Name: "রহিম"},
        },
    }
    svc := &UserService{repo: mock}
    
    user, err := svc.GetUser(1)
    if err != nil {
        t.Fatal(err)
    }
    if user.Name != "রহিম" {
        t.Errorf("got %s, want রহিম", user.Name)
    }
}
```

### 🔧 Test Helpers

```go
func TestMain(m *testing.M) {
    // Setup (DB connection, etc.)
    setup()
    
    code := m.Run()
    
    // Teardown
    teardown()
    
    os.Exit(code)
}

// Helper function
func assertEqual(t *testing.T, got, want interface{}) {
    t.Helper()                        // Line number সঠিক দেখাবে
    if got != want {
        t.Errorf("got %v, want %v", got, want)
    }
}
```

### 📊 Coverage

```bash
go test -cover ./...
go test -coverprofile=coverage.out ./...
go tool cover -html=coverage.out
go tool cover -func=coverage.out
```

---

## ১৪. REST API Development

### 🚀 Gin Quick Start

```go
package main

import (
    "net/http"
    "github.com/gin-gonic/gin"
)

func main() {
    r := gin.Default()
    
    r.GET("/ping", func(c *gin.Context) {
        c.JSON(http.StatusOK, gin.H{"message": "pong"})
    })
    
    r.Run(":8080")
}
```

### 📋 CRUD Endpoints

```go
type UserHandler struct {
    service UserService
}

func (h *UserHandler) RegisterRoutes(r *gin.Engine) {
    g := r.Group("/api/v1/users")
    {
        g.POST("", h.Create)
        g.GET("", h.List)
        g.GET("/:id", h.GetByID)
        g.PUT("/:id", h.Update)
        g.DELETE("/:id", h.Delete)
    }
}

func (h *UserHandler) Create(c *gin.Context) {
    var req CreateUserRequest
    if err := c.ShouldBindJSON(&req); err != nil {
        c.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
        return
    }
    
    user, err := h.service.Create(c.Request.Context(), &req)
    if err != nil {
        c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
        return
    }
    
    c.JSON(http.StatusCreated, user)
}

func (h *UserHandler) GetByID(c *gin.Context) {
    id, err := strconv.Atoi(c.Param("id"))
    if err != nil {
        c.JSON(http.StatusBadRequest, gin.H{"error": "invalid id"})
        return
    }
    
    user, err := h.service.GetByID(c.Request.Context(), id)
    if err != nil {
        c.JSON(http.StatusNotFound, gin.H{"error": err.Error()})
        return
    }
    
    c.JSON(http.StatusOK, user)
}
```

### 📊 HTTP Status Codes

| Code | Meaning | ব্যবহার |
|------|---------|---------|
| 200 | OK | GET, PUT success |
| 201 | Created | POST success |
| 204 | No Content | DELETE success |
| 400 | Bad Request | Validation fail |
| 401 | Unauthorized | Missing/invalid token |
| 403 | Forbidden | No permission |
| 404 | Not Found | Resource নেই |
| 409 | Conflict | Duplicate |
| 422 | Unprocessable | Semantic error |
| 500 | Server Error | Internal error |
| 503 | Unavailable | Down for maintenance |

### ✅ Request Validation

```go
type CreateUserRequest struct {
    Name     string `json:"name" validate:"required,min=3,max=100"`
    Email    string `json:"email" validate:"required,email"`
    Password string `json:"password" validate:"required,min=8"`
    Age      int    `json:"age" validate:"gte=18,lte=120"`
}

// With validator v10
import "github.com/go-playground/validator/v10"

var validate = validator.New()

func (r *CreateUserRequest) Validate() error {
    return validate.Struct(r)
}
```

---

## ১৫. Database (MySQL + GORM)

### 🗄️ Connection

```go
import (
    "gorm.io/driver/mysql"
    "gorm.io/gorm"
    "gorm.io/gorm/logger"
)

func NewDB(dsn string) (*gorm.DB, error) {
    db, err := gorm.Open(mysql.Open(dsn), &gorm.Config{
        Logger: logger.Default.LogMode(logger.Info),
    })
    if err != nil {
        return nil, err
    }
    
    sqlDB, err := db.DB()
    if err != nil {
        return nil, err
    }
    
    // Connection pool
    sqlDB.SetMaxIdleConns(10)
    sqlDB.SetMaxOpenConns(100)
    sqlDB.SetConnMaxLifetime(time.Hour)
    
    return db, nil
}

// DSN format:
// user:password@tcp(host:port)/dbname?charset=utf8mb4&parseTime=True&loc=Local
```

### 📊 Models

```go
type User struct {
    ID        uint           `gorm:"primaryKey" json:"id"`
    Name      string         `gorm:"size:100;not null" json:"name"`
    Email     string         `gorm:"uniqueIndex;size:255;not null" json:"email"`
    Password  string         `gorm:"size:255;not null" json:"-"`
    Age       int            `gorm:"default:0" json:"age"`
    RoleID    uint           `gorm:"index" json:"role_id"`
    Role      Role           `gorm:"foreignKey:RoleID" json:"role,omitempty"`
    Orders    []Order        `gorm:"foreignKey:UserID" json:"orders,omitempty"`
    CreatedAt time.Time      `json:"created_at"`
    UpdatedAt time.Time      `json:"updated_at"`
    DeletedAt gorm.DeletedAt `gorm:"index" json:"-"`
}

func (User) TableName() string { return "users" }
```

### 🔄 CRUD Operations

```go
// Create
user := &User{Name: "রহিম", Email: "rahim@example.com"}
result := db.Create(user)
if result.Error != nil {
    return result.Error
}
fmt.Println("ID:", user.ID)

// Read
var user User
db.First(&user, 1)                     // by primary key
db.First(&user, "email = ?", "rahim@example.com")

var users []User
db.Where("age > ?", 18).Find(&users)

// Update
db.Model(&user).Update("name", "করিম")
db.Model(&user).Updates(User{Name: "করিম", Age: 30})
db.Model(&User{}).Where("age < ?", 18).Update("status", "minor")

// Delete (soft delete)
db.Delete(&user, 1)

// Hard delete
db.Unscoped().Delete(&user, 1)

// Transactions
err := db.Transaction(func(tx *gorm.DB) error {
    if err := tx.Create(&user).Error; err != nil {
        return err
    }
    if err := tx.Create(&order).Error; err != nil {
        return err
    }
    return nil
})
```

### 🔗 Relationships

```go
// One-to-One
type User struct {
    ID      uint
    Profile Profile
}
type Profile struct {
    ID     uint
    UserID uint
    Bio    string
}

// One-to-Many
type User struct {
    ID     uint
    Orders []Order
}
type Order struct {
    ID     uint
    UserID uint
    Total  float64
}

// Many-to-Many
type Product struct {
    ID       uint
    Name     string
    Tags     []Tag `gorm:"many2many:product_tags"`
}
type Tag struct {
    ID       uint
    Name     string
    Products []Product `gorm:"many2many:product_tags"`
}

// Eager loading
db.Preload("Orders").Find(&users)
db.Preload("Orders.Items").Find(&users)
db.Joins("Role").Find(&users)
```

### 📈 Pagination

```go
func Paginate(page, size int) func(db *gorm.DB) *gorm.DB {
    return func(db *gorm.DB) *gorm.DB {
        if page <= 0 { page = 1 }
        if size <= 0 || size > 100 { size = 10 }
        offset := (page - 1) * size
        return db.Offset(offset).Limit(size)
    }
}

// Usage
var users []User
var total int64

db.Model(&User{}).Count(&total)
db.Scopes(Paginate(2, 10)).Find(&users)

// Response
type PaginatedResponse struct {
    Data       interface{} `json:"data"`
    Total      int64       `json:"total"`
    Page       int         `json:"page"`
    PageSize   int         `json:"page_size"`
    TotalPages int         `json:"total_pages"`
}
```

---

## ১৬. JWT Authentication

### 🎫 JWT Structure

```
Header.Payload.Signature

eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.
eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IlJhaGltIiwiaWF0IjoxNTE2MjM5MDIyfQ.
SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c
```

### 🔐 Generate Token

```go
import "github.com/golang-jwt/jwt/v5"

type Claims struct {
    UserID uint   `json:"user_id"`
    Email  string `json:"email"`
    Role   string `json:"role"`
    jwt.RegisteredClaims
}

func GenerateToken(user *User, secret string, duration time.Duration) (string, error) {
    claims := Claims{
        UserID: user.ID,
        Email:  user.Email,
        Role:   user.Role.Name,
        RegisteredClaims: jwt.RegisteredClaims{
            ExpiresAt: jwt.NewNumericDate(time.Now().Add(duration)),
            IssuedAt:  jwt.NewNumericDate(time.Now()),
            Issuer:    "my-api",
            Subject:   strconv.FormatUint(uint64(user.ID), 10),
        },
    }
    
    token := jwt.NewWithClaims(jwt.SigningMethodHS256, claims)
    return token.SignedString([]byte(secret))
}
```

### 🔍 Validate Token

```go
func ValidateToken(tokenString, secret string) (*Claims, error) {
    token, err := jwt.ParseWithClaims(
        tokenString,
        &Claims{},
        func(t *jwt.Token) (interface{}, error) {
            if _, ok := t.Method.(*jwt.SigningMethodHMAC); !ok {
                return nil, fmt.Errorf("unexpected signing method: %v", t.Header["alg"])
            }
            return []byte(secret), nil
        },
    )
    if err != nil {
        return nil, err
    }
    
    claims, ok := token.Claims.(*Claims)
    if !ok || !token.Valid {
        return nil, errors.New("invalid token")
    }
    
    return claims, nil
}
```

### 🛡️ Middleware

```go
func AuthMiddleware(secret string) gin.HandlerFunc {
    return func(c *gin.Context) {
        authHeader := c.GetHeader("Authorization")
        if authHeader == "" {
            c.AbortWithStatusJSON(http.StatusUnauthorized, gin.H{
                "error": "missing authorization header",
            })
            return
        }
        
        parts := strings.SplitN(authHeader, " ", 2)
        if len(parts) != 2 || parts[0] != "Bearer" {
            c.AbortWithStatusJSON(http.StatusUnauthorized, gin.H{
                "error": "invalid authorization header",
            })
            return
        }
        
        claims, err := ValidateToken(parts[1], secret)
        if err != nil {
            c.AbortWithStatusJSON(http.StatusUnauthorized, gin.H{
                "error": err.Error(),
            })
            return
        }
        
        c.Set("user_id", claims.UserID)
        c.Set("email", claims.Email)
        c.Set("role", claims.Role)
        c.Next()
    }
}

// Role-based
func RequireRole(roles ...string) gin.HandlerFunc {
    return func(c *gin.Context) {
        role, exists := c.Get("role")
        if !exists {
            c.AbortWithStatusJSON(http.StatusForbidden, gin.H{
                "error": "role not found",
            })
            return
        }
        
        for _, r := range roles {
            if role == r {
                c.Next()
                return
            }
        }
        
        c.AbortWithStatusJSON(http.StatusForbidden, gin.H{
            "error": "insufficient permissions",
        })
    }
}

// Usage
api := r.Group("/api/v1")
api.Use(AuthMiddleware(cfg.JWTSecret))
{
    api.GET("/profile", getProfile)
    
    admin := api.Group("/admin")
    admin.Use(RequireRole("admin"))
    {
        admin.DELETE("/users/:id", deleteUser)
    }
}
```

---

## ১৭. Docker

### 📄 Multi-Stage Dockerfile

```dockerfile
# ============ Builder ============
FROM golang:1.22-alpine AS builder

WORKDIR /build

# Dependencies (cache layer)
COPY go.mod go.sum ./
RUN go mod download && go mod verify

# Source
COPY . .

# Build
ARG VERSION=dev
ARG BUILD_TIME=unknown
RUN CGO_ENABLED=0 GOOS=linux go build \
    -trimpath \
    -ldflags="-s -w -X main.Version=${VERSION} -X main.BuildTime=${BUILD_TIME}" \
    -o /build/app \
    ./cmd/api

# ============ Runtime ============
FROM gcr.io/distroless/static-debian12:nonroot

COPY --from=builder /build/app /app

USER nonroot:nonroot
EXPOSE 8080
ENTRYPOINT ["/app"]
```

### 🐳 docker-compose.yml

```yaml
version: '3.9'

services:
  api:
    build:
      context: .
      dockerfile: deployments/Dockerfile
    ports:
      - "8080:8080"
    environment:
      - DB_HOST=mysql
      - DB_PORT=3306
      - DB_USER=app
      - DB_PASSWORD=secret
      - DB_NAME=myapp
      - JWT_SECRET=super-secret
    depends_on:
      mysql:
        condition: service_healthy
    networks:
      - app-network

  mysql:
    image: mysql:8.0
    environment:
      MYSQL_ROOT_PASSWORD: rootpass
      MYSQL_DATABASE: myapp
      MYSQL_USER: app
      MYSQL_PASSWORD: secret
    ports:
      - "3306:3306"
    volumes:
      - mysql-data:/var/lib/mysql
      - ./migrations:/docker-entrypoint-initdb.d
    healthcheck:
      test: ["CMD", "mysqladmin", "ping", "-h", "localhost"]
      interval: 10s
      timeout: 5s
      retries: 5
    networks:
      - app-network

volumes:
  mysql-data:

networks:
  app-network:
    driver: bridge
```

### 📋 Docker Commands

```bash
# Build
docker build -t my-api:latest .
docker build -t my-api:1.0.0 -f deployments/Dockerfile .

# Run
docker run -d -p 8080:8080 --name api my-api:latest
docker run --rm -it my-api:latest sh

# Compose
docker-compose up -d
docker-compose logs -f api
docker-compose down
docker-compose down -v           # With volumes

# Cleanup
docker system prune -a
docker volume prune
```

### 🌐 Container Networking

```
┌────────────────────────────────────────┐
│  Docker Host                            │
│                                         │
│  ┌──────────────────────────────────┐  │
│  │  app-network (bridge)             │  │
│  │                                    │  │
│  │  ┌──────────┐    ┌──────────┐    │  │
│  │  │   api    │───▶│  mysql   │    │  │
│  │  │ :8080    │    │ :3306    │    │  │
│  │  └──────────┘    └──────────┘    │  │
│  │       │                            │  │
│  └───────┼────────────────────────────┘  │
│          │                                │
│          ▼ Port mapping                  │
│      localhost:8080                       │
└────────────────────────────────────────┘

Note: Same network এ containers একে অপরকে 
service name দিয়ে access করে (e.g., mysql:3306)
```

---

## ১৮. Production Best Practices

### ✅ Checklist

**Code Quality:**
- [ ] `gofmt -s -w .` সব commit এর আগে
- [ ] `go vet ./...` CI তে
- [ ] `golangci-lint run` CI তে
- [ ] Test coverage > 70%
- [ ] No `panic` in production code (except init)
- [ ] Errors wrap করা `%w` দিয়ে

**Security:**
- [ ] Environment variables `.env` এ (git ignore)
- [ ] Secrets কখনো code এ নয়
- [ ] SQL injection থেকে সাবধান (prepared statements)
- [ ] Input validation সব endpoint এ
- [ ] Rate limiting critical endpoints এ
- [ ] HTTPS only production এ
- [ ] Password bcrypt/argon2 দিয়ে hash
- [ ] JWT secret strong (32+ bytes)

**Performance:**
- [ ] Database indexes সঠিক জায়গায়
- [ ] Connection pool configured
- [ ] N+1 query এড়িয়ে চলুন
- [ ] Context propagation সব জায়গায়
- [ ] Graceful shutdown implement
- [ ] Health check endpoints (`/health`, `/ready`)
- [ ] Timeouts সব external calls এ

**Observability:**
- [ ] Structured logging (JSON)
- [ ] Request ID tracing
- [ ] Metrics (Prometheus)
- [ ] Distributed tracing (optional)

**Deployment:**
- [ ] Multi-stage Docker build
- [ ] Non-root user
- [ ] Read-only filesystem (possible হলে)
- [ ] Resource limits (CPU, memory)
- [ ] Liveness/Readiness probes

### 🎯 Graceful Shutdown

```go
func main() {
    srv := &http.Server{
        Addr:    ":8080",
        Handler: router,
    }
    
    go func() {
        if err := srv.ListenAndServe(); err != nil && err != http.ErrServerClosed {
            log.Fatalf("listen: %s\n", err)
        }
    }()
    
    quit := make(chan os.Signal, 1)
    signal.Notify(quit, syscall.SIGINT, syscall.SIGTERM)
    <-quit
    log.Println("Shutting down server...")
    
    ctx, cancel := context.WithTimeout(context.Background(), 30*time.Second)
    defer cancel()
    
    if err := srv.Shutdown(ctx); err != nil {
        log.Fatal("Server forced to shutdown:", err)
    }
    
    log.Println("Server exited")
}
```

### 📊 Structured Logging

```go
import "log/slog"

logger := slog.New(slog.NewJSONHandler(os.Stdout, nil))

logger.Info("user created",
    "user_id", user.ID,
    "email", user.Email,
    "ip", c.ClientIP(),
)

logger.Error("database error",
    "error", err,
    "query", "SELECT * FROM users",
)
```

---

## ১৯. Common Errors ও Solutions

| Error | কারণ | Solution |
|-------|------|----------|
| `cannot find package` | Module not initialized | `go mod init` + `go mod tidy` |
| `undefined: X` | Typo / not imported | Check import |
| `declared and not used` | Unused variable | Use `_` or remove |
| `imported and not used` | Unused import | Remove or `_` |
| `cannot use X (type Y) as type Z` | Type mismatch | Type conversion |
| `nil pointer dereference` | Nil pointer | Nil check |
| `too many open files` | File/conn leak | `defer file.Close()` |
| `context deadline exceeded` | Timeout | Increase timeout or optimize |
| `no required module provides package` | Missing dependency | `go get <package>` |
| `mixed named and unnamed parameters` | Function signature | Fix signature |
| `syntax error: unexpected newline` | Missing operator/brace | Check syntax |
| `duplicate case in switch` | Same case twice | Remove duplicate |
| `cannot take address of ...` | Non-addressable | Assign to variable first |

### 🐛 Common Go Pitfalls

```go
// ❌ Bug 1: Loop variable capture (Go <1.22)
for i := 0; i < 3; i++ {
    go func() { fmt.Println(i) }()   // সবগুলো 3 print করতে পারে
}

// ✅ Fix
for i := 0; i < 3; i++ {
    i := i                            // Shadow
    go func() { fmt.Println(i) }()
}
// অথবা Go 1.22+ এ automatic fix

// ❌ Bug 2: Slice append sharing
a := []int{1, 2, 3}
b := a[:2]
b = append(b, 99)                     // a[2] ও 99 হয়ে যাবে!
fmt.Println(a)                        // [1 2 99]

// ✅ Fix: Copy
b := make([]int, 2)
copy(b, a[:2])
b = append(b, 99)

// ❌ Bug 3: Defer in loop
for _, f := range files {
    file, _ := os.Open(f)
    defer file.Close()                // শেষ পর্যন্ত খোলা থাকবে
}

// ✅ Fix: Closure or separate function
for _, f := range files {
    func() {
        file, _ := os.Open(f)
        defer file.Close()
        // ...
    }()
}

// ❌ Bug 4: Nil map write
var m map[string]int
m["key"] = 1                          // Panic!

// ✅ Fix: make
m := make(map[string]int)
m["key"] = 1
```

---

## ২০. Debugging Techniques

### 🖨️ Print Debugging

```go
import "log"

log.Printf("user: %+v", user)         // Struct details
log.Printf("pointer: %p", &user)      // Address
log.Printf("type: %T", i)             // Type

// Pretty print
import "encoding/json"
b, _ := json.MarshalIndent(user, "", "  ")
fmt.Println(string(b))
```

### 🔍 Delve Debugger

```bash
# Install
go install github.com/go-delve/delve/cmd/dlv@latest

# Debug
dlv debug main.go

# Inside dlv:
# (dlv) break main.main
# (dlv) continue
# (dlv) next
# (dlv) step
# (dlv) print variableName
# (dlv) goroutines
# (dlv) exit
```

### 🏁 Race Detector

```bash
go run -race main.go
go test -race ./...
go build -race -o app main.go
```

### 📊 Profiling

```go
import (
    "net/http"
    _ "net/http/pprof"        // Side-effect import
)

func main() {
    go func() {
        http.ListenAndServe("localhost:6060", nil)
    }()
    // Your app
}
```

```bash
# CPU profile
go tool pprof http://localhost:6060/debug/pprof/profile?seconds=30

# Memory
go tool pprof http://localhost:6060/debug/pprof/heap

# Goroutines
go tool pprof http://localhost:6060/debug/pprof/goroutine

# In pprof:
# (pprof) top
# (pprof) list functionName
# (pprof) web                    # Requires graphviz
```

### 📝 Benchmarking

```go
func BenchmarkAdd(b *testing.B) {
    for i := 0; i < b.N; i++ {
        Add(2, 3)
    }
}

// Run
// go test -bench=. -benchmem
// go test -bench=BenchmarkAdd -count=5
// go test -bench=. -cpuprofile=cpu.prof
```

---

## ২১. Useful Resources

### 📚 Official

- [Go Official Site](https://go.dev/)
- [Go Documentation](https://go.dev/doc/)
- [Effective Go](https://go.dev/doc/effective_go)
- [Go Playground](https://go.dev/play/)
- [Go Blog](https://go.dev/blog/)
- [Go by Example](https://gobyexample.com/)

### 🎓 Learning

- [Tour of Go](https://go.dev/tour/)
- [Learn Go with Tests](https://quii.gitbook.io/learn-go-with-tests)
- [Go Bootcamp](https://www.golangbootcamp.com/)
- [Awesome Go](https://github.com/avelino/awesome-go)

### 🛠️ Essential Libraries

| Purpose | Library |
|---------|---------|
| Web Framework | `github.com/gin-gonic/gin` |
| ORM | `gorm.io/gorm` |
| JWT | `github.com/golang-jwt/jwt/v5` |
| Validation | `github.com/go-playground/validator/v10` |
| Config | `github.com/spf13/viper` |
| Logging | `log/slog`, `go.uber.org/zap` |
| Testing | `github.com/stretchr/testify` |
| Mocking | `github.com/golang/mock` |
| Migration | `github.com/golang-migrate/migrate` |
| Redis | `github.com/redis/go-redis/v9` |
| Scheduler | `github.com/robfig/cron/v3` |
| Swagger | `github.com/swaggo/swag` |

### 📖 Books

- **The Go Programming Language** — Donovan & Kernighan
- **Go in Action** — William Kennedy
- **Concurrency in Go** — Katherine Cox-Buday
- **100 Go Mistakes** — Teiva Harsanyi
- **Learning Go** — Jon Bodner

---

## 🎯 Quick Reference Card

```
📌 Essentials
────────────────────────────────────────────
Declaration   : var x int = 5   |   x := 5
Constant      : const PI = 3.14
Slice         : s := []int{1, 2, 3}
Map           : m := map[string]int{"a": 1}
Struct        : type U struct { Name string }
Interface     : type I interface { Do() }
Error         : if err != nil { return err }
Goroutine     : go fn()
Channel       : ch := make(chan int)
Mutex         : var mu sync.Mutex; mu.Lock()
Context       : ctx, cancel := context.WithTimeout(...)
Defer         : defer file.Close()
Test          : func TestX(t *testing.T) { ... }
────────────────────────────────────────────

⚡ Commands
────────────────────────────────────────────
Init          : go mod init <path>
Run           : go run .
Build         : go build -o app .
Test          : go test ./...
Coverage      : go test -cover ./...
Format        : gofmt -w .
Vet           : go vet ./...
Tidy          : go mod tidy
Cross-build   : GOOS=linux GOARCH=amd64 go build
────────────────────────────────────────────
```

---

## 🤝 Contributing

এই README.md কে improve করতে চাইলে:
1. Fork করুন
2. Feature branch তৈরি করুন
3. Commit করুন
4. Push করুন
5. Pull Request পাঠান

---

## 📄 License

MIT License — freely use, modify, and share.

---

## 👨‍💻 Author

**Your Name**  
Senior Golang Engineer | Backend Architect  
📧 your.email@example.com  
🔗 [GitHub](https://github.com/yourname)

---

## ⭐ Support

এই README কাজে লাগলে ⭐ **star** দিতে ভুলবেন না!

> **"Talk is cheap. Show me the code."** — Linus Torvalds

---

**Happy Coding! 🚀🐹**
```

---

## 📝 এই README.md কীভাবে ব্যবহার করবেন?

### 🎯 Development এর সময়:
1. **Quick Reference** — Section 4 (Commands), Section 5-9 (Syntax)
2. **Error পড়লে** — Section 19 (Common Errors)
3. **Bug ধরতে** — Section 20 (Debugging)

### 📚 শেখার সময়:
1. Sequential পড়ুন Section 1 → 21
2. প্রতিটি Section এর code নিজে লিখুন
3. Exercise নিজে করুন

### 🚀 Project Setup এ:
1. Section 3 (Project Structure) follow করুন
2. Section 4 (Makefile) কপি করুন
3. Section 17 (Docker) দিয়ে deploy করুন

### 🎨 Team এ শেয়ার করতে:
1. README.md কে project root এ রাখুন
2. Team members কে reference হিসেবে বলুন
3. Project specific info যোগ করুন

---

> 💡 **Pro Tip:** এই README.md কে `docs/` folder এ রাখুন এবং `Makefile` এ একটি `make help` command যোগ করুন যা এই documentation এর path দেখাবে।

**আরো specific কিছু চাইলে বলুন** — যেমন: خاص framework এর detail, specific pattern এর example, বা আপনার project specific customization! 🚀