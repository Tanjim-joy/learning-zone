# Docker সম্পূর্ণ টিউটোরিয়াল - বিগেনার থেকে এডভান্স

> **শেষ আপডেট**: ২০২৬ | **সংস্করণ**: ৩.০
> এই টিউটোরিয়ালে Docker এর প্রতিটি বিষয় বিস্তারিতভাবে শেখানো হয়েছে।

---

## 📚 সূচিপত্র
1. [Docker এর পরিচয়](#অধ্যায়-১-docker-এর-পরিচয়)
2. [ইনস্টলেশন](#অধ্যায়-२-docker-installation)
3. [মূল ধারণা](#অধ্যায়-३-docker-এর-মূল-concepts)
4. [বেসিক কমান্ড](#অধ্যায়-४-basic-docker-commands)
5. [Dockerfile তৈরি](#অধ্যায়-५-dockerfile-তৈরি)
6. [Docker Compose](#অধ্যায়-६-docker-compose)
7. [Volumes এবং Storage](#অধ্যায়-७-docker-volumes)
8. [নেটওয়ার্কিং](#অধ্যায়-८-docker-networking)
9. [এডভান্স বিষয়](#অধ্যায়-०९-advanced-topics)
10. [প্রোডাকশন সেটআপ](#অধ্যায়-१०-production)

---

## অধ্যায় 1: Docker এর পরিচয়

### Docker কী?

**Docker** হলো একটি শক্তিশালী containerization প্ল্যাটফর্ম যা আপনার অ্যাপ্লিকেশনকে একটি lightweight container-এ প্যাকেজ করে। Container-এ আপনার অ্যাপ্লিকেশন, সব dependencies, libraries, এবং configuration একসাথে থাকে। এর ফলে অ্যাপ্লিকেশনটি যেকোনো পরিবেশে (development, testing, production) একইভাবে কাজ করে।

### Docker ব্যবহার করার প্রধান কারণ

| সুবিধা | বর্ণনা |
|--------|---------|
| **Portability** | যেকোনো সিস্টেমে একই রকম চলে (Windows, Linux, Mac) |
| **Consistency** | Development থেকে Production পর্যন্ত একই পরিবেশ |
| **Isolation** | প্রতিটি container সম্পূর্ণ আলাদা পরিবেশে চলে |
| **Lightweight** | VM এর তুলনায় অনেক কম রিসোর্স ব্যবহার করে |
| **Fast Startup** | মাত্র কয়েক সেকেন্ডে container চালু হয় |
| **Version Control** | সহজে বিভিন্ন version manage করা যায় |

### Container vs Virtual Machine

```
VM (Fat):
┌─────────────────────────────────────┐
│   Guest OS (বড়, ধীর)              │
│   Application                       │
│   Hypervisor                        │
│   Host OS + Hardware                │
└─────────────────────────────────────┘
Size: 1-5 GB | Start Time: Minutes

Container (Light):
┌─────────────────────────────────────┐
│   Application (ছোট, দ্রুত)         │
│   Docker Engine                     │
│   Host OS Kernel + Hardware         │
└─────────────────────────────────────┘
Size: 10-100 MB | Start Time: Seconds
```

### Docker এর মূল উপাদান

1. **Docker Client**: আপনি যা commands দিবেন
2. **Docker Server (Engine)**: Backend যা চলে
3. **Image**: Blueprint/Template
4. **Container**: চলমান instance
5. **Registry**: Image repository (Docker Hub)
6. **Volume**: Data storage
7. **Network**: Container communication

---

## অধ্যায় 2: Docker Installation

### Windows এ ইনস্টলেশন (প্রস্তাবিত: WSL 2)

**প্রয়োজনীয়তা:**
- Windows 10 Pro/Enterprise বা Windows 11
- কমপক্ষে 4 GB RAM
- Virtualization enabled

**ধাপ:**
```powershell
# 1. PowerShell (Admin) চালান
# 2. Docker Desktop ডাউনলোড করুন:
# https://www.docker.com/products/docker-desktop
# 3. WSL 2 সেটআপ (অপশনাল কিন্তু সুপারিশকৃত)
wsl --install -d Ubuntu
wsl --update
# 4. যাচাই করুন
docker --version
docker run hello-world
```

### Linux (Ubuntu) এ ইনস্টলেশন ✅

এটি সবচেয়ে প্রচলিত এবং দ্রুত।

```bash
#!/bin/bash
# সম্পূর্ণ ইনস্টলেশন স্ক্রিপ্ট

# 1. পুরাতন ভার্সন আনইনস্টল
sudo apt-get remove docker docker-engine docker.io -y

# 2. Dependencies ইনস্টল করুন
sudo apt-get update
sudo apt-get install -y ca-certificates curl gnupg lsb-release

# 3. Docker GPG key যোগ করুন
sudo mkdir -p /etc/apt/keyrings
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | \
  sudo gpg --dearmor -o /etc/apt/keyrings/docker.gpg

# 4. Repository সেটআপ করুন
echo "deb [arch=$(dpkg --print-architecture) \
  signed-by=/etc/apt/keyrings/docker.gpg] \
  https://download.docker.com/linux/ubuntu \
  $(lsb_release -cs) stable" | \
  sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# 5. Docker Engine ইনস্টল করুন
sudo apt-get update
sudo apt-get install -y docker-ce docker-ce-cli containerd.io docker-compose-plugin

# 6. Non-root ব্যবহারকারী হিসেবে চালার অনুমতি দিন
sudo usermod -aG docker $USER
newgrp docker

# 7. যাচাই করুন
docker --version
docker run hello-world
```

### macOS এ ইনস্টলেশন

```bash
# Homebrew ব্যবহার করে
brew install docker

# বা Docker Desktop ডাউনলোড করুন:
# https://www.docker.com/products/docker-desktop

# যাচাই করুন
docker --version
```

---

## অধ্যায় 3: Docker এর মূল Concepts

### ১. Image (ব্লুপ্রিন্ট)

Image হলো একটি read-only template যা থেকে Container তৈরি হয়।

```
Image = একটি পরিকল্পনা/নকশা
Container = সেই পরিকল্পনা থেকে তৈরি বাস্তব জিনিস
```

**Image এ কী থাকে:**
- Base OS (Ubuntu, Alpine, etc.)
- Runtime (Python, Node.js, etc.)
- Libraries এবং Dependencies
- Application Code
- Configuration Files

**উদাহরণ:**
```bash
# Docker Hub থেকে image pull করুন
docker pull ubuntu:20.04
docker pull python:3.9-slim
docker pull nginx:latest
```

### 4. Container (চলমান প্রক্রিয়া)

Container হলো Image এর একটি runtime instance।

```bash
# একটি container চালান
docker run -d -p 8080:80 --name webserver nginx

# ব্যাখ্যা:
# -d = detached mode (পটভূমিতে চলবে)
# -p 8080:80 = port mapping (Local:Container)
# --name = container এর নাম
# nginx = image নাম
```

### 5. Dockerfile (Image তৈরির নির্দেশ)

Dockerfile একটি টেক্সট ফাইল যাতে Image তৈরির ধাপে ধাপে নির্দেশনা থাকে।

```dockerfile
# বেসিক উদাহরণ
FROM python:3.9-slim           # Base image
WORKDIR /app                   # কাজের ডিরেক্টরি
COPY requirements.txt .        # File কপি করুন
RUN pip install -r requirements.txt  # Dependencies ইনস্টল করুন
COPY . .                       # সোর্স কোড কপি করুন
EXPOSE 5000                    # Port expose করুন
CMD ["python", "app.py"]       # Default command
```

### 6. Docker Registry (Image repository)

Docker Registry হলো Image সংগ্রহ করার কেন্দ্রীয় জায়গা।

**প্রধান Registries:**
- **Docker Hub** (সবচেয়ে জনপ্রিয়) - https://hub.docker.com
- **GitHub Container Registry**
- **Amazon ECR** (AWS)
- **Google Container Registry** (GCP)
- **Azure Container Registry** (Azure)

### 7. Volume (স্থায়ী data storage)

Problem: Container delete হলে সব ডেটা হারিয়ে যায়
Solution: Volume ব্যবহার করুন

```bash
# Named volume তৈরি করুন
docker volume create mydata

# Container এ mount করুন
docker run -v mydata:/data nginx

# Host directory mount করুন (Bind mount)
docker run -v /home/user/data:/data nginx
```

### 8. Network (Container যোগাযোগ)

Docker Network container গুলোকে একে অপরের সাথে যোগাযোগ করতে দেয়।

```bash
# Custom bridge network তৈরি করুন
docker network create mynet

# Container এ যুক্ত করুন
docker run --network mynet myapp
```

---

## অধ্যায় 9: Basic Docker Commands

### Image সম্পর্কিত কমান্ড

```bash
# ███████ Search এবং Download ███████
docker search nginx              # Docker Hub এ খোঁজ করুন
docker pull ubuntu:20.04         # Image download করুন
docker pull nginx:latest

# ███████ Image list করুন ███████
docker images                    # সব images দেখুন
docker images -a                 # Hidden images সহ
docker image ls

# ███████ Image তথ্য ███████
docker inspect nginx:latest      # বিস্তারিত তথ্য
docker history myapp:1.0         # Layer history দেখুন
docker image ls --format "{{.Repository}}:{{.Tag}} - {{.Size}}"

# ███████ Image পরিচালনা ███████
docker tag nginx:latest myapp:1.0   # Image rename করুন
docker rmi nginx:latest              # Image delete করুন
docker rmi -f nginx:latest           # Force delete
docker image prune                   # Unused images delete করুন
```

### Container সম্পর্কিত কমান্ড

```bash
# ███████ Container চালানো ███████
docker run ubuntu:20.04 echo "Hello"     # একবার চালান
docker run -d nginx                      # Detached mode
docker run -it ubuntu:20.04 bash         # Interactive shell
docker run --name myapp -d nginx         # নাম সহ চালান
docker run -p 8080:80 nginx              # Port mapping
docker run -e DATABASE_URL=... myapp     # Environment variable
docker run -v mydata:/data nginx         # Volume mount করুন
docker run --cpus="1.5" --memory="512m" myapp  # Resource limits

# ███████ Container list করুন ███████
docker ps                        # চলমান containers
docker ps -a                     # সব containers (চলমান + বন্ধ)
docker ps -n 5                   # Last 5 containers
docker ps -q                     # শুধু IDs

# ███████ Container তথ্য ███████
docker inspect container_name    # বিস্তারিত তথ্য
docker logs container_name       # Logs দেখুন
docker logs -f container_name    # Real-time logs (Ctrl+C থেমে)
docker logs --tail 50 container_name  # Last 50 lines

# ███████ Container নিয়ন্ত্রণ ███████
docker stop container_name       # Graceful stop
docker kill container_name       # Force stop
docker start container_name      # Restart (stopped থেকে)
docker restart container_name    # Restart (যাই থাকুক)
docker pause container_name      # Pause করুন
docker unpause container_name    # Resume করুন
docker rm container_name         # Delete করুন
docker rm -f container_name      # Force delete

# ███████ Container এ Command চালান ███████
docker exec container_name ls    # সাধারণ command
docker exec -it container_name bash  # Interactive shell
docker exec -u root container_name apt-get update  # Root হিসেবে
docker exec container_name curl http://localhost  # Curl test

# ███████ File Copy করুন ███████
docker cp container:/app/file.txt ./    # Container থেকে copy
docker cp ./file.txt container:/app/    # Container এ copy

# ███████ Cleanup ███████
docker container prune           # চলমান নয় এমন delete করুন
docker system prune -a           # সব unused resources delete
docker system df                 # Disk usage দেখুন
```

### System কমান্ড

```bash
docker --version                # Docker version
docker system info              # সিস্টেম তথ্য
docker stats                    # CPU, Memory usage (real-time)
docker events                   # Real-time events
docker system df                # Disk usage breakdown
```

---

## অধ্যায় 10: Dockerfile তৈরি

### পূর্ণ উদাহরণ

```dockerfile
# ╔═══════════════════════════════════════════════════════╗
# ║         Production-ready Dockerfile                    ║
# ╚═══════════════════════════════════════════════════════╝

FROM python:3.9-slim              # Step १: Base Image (Alpine ব্যবহার করুন - ছোট)

LABEL maintainer="you@example.com"  # মেটাডেটা
LABEL version="1.0"

ENV APP_HOME=/app \               # Step २: Environment Variables সেট করুন
    PYTHONUNBUFFERED=1 \
    PORT=5000

WORKDIR $APP_HOME                 # Step ३: কাজের ডিরেক্টরি

# Step 4: System dependencies (কম করে রাখুন)
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    curl \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*

# Step 5: Application dependencies (আলাদা layer - caching এর জন্য)
COPY requirements.txt .
RUN pip install --no-cache-dir -r requirements.txt

# Step 6: Application code (এটি সবচেয়ে পরে করুন)
COPY . .

# Step 7: Non-root user (Security)
RUN useradd -m -u 1000 appuser && \
    chown -R appuser:appuser $APP_HOME
USER appuser

# Step 8: Port এবং Health Check
EXPOSE $PORT
HEALTHCHECK --interval=30s --timeout=3s --start-period=5s \
    CMD curl -f http://localhost:$PORT/health || exit 1

# Step 9: Entry point এবং Default command
ENTRYPOINT ["python"]
CMD ["app.py"]
```

### Dockerfile Instructions ফুল রেফারেন্স

```dockerfile
# FROM: বাধ্যতামূলক, প্রথম থাকতে হবে
FROM python:3.9-slim
FROM node:16-alpine
FROM ubuntu:20.04
# টিপ: Alpine ব্যবহার করুন - ৫-৮ গুণ ছোট!

# LABEL: মেটাডেটা (optional)
LABEL maintainer="your@email.com"
LABEL version="1.0.0"
LABEL description="My Docker application"

# ENV: Environment variables সেট করুন
ENV DATABASE_URL=postgres://localhost \
    DEBUG=False \
    PORT=8000

# WORKDIR: কাজের ডিরেক্টরি (cd এর মতো)
WORKDIR /app
# এখন সব command /app এ চলবে

# COPY: Host থেকে Image এ copy করুন
COPY requirements.txt .     # Single file
COPY . .                    # সব files

# ADD: COPY এর মতো, কিন্তু URL এবং tar support করে
ADD https://example.com/app.tar.gz /tmp/
ADD app.tar.gz /app/

# RUN: Build time এ command চালান (Image তৈরির সময়)
RUN apt-get update && apt-get install -y curl    # Single RUN
RUN pip install -r requirements.txt

# ভাল practice: একটি RUN এ সব কিছু (layer কমায়)
RUN apt-get update && \
    apt-get install -y curl git && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/*

# EXPOSE: Port expose করুন (শুধু documentation)
EXPOSE 8000
# মনে রাখুন: docker run -p 8000:8000 দরকার

# VOLUME: Mount point তৈরি করুন
VOLUME /data
VOLUME ["/data", "/logs"]

# USER: Container এ run করার user
RUN useradd -m -u 1000 appuser
USER appuser

# CMD: Default command (override করা যায়)
CMD ["python", "app.py"]
# docker run myapp python test.py → test.py চলবে

# ENTRYPOINT: Entry point (override করা কঠিন)
ENTRYPOINT ["python"]
CMD ["app.py"]
# docker run myapp app.py → python app.py চলবে

# HEALTHCHECK: Container স্বাস্থ্য পরীক্ষা
HEALTHCHECK --interval=30s --timeout=3s --retries=3 \
    CMD curl -f http://localhost:8000/ || exit 1
```

### Image Build করা

```bash
# সাধারণ build
docker build -t myapp:1.0 .

# অনেক options সহ
docker build \
    -t myapp:1.0 \                    # Image name
    -f Dockerfile \                   # Dockerfile path
    --build-arg VERSION=1.0 \         # Build arguments
    .                                 # Context (current dir)

# Multiple tags
docker build -t myapp:1.0 -t myapp:latest .

# BuildKit সহ (দ্রুত, ভাল caching)
DOCKER_BUILDKIT=1 docker build -t myapp:1.0 .

# Build progress দেখুন
docker build --progress=plain -t myapp:1.0 .
```

### Best Practices

```dockerfile
# ✓ ভাল
FROM python:3.9-alpine              # Alpine ছোট
COPY requirements.txt .             # Dependencies আগে
RUN pip install -r requirements.txt # এটি caching এ সাহায্য করে
COPY . .                            # Code শেষে

# ✗ খারাপ
FROM python:3.9                     # বড় image
COPY . .                            # সব এক সাথে
RUN pip install -r requirements.txt  # প্রতিবার reinstall হয়

# ✓ Multi-stage build (image size কমায় ५-१० গুণ)
FROM python:3.9 AS builder
RUN pip install -r requirements.txt

FROM python:3.9-alpine
COPY --from=builder /usr/local/lib /usr/local/lib
```

### .dockerignore তৈরি করুন

```
# Docker এ এই files যাবে না
node_modules/
.git
.env
*.log
__pycache__
.pytest_cache
.vscode
.DS_Store
README.md
```

---

## অধ্যায় 6: Docker Compose

### কেন Docker Compose?

```
একটি container:  docker run
দুটি container:   docker run + docker run (জটিল!)
পাঁচটি container: → Docker Compose (সহজ!)
```

### docker-compose.yml ফরম্যাট

```yaml
version: '3.9'  # Version (০৩.৫ থেকে পরপূর্বতা)

services:
  # ─────────────────────────────────────────────────
  # Service 1: Web Application
  # ─────────────────────────────────────────────────
  web:
    build:
      context: .           # Dockerfile এর জায়গা
      dockerfile: Dockerfile
    container_name: myapp_web
    ports:
      - "5000:5000"        # Host:Container
    volumes:
      - .:/app             # Current dir → Container
      - /app/node_modules  # node_modules exclude করুন
    environment:
      - DATABASE_URL=postgresql://db:5432/mydb
      - DEBUG=False
    depends_on:
      db:
        condition: service_healthy  # db healthy হওয়ার জন্য অপেক্ষা করুন
    networks:
      - backend
    restart: unless-stopped
    healthcheck:
      test: ["CMD", "curl", "-f", "http://localhost:5000"]
      interval: 30s
      timeout: 5s
      retries: 3

  # ─────────────────────────────────────────────────
  # Service 2: Database
  # ─────────────────────────────────────────────────
  db:
    image: postgres:13-alpine
    container_name: myapp_db
    environment:
      - POSTGRES_USER=user
      - POSTGRES_PASSWORD=secure_password
      - POSTGRES_DB=mydb
    volumes:
      - db_data:/var/lib/postgresql/data
    networks:
      - backend
    healthcheck:
      test: ["CMD-SHELL", "pg_isready -U user"]
      interval: 10s
      timeout: 5s
      retries: 5

  # ─────────────────────────────────────────────────
  # Service 3: Cache
  # ─────────────────────────────────────────────────
  cache:
    image: redis:alpine
    volumes:
      - redis_data:/data
    networks:
      - backend

networks:
  backend:
    driver: bridge

volumes:
  db_data:
  redis_data:
```

### Docker Compose কমান্ড

```bash
# ███████ শুরু এবং বন্ধ ███████
docker-compose up              # Foreground এ শুরু করুন
docker-compose up -d           # Detached mode

docker-compose down            # Services বন্ধ করুন (data থাকে)
docker-compose down -v         # Volumes delete সহ

# ███████ Logs দেখুন ███████
docker-compose logs            # সব services
docker-compose logs -f         # Real-time
docker-compose logs web        # Specific service

# ███████ Services পরিচালনা ███████
docker-compose ps              # চলমান services
docker-compose restart         # সব restart করুন
docker-compose restart web     # Specific service

docker-compose build           # Re-build করুন
docker-compose build --no-cache

docker-compose up -d --scale worker=3  # Scale করুন

# ███████ Shell access ███████
docker-compose exec web bash            # Web service এ
docker-compose exec db psql -U user     # Database এ

# ███████ Cleanup ███████
docker-compose rm              # Containers delete (চলছে না এমন)
docker-compose down --rmi local # Services, volumes, local images delete
```

### Real-world উদাহরণ

```yaml
# ফুল-স্ট্যাক অ্যাপ্লিকেশন
version: '3.9'

services:
  frontend:
    build: ./frontend
    ports:
      - "3000:3000"
    volumes:
      - ./frontend/src:/app/src

  backend:
    build: ./backend
    environment:
      - DATABASE_URL=postgresql://postgres:pass@db:5432/app
    depends_on:
      - db

  db:
    image: postgres:13-alpine
    environment:
      - POSTGRES_PASSWORD=pass
    volumes:
      - db_data:/data

  nginx:
    image: nginx:alpine
    ports:
      - "80:80"
    volumes:
      - ./nginx.conf:/etc/nginx/nginx.conf

volumes:
  db_data:
```

---

## অধ্যায় 7: Docker Volumes

### Volume কেন প্রয়োজন

```
সমস্যা: Container delete → সব data হারায়
সমাধান: Volume ব্যবহার করুন (Host এ save থাকে)
```

### Volume প্রকার

```bash
# ███████ Named Volume (Docker managed) ███████
docker volume create mydata         # তৈরি করুন
docker volume ls                    # List করুন
docker volume inspect mydata        # Details দেখুন
docker volume rm mydata             # Delete করুন

docker run -v mydata:/data nginx    # Container এ attach করুন


# ███████ Bind Mount (Host directory) ███████
docker run -v /home/user/data:/data nginx        # Host path
docker run -v $(pwd):/app myapp                  # Current directory
docker run -v /home/conf:/config:ro nginx        # Read-only


# ███████ tmpfs Mount (Memory, Linux only) ███████
docker run --tmpfs /tmp:size=512m myapp         # Temporary storage
```

### docker-compose.yml এ Volume

```yaml
version: '3.9'

services:
  app:
    image: myapp
    volumes:
      - named_volume:/data         # Named volume
      - ./src:/app/src             # Bind mount
      - /app/node_modules          # Anonymous volume

volumes:
  named_volume:  # এখানে define করুন top-level
```

### Volume Backup এবং Restore

```bash
# ███████ Backup করুন ███████
docker run --rm \
  -v mydata:/data \
  -v $(pwd):/backup \
  ubuntu tar czf /backup/backup.tar.gz /data

# ███████ Restore করুন ███████
docker run --rm \
  -v mydata:/data \
  -v $(pwd):/backup \
  ubuntu tar xzf /backup/backup.tar.gz -C /
```

---

## অধ্যায় 7: Docker Networking

### Network Types

```bash
# ████████ Bridge (Default) ████████
docker network create my-bridge
docker run --network my-bridge nginx
docker run --network my-bridge alpine ping nginx

# ████████ Host ████████
docker run --network host nginx        # Host এর network ব্যবহার করুন

# ████████ None ████████
docker run --network none nginx        # Network ছাড়া
```

### Network কমান্ড

```bash
docker network ls              # সব networks
docker network create my-net   # তৈরি করুন
docker network inspect my-net  # Details

docker network connect my-net container_id    # Container এ join করান
docker network disconnect my-net container_id # Remove করুন

docker network rm my-net       # Delete করুন
```

### docker-compose.yml এ Network

```yaml
version: '3.9'

services:
  web:
    networks:
      - frontend
      - backend  # দুটি network এ belong করতে পারে

  db:
    networks:
      - backend

networks:
  frontend:
    driver: bridge
  backend:
    driver: bridge

# Service discovery: web থেকে db এ connect করতে:
# postgresql://db:5432 (container নাম hostname হিসেবে কাজ করে)
```

---

## অধ্যায় 9: Advanced Topics

### Multi-stage Builds (Image size কমান)

```dockerfile
# ██████ Build stage ██████
FROM node:16 AS builder
WORKDIR /app
COPY package*.json ./
RUN npm ci
COPY . .
RUN npm run build

# ██████ Production stage ██████
FROM node:16-alpine
WORKDIR /app
COPY --from=builder /app/dist ./dist
COPY --from=builder /app/node_modules ./node_modules
EXPOSE 3000
CMD ["node", "dist/index.js"]

# Result: ৫০০ MB → ২০০ MB!
```

### Docker BuildKit (দ্রুত Build)

```bash
# Enable করুন (Linux/Mac)
export DOCKER_BUILDKIT=1
docker build -t myapp:latest .

# Windows (PowerShell)
$env:DOCKER_BUILDKIT=1
docker build -t myapp:latest .
```

---

## অধ্যায় ১০: Production

### Resource Limits সেট করুন

```bash
# Container চালানোর সময়
docker run \
  --cpus="1.5" \        # CPU cores
  --memory="512m" \     # RAM
  myapp:latest
```

### Monitoring

```bash
docker stats               # Real-time CPU, Memory
docker logs -f container   # Logs দেখুন
docker inspect container   # Details
```

### Security

```dockerfile
# ✓ Non-root user
RUN useradd -m appuser
USER appuser

# ✓ Read-only filesystem
docker run --read-only myapp

# ✓ Health check
HEALTHCHECK --interval=30s CMD curl -f http://localhost/
```

---

## FAQ

**Q: Docker এবং VM এর পার্থক্য?**
A: Docker lightweight এবং দ্রুত, VM পূর্ণ OS চালায়।

**Q: Production এ ব্যবহার করা যায়?**
A: হ্যাঁ, best practices অনুসরণ করলে।

**Q: একটি container একটি সার্ভার বা একটি app?**
A: একটি app (একটি প্রক্রিয়া)। Multi-container সরঞ্জাম ব্যবহার করুন (Kubernetes)।

---

## সম্পদ

- Docker Docs: https://docs.docker.com
- Docker Hub: https://hub.docker.com
- Kubernetes: https://kubernetes.io (পরবর্তী level)

---


Docker Desktop ব্যবহার করে MySQL Container থেকে সম্পূর্ণ (Full) ডাটা ব্যাকআপ এবং রিস্টোর করার একটি প্রফেশনাল, কমপ্লিট এবং স্টেপ-বাই-স্টেপ গাইড। এই টিউটোরিয়ালে সাধারণ ব্যাকআপের পাশাপাশি ক্লাউডে (Google Drive এবং OneDrive) অটোমেটিক ব্যাকআপ রাখার পদ্ধতিও যুক্ত করা হয়েছে।

---

## 🔰 Prerequisites (শুরু করার আগে যা প্রয়োজন)
* [ ] **Docker Desktop** আপনার কম্পিউটারে ইনস্টলড এবং রানিং থাকতে হবে।
* [ ] একটি **MySQL Container** সচল থাকতে হবে।
* [ ] আপনার কন্টেইনারের নাম (**Container Name**) জানতে হবে (যেমন: `mysql-container`)।
* [ ] MySQL-এর **Root Password** জানা থাকতে হবে।

### 🔍 Container রানিং আছে কিনা চেক করার কমান্ড:

```

```text
File successfully generated!

```bash
docker ps

```

**আউটপুট উদাহরণ:**

```text
CONTAINER ID   IMAGE      COMMAND                  NAMES
xxxxxx123456   mysql:8    "docker-entrypoint.s…"   mysql-container

```

*এখানে `mysql-container` হলো আমাদের কন্টেইনারের নাম (Container Name)।*

---

## 🗄️ Step 1: Single Database Backup (বেসিক ব্যাকআপ)

যদি আপনি কন্টেইনারের ভেতর থেকে নির্দিষ্ট কোনো একটি ডাটাবেজের ব্যাকআপ নিতে চান (যেমন: `demo_db`), তবে নিচের কমান্ডটি রান করুন:

```bash
docker exec mysql-container mysqldump -u root -proot123 demo_db > demo_db_backup.sql

```

### 📌 প্যারামিটার পরিচিতি:

* `-u root` $\rightarrow$ MySQL-এর ইউজারনেম (Username)।
* `-proot123` $\rightarrow$ MySQL-এর পাসওয়ার্ড (এখানে পাসওয়ার্ড `root123`)। **⚠️ সতর্কবার্তা:** `-p` এবং পাসওয়ার্ডের মাঝে কোনো স্পেস (Space) দেওয়া যাবে না।
* `demo_db` $\rightarrow$ যে ডাটাবেজটির ব্যাকআপ নিতে চান তার নাম।
* `>` $\rightarrow$ কন্টেইনার থেকে ডাটা এক্সপোর্ট করে আপনার লোকাল হোস্ট মেশিনে (Host Machine) ফাইল হিসেবে সেভ করবে।

---

## 🌍 Step 2: Full MySQL Backup (প্রোডাকশন লেভেল - রিকমেন্ডেড)

প্রোডাকশন এনভায়রনমেন্টে শুধু ডাটাবেজ নয়, বরং সব ডাটাবেজের পাশাপাশি সমস্ত প্রোসিডিউর, ইভেন্ট এবং ট্রিগারসহ সম্পূর্ণ ব্যাকআপ নেওয়া নিরাপদ।

```bash
docker exec mysql-container mysqldump \\
  -u root -proot123 \\
  --all-databases \\
  --routines \\
  --events \\
  --triggers \\
  > full_mysql_backup.sql

```

### ⚙️ অপশনসমূহের ব্যাখ্যা:

* `--all-databases` $\rightarrow$ কন্টেইনারের ভেতরের সব ডাটাবেজ একসাথে ব্যাকআপ নেবে।
* `--routines` $\rightarrow$ সব Stored Procedures এবং Functions ব্যাকআপ করবে।
* `--events` $\rightarrow$ MySQL Event Scheduler-এর সব ইভেন্ট যুক্ত করবে।
* `--triggers` $\rightarrow$ টেবিলের সাথে যুক্ত সমস্ত ট্রিগার ব্যাকআপ করবে।

---

## 👤 Step 3: MySQL Users & Permissions Backup

ডাটাবেজ রিস্টোর করার পর অনেক সময় ইউজার পারমিশন না থাকলে অ্যাপ্লিকেশন কানেক্ট হতে পারে না। তাই ইউজার ও পারমিশন টেবিল আলাদা ব্যাকআপ রাখা বুদ্ধিমানের কাজ:

```bash
docker exec mysql-container mysqldump \\
  -u root -proot123 mysql \\
  user db tables_priv columns_priv procs_priv \\
  > mysql_users_backup.sql

```

*এটি মূল `mysql` সিস্টেম ডাটাবেজ থেকে ইউজার এবং তাদের প্রিভিলেজ (Privileges) সংক্রান্ত টেবিলগুলো ব্যাকআপ করে।*

---

## 📂 Step 4: Backup File Verification (ফাইল যাচাইকরণ)

ব্যাকআপ ফাইলটি ঠিকঠাক তৈরি হয়েছে কিনা তা চেক করতে আপনার টার্মিনাল বা কমান্ড প্রম্পটে নিচের কমান্ডগুলো ব্যবহার করতে পারেন:

### Windows (CMD):

```cmd
dir *.sql
type full_mysql_backup.sql | more

```

### Linux / macOS / Git Bash:

```bash
ls -lh *.sql
head -n 20 full_mysql_backup.sql

```

---

## 🔄 Step 5: Restore Database from Backup (ডাটা রিস্টোর করার নিয়ম)

কোনো কারণে ডাটা হারিয়ে গেলে বা নতুন কন্টেইনারে ব্যাকআপ ফাইল থেকে ডাটা ফিরিয়ে আনার পদ্ধতি নিচে দেওয়া হলো:

### 🔹 সম্পূর্ণ ডাটাবেজ রিস্টোর করতে (Full Restore):

```bash
docker exec -i mysql-container mysql -u root -proot123 < full_mysql_backup.sql

```

### 🔹 নির্দিষ্ট একটি ডাটাবেজ রিস্টোর করতে (Single Database Restore):

```bash
docker exec -i mysql-container mysql -u root -proot123 demo_db < demo_db_backup.sql

```

* **দ্রষ্টব্য:** রিস্টোর করার সময় `mysqldump`-এর পরিবর্তে `mysql` কমান্ড ব্যবহৃত হয় এবং `>` চিহ্নের বদলে `<` (Input Redirection) চিহ্ন ব্যবহার করা হয়। এছাড়া এখানে `-i` (Interactive) ফ্ল্যাগ ব্যবহার করা বাধ্যতামূলক।

---

## 🔐 Step 6: Secure Backup Method (ক্লিন ও নিরাপদ পদ্ধতি)

সরাসরি লাইভ ডকার এক্সিকিউশনে বড় ডাটাবেজের ক্ষেত্রে অনেক সময় নেটওয়ার্ক বা পাইপলাইনের কারণে ফাইল করাপ্ট হতে পারে। তাই সবচেয়ে নিরাপদ ও স্ট্যান্ডার্ড প্র্যাকটিস হলো:

1. **প্রথমে কন্টেইনারের শেলের (Shell) ভেতর প্রবেশ করুন:**
```bash
docker exec -it mysql-container bash

```


2. **কন্টেইনারের নিজস্ব `/tmp` ফোল্ডারে ব্যাকআপ ফাইল তৈরি করুন:**
```bash
mysqldump -u root -p --all-databases > /tmp/full_backup.sql

```


*(এখানে এন্টার চাপার পর পাসওয়ার্ড চাইলে টাইপ করুন, এতে স্ক্রিনে পাসওয়ার্ড ওপেনলি দেখা যাবে না।)*
3. **কন্টেইনার থেকে বের হয়ে আসুন:**
```bash
exit

```


4. **`docker cp` কমান্ড ব্যবহার করে ফাইলটি লোকাল মেশিনে নিয়ে আসুন:**
```bash
docker cp mysql-container:/tmp/full_backup.sql .

```



---

## ☁️ Step 7: Google Drive Auto Backup (Using Rclone)

আপনার ব্যাকআপ ফাইলটি স্বয়ংক্রিয়ভাবে ক্লাউডে আপলোড করার জন্য আমরা **Rclone** টুলটি ব্যবহার করব। এটি অত্যন্ত লাইটওয়েট এবং সিকিউর।

### 🛠️ সেটআপ প্রসেস:

1. **Rclone ডাউনলোড ও ইনস্টল করুন:** [rclone.org/downloads](https://rclone.org/downloads/) থেকে উইন্ডোজ বা আপনার ওএসের জন্য ডাউনলোড করে এনভায়রনমেন্ট ভ্যারিয়েবলে পাথ (Path) সেট করুন।
2. **গুগল ড্রাইভ কনফিগার করুন:** আপনার টার্মিনালে রান করুন:
```bash
rclone config

```


* `n` চাপুন (New remote)।
* নাম দিন: `gdrive`
* স্টোরেজ টাইপ সিলেক্ট করুন: `drive` (Google Drive এর নম্বরটি দিন)।
* ব্রাউজারে অটোমেটিক একটি উইন্ডো খুলবে, সেখান থেকে আপনার গুগল অ্যাকাউন্ট দিয়ে 'Allow' বাটনে ক্লিক করে Auth কমপ্লিট করুন।



### 📜 Automated Batch Script (`backup_to_gdrive.bat`)

আপনার লোকাল ড্রাইভে (ধরি `D:\\mysql_backups`) একটি ফাইল তৈরি করুন `backup_to_gdrive.bat` নামে এবং নিচের কোডটি কপি-পেস্ট করুন:

```batch
@echo off
:: ফোল্ডার পাথ এবং তারিখ ফরমেট সেটআপ (YYYY-MM-DD)
set BACKUP_DIR=D:\\mysql_backups
for /f "tokens=2 delims==" %%I in ('wmic os get localdatetime /value') do set datetime=%%I
set DATE_STR=%datetime:~0,4%-%datetime:~4,2%-%datetime:~6,2%

echo Starting MySQL Backup...

:: ১. ডকার থেকে ব্যাকআপ নেওয়া
docker exec mysql-container mysqldump -u root -proot123 --all-databases --routines --events --triggers > "%BACKUP_DIR%\\mysql_full_backup_%DATE_STR%.sql"

echo Backup completed locally. Uploading to Google Drive...

:: ২. রিক্লোন দিয়ে গুগল ড্রাইভে 'mysql-backups' ফোল্ডারে আপলোড করা
rclone copy "%BACKUP_DIR%\\mysql_full_backup_%DATE_STR%.sql" gdrive:/mysql-backups

echo Cloud upload successfully finished!

```

---

## ☁️ Step 8: OneDrive Auto Backup (সহজ ও সরাসরি পদ্ধতি)

OneDrive-এর ক্ষেত্রে সবচেয়ে সহজ বুদ্ধি হলো উইন্ডোজের অফিসিয়াল OneDrive ডেক্সটপ অ্যাপ ব্যবহার করা। এটি লোকাল ফোল্ডারে ফাইল রাখা মাত্রই ব্যাকগ্রাউন্ডে সিংক্রোনাইজ (Sync) করে নেয়।

### 📜 Automated Batch Script (`backup_to_onedrive.bat`)

আপনার OneDrive ফোল্ডারের ভেতর একটি ডিরেক্টরি তৈরি করুন (যেমন: `mysql_backups`)। এবার নিচের স্ক্রিপ্টটি দিয়ে একটি `.bat` ফাইল তৈরি করুন:

```batch
@echo off
:: আপনার পিসির ইউজারনেম অনুযায়ী পাথ পরিবর্তন করুন
set ONEDRIVE_DIR=C:\\Users\\YOUR_PC_USERNAME\\OneDrive\\mysql_backups
for /f "tokens=2 delims==" %%I in ('wmic os get localdatetime /value') do set datetime=%%I
set DATE_STR=%datetime:~0,4%-%datetime:~4,2%-%datetime:~6,2%

echo Executing backup directly to OneDrive directory...

:: সরাসরি ওয়ানড্রাইভ সিঙ্ক ফোল্ডারে ব্যাকআপ ফাইল রাইট করা
docker exec mysql-container mysqldump -u root -proot123 --all-databases --routines --events --triggers > "%ONEDRIVE_DIR%\\mysql_full_backup_%DATE_STR%.sql"

echo Backup saved to OneDrive folder. Windows will automatically sync the file.

```

*⚠️ **নোট:** `YOUR_PC_USERNAME` লেখা জায়গাটিতে আপনার পিসির অরিজিনাল ইউজার ফোল্ডারের নাম বসিয়ে দিন।*

---

## ⏰ Step 9: Windows Task Scheduler দিয়ে Automation রান করা

উপরের স্ক্রিপ্ট দুটি প্রতিদিন নির্দিষ্ট সময়ে স্বয়ংক্রিয়ভাবে রান করানোর জন্য নিচের ধাপগুলো অনুসরণ করুন:

1. উইন্ডোজ সার্চ বারে লিখুন **Task Scheduler** এবং ওপেন করুন।
2. ডানপাশের প্যানেল থেকে **Create Basic Task**-এ ক্লিক করুন।
3. টাস্কের একটি নাম দিন (যেমন: `Docker_MySQL_Daily_Backup`)।
4. **Trigger** সেকশনে `Daily` সিলেক্ট করুন এবং আপনার সুবিধাজনক সময় (যেমন: রাত ১২:০০ টা) নির্ধারণ করুন।
5. **Action** সেকশনে `Start a program` সিলেক্ট করুন।
6. **Program/script** ব্রাউজ (Browse) বাটনে ক্লিক করে আপনার তৈরি করা `.bat` ফাইলটি (গুগল ড্রাইভ বা ওয়ানড্রাইভের স্ক্রিপ্ট) সিলেক্ট করে দিন।
7. **Finish** বাটনে ক্লিক করুন। এখন থেকে প্রতিদিন নির্দিষ্ট সময়ে আপনার ডাটাবেজ ব্যাকআপ হয়ে স্বয়ংক্রিয়ভাবে ক্লাউডে চলে যাবে!

---

## ⚠️ Common Errors & Instant Fix (সাধারণ সমস্যা ও সমাধান)

### ১. `Access denied for user 'root'@'localhost' (using password: NO)`

* **কারণ:** আপনি পাসওয়ার্ড দেননি অথবা পাসওয়ার্ড কমান্ডে ভুল লিখেছেন।
* **সমাধান:** `-proot123` ঠিক এভাবে লিখুন। কোনো স্পেস বা অতিরিক্ত কোটেশন ব্যবহার করবেন না।

### ২. `Error: MySQL container is restarting / not found`

* **কারণ:** আপনার কন্টেইনারটি বন্ধ বা ক্র্যাশ করেছে অথবা আপনি ভুল কন্টেইনার নাম টাইপ করেছেন।
* **সমাধান:** `docker ps` দিয়ে সঠিক নামটি নিশ্চিত হয়ে নিন এবং কন্টেইনার সচল না থাকলে `docker start mysql-container` দিয়ে চালু করুন।

---

## 📌 Best Practices Summary (সেরা কিছু পরামর্শ)

* [x] **সবসময় অল-ডাটাবেজ ব্যাকআপ নিন:** প্রোডাকশনে ডাটা মিসিং এড়াতে `--all-databases` ব্যবহার করা সবচেয়ে নিরাপদ।
* [x] **3-2-1 ব্যাকআপ রুল মানুন:** ৩টি কপি রাখুন, ২টি ভিন্ন লোকাল মিডিয়াতে এবং অন্তত ১টি কপি ক্লাউডে (যেমন আমাদের এই গাইডের Google Drive/OneDrive ব্যাকআপ)।
* [x] **পাসওয়ার্ড নিরাপত্তা:** প্রোডাকশন স্ক্রিপ্ট বা ব্যাচ ফাইলটি পিসির এমন ডিরেক্টরিতে রাখুন যেখানে অন্য সাধারণ ইউজারের এক্সেস নেই।
* [x] **অটো-ডিলিট পলিসি:** লোকাল ড্রাইভে স্পেস বাঁচাতে নির্দিষ্ট সময় পর (যেমন ৩০ দিন আগের) পুরোনো ব্যাকআপ ফাইল ডিলিট করার স্ক্রিপ্ট বা রুটিন সেট করে রাখুন।

---

**📘 You Are Now Production Ready! 🎉** আপনার ডকারাইজড MySQL ডাটাবেজ এখন সম্পূর্ণ নিরাপদ এবং ক্লাউড অটোমেশনের সাথে ইন্টিগ্রেটেড!
"""

with open("Docker_MySQL_Backup_Tutorial.md", "w", encoding="utf-8") as f:
f.write(markdown_content)
print("File successfully generated!")

```
Your Markdown file is ready
[file-tag: code-generated-file-0-1779614193890953876]

আপনার দেওয়া পুরো টিউটোরিয়ালটিকে রিভিউ করে, প্রফেশনাল স্ট্যান্ডার্ডে কারেকশন এবং ফর্ম্যাটিং ফিক্স করে একটি কমপ্লিট **Markdown (.md)** ডকুমেন্ট তৈরি করে দিয়েছি। 

### 🔧 এই সংস্করণে যা যা কারেকশন ও উন্নত করা হয়েছে:
1. **উইন্ডোজ ব্যাচ স্ক্রিপ্ট ডেট ফিক্স (`%DATE%` bug fix):** উইন্ডোজে স্বাভাবিক পিসি বা সার্ভারের রিজিওনাল সেটিংসে ডেট ফরম্যাট (`MM/DD/YYYY` বা `DD-MM-YYYY`) একেক রকম হতে পারে। এর ফলে সাধারণ `%DATE:~10,4%` কমান্ড অনেক সময় ভুল নাম বা ক্র্যাশ জেনারেট করে। এখানে একটি ইউনিভার্সাল `wmic os get localdatetime` মেথড ব্যবহার করা হয়েছে যা সব উইন্ডোজ পিসিতে নিখুঁতভাবে `YYYY-MM-DD` ফরম্যাটে ব্যাকআপ ফাইল তৈরি করবে।
2. **প্যারামিটার ও এস্কেপ ক্যারেক্টার কারেকশন:** মাল্টি-লাইন ব্যাকআপ কমান্ডের জন্য সঠিক ব্যাকস্ল্যাশ (`\`) এস্কেপ সিকোয়েন্স এবং রিস্টোর করার জন্য সঠিক ইনপুট ডিরেকশন (`<`) ডকার কমান্ডে প্রফেশনাল গাইডলাইন অনুযায়ী সাজানো হয়েছে।
3. **পাথ হ্যান্ডলিং:** ব্যাচ ফাইলে ফোল্ডার পাথের ডাবল কোটেশন (`" `) ঠিক করা হয়েছে যাতে ফোল্ডারের নামে কোনো স্পেস থাকলেও স্ক্রিপ্ট সফলভাবে কাজ করে।
4. **সহজ উইন্ডোজ টাস্ক শিডিউলার গাইড:** উইন্ডোজ ব্যাকআপ অটোমেশন রান করার জন্য একদম সহজ ও পরিষ্কার স্টেপ যুক্ত করা হয়েছে।

ডকুমেন্টটি ডাউনলোডের পাশাপাশি আপনি চাইলে নিচে থেকেও সরাসরি কোডটি কপি করে নিতে পারেন:

```markdown
# Docker MySQL Full Backup Tutorial (Step by Step)

Docker Desktop ব্যবহার করে MySQL Container থেকে সম্পূর্ণ (Full) ডাটা ব্যাকআপ এবং রিস্টোর করার একটি প্রফেশনাল, কমপ্লিট এবং স্টেপ-বাই-স্টেপ গাইড। এই টিউটোরিয়ালে সাধারণ ব্যাকআপের পাশাপাশি ক্লাউডে (Google Drive এবং OneDrive) অটোমেটিক ব্যাকআপ রাখার পদ্ধতিও যুক্ত করা হয়েছে।

---

## 🔰 Prerequisites (শুরু করার আগে যা প্রয়োজন)
* [ ] **Docker Desktop** আপনার কম্পিউটারে ইনস্টলড এবং রানিং থাকতে হবে।
* [ ] একটি **MySQL Container** সচল থাকতে হবে।
* [ ] আপনার কন্টেইনারের নাম (**Container Name**) জানতে হবে (যেমন: `mysql-container`)।
* [ ] MySQL-এর **Root Password** জানা থাকতে হবে।

### 🔍 Container রানিং আছে কিনা চেক করার কমান্ড:
```bash
docker ps

```

**আউটপুট উদাহরণ:**

```text
CONTAINER ID   IMAGE      COMMAND                  NAMES
xxxxxx123456   mysql:8    "docker-entrypoint.s…"   mysql-container

```

*এখানে `mysql-container` হলো আমাদের কন্টেইনারের নাম (Container Name)।*

---

## 🗄️ Step 1: Single Database Backup (বেসিক ব্যাকআপ)

যদি আপনি কন্টেইনারের ভেতর থেকে নির্দিষ্ট কোনো একটি ডাটাবেজের ব্যাকআপ নিতে চান (যেমন: `demo_db`), তবে নিচের কমান্ডটি রান করুন:

```bash
docker exec mysql-container mysqldump -u root -proot123 demo_db > demo_db_backup.sql

```

### 📌 প্যারামিটার পরিচিতি:

* `-u root` → MySQL-এর ইউজারনেম (Username)।
* `-proot123` → MySQL-এর পাসওয়ার্ড (এখানে পাসওয়ার্ড `root123`)। **⚠️ সতর্কবার্তা:** `-p` এবং পাসওয়ার্ডের মাঝে কোনো স্পেস (Space) দেওয়া যাবে না।
* `demo_db` → যে ডাটাবেজটির ব্যাকআপ নিতে চান তার নাম।
* `>` → কন্টেইনার থেকে ডাটা এক্সপোর্ট করে আপনার লোকাল হোস্ট মেশিনে (Host Machine) ফাইল হিসেবে সেভ করবে।

---

## 🌍 Step 2: Full MySQL Backup (প্রোডাকশন লেভেল - রিকমেন্ডেড)

প্রোডাকশন এনভায়রনমেন্টে শুধু ডাটাবেজ নয়, বরং সব ডাটাবেজের পাশাপাশি সমস্ত প্রোসিডিউর, ইভেন্ট এবং ট্রিগারসহ সম্পূর্ণ ব্যাকআপ নেওয়া নিরাপদ।

```bash
docker exec mysql-container mysqldump \
  -u root -proot123 \
  --all-databases \
  --routines \
  --events \
  --triggers \
  > full_mysql_backup.sql

```

### ⚙️ অপশনসমূহের ব্যাখ্যা:

* `--all-databases` → কন্টেইনারের ভেতরের সব ডাটাবেজ একসাথে ব্যাকআপ নেবে।
* `--routines` → সব Stored Procedures এবং Functions ব্যাকআপ করবে।
* `--events` → MySQL Event Scheduler-এর সব ইভেন্ট যুক্ত করবে।
* `--triggers` → টেবিলের সাথে যুক্ত সমস্ত ট্রিগার ব্যাকআপ করবে。

---

## 👤 Step 3: MySQL Users & Permissions Backup

ডাটাবেজ রিস্টোর করার পর অনেক সময় ইউজার পারমিশন না থাকলে অ্যাপ্লিকেশন কানেক্ট হতে পারে না। তাই ইউজার ও পারমিশন টেবিল আলাদা ব্যাকআপ রাখা বুদ্ধিমানের কাজ:

```bash
docker exec mysql-container mysqldump \
  -u root -proot123 mysql \
  user db tables_priv columns_priv procs_priv \
  > mysql_users_backup.sql

```

*এটি মূল `mysql` সিস্টেম ডাটাবেজ থেকে ইউজার এবং তাদের প্রিভিলেজ (Privileges) সংক্রান্ত টেবিলগুলো ব্যাকআপ করে।*

---

## 📂 Step 4: Backup File Verification (ফাইল যাচাইকরণ)

ব্যাকআপ ফাইলটি ঠিকঠাক তৈরি হয়েছে কিনা তা চেক করতে আপনার টার্মিনাল বা কমান্ড প্রম্পটে নিচের কমান্ডগুলো ব্যবহার করতে পারেন:

### Windows (CMD):

```cmd
dir *.sql
type full_mysql_backup.sql | more

```

### Linux / macOS / Git Bash:

```bash
ls -lh *.sql
head -n 20 full_mysql_backup.sql

```

---

## 🔄 Step 5: Restore Database from Backup (ডাটা রিস্টোর করার নিয়ম)

কোনো কারণে ডাটা হারিয়ে গেলে বা নতুন কন্টেইনারে ব্যাকআপ ফাইল থেকে ডাটা ফিরিয়ে আনার পদ্ধতি নিচে দেওয়া হলো:

### 🔹 সম্পূর্ণ ডাটাবেজ রিস্টোর করতে (Full Restore):

```bash
docker exec -i mysql-container mysql -u root -proot123 < full_mysql_backup.sql

```

### 🔹 নির্দিষ্ট একটি ডাটাবেজ রিস্টোর করতে (Single Database Restore):

```bash
docker exec -i mysql-container mysql -u root -proot123 demo_db < demo_db_backup.sql

```

* **द्रष्टव्य:** রিস্টোর করার সময় `mysqldump`-এর পরিবর্তে `mysql` কমান্ড ব্যবহৃত হয় এবং `>` চিহ্নের বদলে `<` (Input Redirection) চিহ্ন ব্যবহার করা হয়। এছাড়া এখানে `-i` (Interactive) ফ্ল্যাগ ব্যবহার করা বাধ্যতামূলক।

---

## 🔐 Step 6: Secure Backup Method (ক্লিন ও নিরাপদ পদ্ধতি)

সরাসরি লাইভ ডকার এক্সিকিউশনে বড় ডাটাবেজের ক্ষেত্রে অনেক সময় নেটওয়ার্ক বা পাইপলাইনের কারণে ফাইল করাপ্ট হতে পারে। তাই সবচেয়ে নিরাপদ ও স্ট্যান্ডার্ড প্র্যাকটিস হলো:

1. **প্রথমে কন্টেইনারের শেলের (Shell) ভেতর প্রবেশ করুন:**
```bash
docker exec -it mysql-container bash

```


2. **কন্টেইনারের নিজস্ব `/tmp` ফোল্ডারে ব্যাকআপ ফাইল তৈরি করুন:**
```bash
mysqldump -u root -p --all-databases > /tmp/full_backup.sql

```


*(এখানে এন্টার চাপার পর পাসওয়ার্ড চাইলে টাইপ করুন, এতে স্ক্রিনে পাসওয়ার্ড ওপেনলি দেখা যাবে না।)*
3. **কন্টেইনার থেকে বের হয়ে আসুন:**
```bash
exit

```


4. **`docker cp` কমান্ড ব্যবহার করে ফাইলটি লোকাল মেশিনে নিয়ে আসুন:**
```bash
docker cp mysql-container:/tmp/full_backup.sql .

```



---

## ☁️ Step 7: Google Drive Auto Backup (Using Rclone)

আপনার ব্যাকআপ ফাইলটি স্বয়ংক্রিয়ভাবে ক্লাউডে আপলোড করার জন্য আমরা **Rclone** টুলটি ব্যবহার করব। এটি অত্যন্ত লাইটওয়েট এবং সিকিউর।

### 🛠️ সেটআপ প্রসেস:

1. **Rclone ডাউনলোড ও ইনস্টল করুন:** [rclone.org/downloads](https://rclone.org/downloads/) থেকে উইন্ডোজ বা আপনার ওএসের জন্য ডাউনলোড করে এনভায়রনমেন্ট ভ্যারিয়েবলে পাথ (Path) সেট করুন।
2. **গুটল ড্রাইভ কনফিগার করুন:** আপনার টার্মিনালে রান করুন:
```bash
rclone config

```


* `n` চাপুন (New remote)।
* নাম দিন: `gdrive`
* স্টোরেজ টাইপ সিলেক্ট করুন: `drive` (Google Drive এর নম্বরটি দিন)।
* ব্রাউজারে অটোমেটিক একটি উইন্ডো খুলবে, সেখান থেকে আপনার গুগল অ্যাকাউন্ট দিয়ে 'Allow' বাটনে ক্লিক করে Auth কমপ্লিট করুন।



### 📜 Automated Batch Script (`backup_to_gdrive.bat`)

আপনার লোকাল ড্রাইভে (ধরি `D:\mysql_backups`) একটি ফাইল তৈরি করুন `backup_to_gdrive.bat` নামে এবং নিচের কোডটি কপি-পেস্ট করুন:

```batch
@echo off
:: ফোল্ডার পাথ এবং তারিখ ফরমেট সেটআপ (YYYY-MM-DD)
set BACKUP_DIR=D:\mysql_backups
for /f "tokens=2 delims==" %%I in ('wmic os get localdatetime /value') do set datetime=%%I
set DATE_STR=%datetime:~0,4%-%datetime:~4,2%-%datetime:~6,2%

echo Starting MySQL Backup...

:: ১. ডকার থেকে ব্যাকআপ নেওয়া
docker exec mysql-container mysqldump -u root -proot123 --all-databases --routines --events --triggers > "%BACKUP_DIR%\mysql_full_backup_%DATE_STR%.sql"

echo Backup completed locally. Uploading to Google Drive...

:: ২. রিক্লোন দিয়ে গুগল ড্রাইভে 'mysql-backups' ফোল্ডারে আপলোড করা
rclone copy "%BACKUP_DIR%\mysql_full_backup_%DATE_STR%.sql" gdrive:/mysql-backups

echo Cloud upload successfully finished!

```

---

## ☁️ Step 8: OneDrive Auto Backup (সহজ ও সরাসরি পদ্ধতি)

OneDrive-এর ক্ষেত্রে সবচেয়ে সহজ বুদ্ধি হলো উইন্ডোজের অফিসিয়াল OneDrive ডেক্সটপ অ্যাপ ব্যবহার করা। এটি লোকাল ফোল্ডারে ফাইল রাখা মাত্রই ব্যাকগ্রাউন্ডে সিংক্রোনাইজ (Sync) করে নেয়।

### 📜 Automated Batch Script (`backup_to_onedrive.bat`)

আপনার OneDrive ফোল্ডারের ভেতর একটি ডিরেক্টরি তৈরি করুন (যেমন: `mysql_backups`)。 এবার নিচের স্ক্রিপ্টটি দিয়ে একটি `.bat` ফাইল তৈরি করুন:

```batch
@echo off
:: আপনার পিসির ইউজারনেম অনুযায়ী পাথ পরিবর্তন করুন
set ONEDRIVE_DIR=C:\Users\YOUR_PC_USERNAME\OneDrive\mysql_backups
for /f "tokens=2 delims==" %%I in ('wmic os get localdatetime /value') do set datetime=%%I
set DATE_STR=%datetime:~0,4%-%datetime:~4,2%-%datetime:~6,2%

echo Executing backup directly to OneDrive directory...

:: সরাসরি ওয়ানড্রাইভ সিঙ্ক ফোল্ডারে ব্যাকআপ ফাইল রাইট করা
docker exec mysql-container mysqldump -u root -proot123 --all-databases --routines --events --triggers > "%ONEDRIVE_DIR%\mysql_full_backup_%DATE_STR%.sql"

echo Backup saved to OneDrive folder. Windows will automatically sync the file.

```

*⚠️ **নোট:** `YOUR_PC_USERNAME` লেখা জায়গাটিতে আপনার পিসির অরিজিনাল ইউজার ফোল্ডারের নাম বসিয়ে দিন।*

---

## ⏰ Step 9: Windows Task Scheduler দিয়ে Automation রান করা

উপরের স্ক্রিপ্ট দুটি প্রতিদিন নির্দিষ্ট সময়ে স্বয়ংক্রিয়ভাবে রান করানোর জন্য নিচের ধাপগুলো অনুসরণ করুন:

1. উইন্ডোজ সার্চ বারে লিখুন **Task Scheduler** এবং ওপেন করুন।
2. ডানপাশের প্যানেল থেকে **Create Basic Task**-এ ক্লিক করুন।
3. টাস্কের একটি নাম দিন (যেমন: `Docker_MySQL_Daily_Backup`)।
4. **Trigger** সেকশনে `Daily` সিলেক্ট করুন এবং আপনার সুবিধাজনক সময় (যেমন: রাত ১২:০০ টা) নির্ধারণ করুন।
5. **Action** সেকশনে `Start a program` সিলেক্ট করুন。
6. **Program/script** ব্রাউজ (Browse) বাটনে ক্লিক করে আপনার তৈরি করা `.bat` ফাইলটি (গুগল ড্রাইভ বা ওয়ানড্রাইভের স্ক্রিপ্ট) সিলেক্ট করে দিন।
7. **Finish** বাটনে ক্লিক করুন। এখন থেকে প্রতিদিন নির্দিষ্ট সময়ে আপনার ডাটাবেজ ব্যাকআপ হয়ে স্বয়ংক্রিয়ভাবে ক্লাউডে চলে যাবে!

---

## ⚠️ Common Errors & Instant Fix (সাধারণ সমস্যা ও সমাধান)

### ১. `Access denied for user 'root'@'localhost' (using password: NO)`

* **কারণ:** আপনি পাসওয়ার্ড দেননি অথবা পাসওয়ার্ড কমান্ডে ভুল লিখেছেন।
* **সমাধান:** `-proot123` ঠিক এভাবে লিখুন। কোনো স্পেস বা অতিরিক্ত কোটেশন ব্যবহার করবেন না।

### ২. `Error: MySQL container is restarting / not found`

* **কারণ:** আপনার কন্টেইনারটি বন্ধ বা ক্র্যাশ করেছে অথবা আপনি ভুল কন্টেইনার নাম টাইপ করেছেন।
* **সমাধান:** `docker ps` দিয়ে সঠিক নামটি নিশ্চিত হয়ে নিন এবং কন্টেইনার সচল না থাকলে `docker start mysql-container` দিয়ে চালু করুন।

---

## 📌 Best Practices Summary (সেরা কিছু পরামর্শ)

* [x] **সবসময় অল-ডাটাবেজ ব্যাকআপ নিন:** প্রোডাকশনে ডাটা মিসিং এড়াতে `--all-databases` ব্যবহার করা সবচেয়ে নিরাপদ।
* [x] **3-2-1 ব্যাকআপ রুল মানুন:** ৩টি কপি রাখুন, ২টি ভিন্ন লোকাল মিডিয়াতে এবং অন্তত ১টি কপি ক্লাউডে (যেমন আমাদের এই গাইডের Google Drive/OneDrive ব্যাকআপ)।
* [x] **পাসওয়ার্ড নিরাপত্তা:** প্রোডাকশন স্ক্রিপ্ট বা ব্যাচ ফাইলটি পিসির এমন ডিরেক্টরিতে রাখুন যেখানে অন্য সাধারণ ইউজারের এক্সেস নেই।
* [x] **অটো-ডিলিট পলিসি:** লোকাল ড্রাইভে স্পেস বাঁচাতে নির্দিষ্ট সময় পর (যেমন ৩০ দিন আগের) পুরোনো ব্যাকআপ ফাইল ডিলিট করার স্ক্রিপ্ট বা রুটিন সেট করে রাখুন।

---

**📘 You Are Now Production Ready! 🎉** আপনার ডকারাইজড MySQL ডাটাবেজ এখন সম্পূর্ণ নিরাপদ এবং ক্লাউড অটোমেশনের সাথে ইন্টিগ্রেটেড!


**Happy Coding! 🚀**
