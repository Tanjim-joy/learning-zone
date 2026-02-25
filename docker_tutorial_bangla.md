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

**Happy Coding! 🚀**
