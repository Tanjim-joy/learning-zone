# Git, GitHub, GitLab Cheat Sheet

## 🚀 **Quick Reference Guide**

---

### 📦 **শুরু করা (Getting Started)**

| Command | Description | Example |
|---------|-------------|---------|
| `git init` | নতুন লোকাল রিপোজিটরি তৈরি | `git init my-project` |
| `git clone [url]` | রিমোট রিপো ক্লোন করা | `git clone https://github.com/user/repo.git` |
| `git config --global user.name "[name]"` | গ্লোবাল ইউজারনেম সেট | `git config --global user.name "Your Name"` |
| `git config --global user.email "[email]"` | গ্লোবাল ইমেইল সেট | `git config --global user.email "your@email.com"` |

---

### 📝 **প্রতিদিনের কাজ (Daily Workflow)**

| Command | Description | Tips |
|---------|-------------|------|
| `git status` | বর্তমান অবস্থা দেখে | সবসময় `git status` চালিয়ে দেখুন |
| `git add [file]` | নির্দিষ্ট ফাইল স্টেজিং-এ যোগ | `git add index.html` |
| `git add .` | সব পরিবর্তন স্টেজিং-এ যোগ | সতর্ক থাকুন, সব কিছু যোগ হয় |
| `git commit -m "message"` | কমিট করুন | `git commit -m "Add login feature"` |
| `git log` | কমিট ইতিহাস দেখুন | `git log --oneline` (সংক্ষিপ্ত) |
| `git diff` | পরিবর্তন দেখুন | কমিটের আগে চেক করুন |

---

### 🌿 **ব্রাঞ্চ (Branch)**

| Command | Description | Example |
|---------|-------------|---------|
| `git branch` | ব্রাঞ্চ লিস্ট দেখে | বর্তমান ব্রাঞ্চ * চিহ্নিত |
| `git branch [name]` | নতুন ব্রাঞ্চ তৈরি | `git branch feature-login` |
| `git checkout [name]` | ব্রাঞ্চ সুইচ | `git checkout feature-login` |
| `git checkout -b [name]` | তৈরি+সুইচ একসাথে | `git checkout -b new-feature` |
| `git merge [name]` | ব্রাঞ্চ মার্জ | `git merge feature-login` |
| `git branch -d [name]` | ব্রাঞ্চ ডিলিট | `git branch -d old-branch` |
| `git branch -D [name]` | ফোর্স ডিলিট | মার্জ না করা ব্রাঞ্চ ডিলিট |

---

### ☁️ **রিমোট (Remote)**

| Command | Description | Example |
|---------|-------------|---------|
| `git remote add origin [url]` | রিমোট সংযুক্ত | `git remote add origin https://github.com/user/repo.git` |
| `git remote -v` | রিমোট লিস্ট দেখে | কোন রিমোট আছে দেখে |
| `git push -u origin [branch]` | প্রথম পুশ | `git push -u origin main` |
| `git push` | সাধারণ পুশ | রিমোটে আপলোড |
| `git pull` | আপডেট+মার্জ | `git pull origin main` |
| `git fetch` | শুধু আপডেট চেক | মার্জ করে না |
| `git push origin --delete [branch]` | রিমোট ব্রাঞ্চ ডিলিট | `git push origin --delete old-branch` |

---

### 🏷️ **ট্যাগ (Tag)**

| Command | Description | Example |
|---------|-------------|---------|
| `git tag [name]` | নতুন ট্যাগ | `git tag v1.0.0` |
| `git tag` | ট্যাগ লিস্ট | সব ট্যাগ দেখে |
| `git push origin [tag]` | ট্যাগ পুশ | `git push origin v1.0.0` |
| `git push --tags` | সব ট্যাগ পুশ | একসাথে সব ট্যাগ পাঠায় |

---

### 💾 **স্ট্যাশ (Stash)**

| Command | Description | Example |
|---------|-------------|---------|
| `git stash` | পরিবর্তন সাময়িক সেভ | নাম না দিয়ে সেভ |
| `git stash save "message"` | মেসেজসহ স্ট্যাশ | `git stash save "WIP: login form"` |
| `git stash list` | স্ট্যাশ লিস্ট | সব স্ট্যাশ দেখে |
| `git stash apply` | শেষ স্ট্যাশ ফিরিয়ে আনে | স্ট্যাশ রাখে |
| `git stash pop` | শেষ স্ট্যাশ ফিরিয়ে আনে + ডিলিট | স্ট্যাশ সরায় |
| `git stash drop` | স্ট্যাশ ডিলিট | `git stash drop stash@{0}` |
| `git stash clear` | সব স্ট্যাশ ডিলিট | সাবধান! |

---

### 🔄 **আনডু (Undo Changes)**

| Command | Description | Risk Level |
|---------|-------------|------------|
| `git checkout -- [file]` | ফাইলের পরিবর্তন বাতিল | ⚡ Low |
| `git reset HEAD [file]` | আনস্টেজ | ⚡ Low |
| `git reset --soft HEAD~1` | কমিট আনডু (পরিবর্তন রাখে) | ⚡⚡ Medium |
| `git reset --hard HEAD~1` | কমিট+পরিবর্তন মুছে ফেলে | ⚡⚡⚡ High |
| `git revert HEAD` | নতুন কমিট দিয়ে আনডু | ⚡ Safe |
| `git revert [commit-hash]` | নির্দিষ্ট কমিট আনডু | `git revert abc123` |

---

### 🤝 **কনফ্লিক্ট রেজুলেশন (Conflict Resolution)**

```bash
# ১. মার্জ করার চেষ্টা করুন
git merge dev

# ২. কনফ্লিক্ট দেখা গেলে ফাইল এডিট করুন
# ফাইলের মধ্যে <<<<<<<, =======, >>>>>>> চিহ্ন দেখতে পাবেন

# ৩. ঠিক করার পর
git add [fixed-files]

# ৪. কমিট করুন
git commit -m "Merge conflict resolved"
```

---

### 🔍 **ইনফো ও লগ (Information & Logs)**

| Command | Description | Example |
|---------|-------------|---------|
| `git log --oneline` | সংক্ষিপ্ত লগ | এক লাইনে ইতিহাস |
| `git log --graph` | গ্রাফসহ লগ | ব্রাঞ্চ দেখা যায় |
| `git log -p [file]` | ফাইলের পরিবর্তন ইতিহাস | `git log -p index.html` |
| `git blame [file]` | কে কী লিখেছে | `git blame app.js` |
| `git show [commit]` | কমিটের বিস্তারিত | `git show abc123` |

---

### 🎯 **GitHub/GitLab স্পেসিফিক**

| Feature | Description | Use Case |
|---------|-------------|----------|
| **Fork** | অন্যের রিপো কপি নিজের অ্যাকাউন্টে | ওপেন সোর্স কন্ট্রিবিউট করতে |
| **Pull Request (PR)** | পরিবর্তন মার্জের অনুরোধ | কোড রিভিউর জন্য |
| **Issues** | বাগ/ফিচার ট্র্যাকার | সমস্যা রিপোর্ট |
| **Projects** | কানবান বোর্ড | টাস্ক ম্যানেজমেন্ট |
| **Wiki** | ডকুমেন্টেশন | প্রকল্পের ডক্স |
| **Actions** | CI/CD | অটোমেটিক টেস্ট/ডেপ্লয় |
| **Gist** | কোড স্নিপেট | ছোট কোড শেয়ার |

---

### 🎨 **উন্নত কমান্ড (Advanced)**

| Command | Description | Example |
|---------|-------------|---------|
| `git rebase [branch]` | রিবেস করুন | `git rebase main` |
| `git cherry-pick [commit]` | নির্দিষ্ট কমিট নিয়ে আসে | `git cherry-pick abc123` |
| `git bisect` | বাগ খুঁজে বের করে | `git bisect start` |
| `git clean -fd` | আনট্র্যাকড ফাইল ডিলিট | সাবধান! |
| `git reflog` | সব কার্যক্রমের ইতিহাস | হারানো কমিট ফিরে পেতে |

---

### ⚠️ **গুরুত্বপূর্ণ টিপস**

1. **কমিট মেসেজ সবসময় অর্থপূর্ণ লিখুন**: `Fixed bug` না লিখে `Fix login validation error` লিখুন
2. **`--hard` ব্যবহারে সাবধান**: স্থায়ীভাবে ডাটা হারাতে পারেন
3. **পুলের আগে স্ট্যাটাস চেক করুন**: অপ্রত্যাশিত মার্জ এড়াতে
4. **নিয়মিত পুশ করুন**: কাজ হারানোর ভয় নেই
5. **.gitignore ব্যবহার করুন**: অপ্রয়োজনীয় ফাইল রিমোটে যেতে দেবেন না

---

### 📁 **.gitignore টেমপ্লেট**

```gitignore
# Dependencies
node_modules/
vendor/

# Build files
dist/
build/
*.exe

# IDE files
.vscode/
.idea/
*.swp

# Environment
.env
.env.local

# OS files
.DS_Store
Thumbs.db
```

---

### 🏆 **GitHub প্রোফাইল টিপস**

- **README.md** প্রোফাইলে রাখুন (username রিপোজিটরি)
- **গিট ইতিহাস** পরিষ্কার রাখুন
- **কন্ট্রিবিউশন গ্রাফ** সবুজ রাখতে নিয়মিত কমিট করুন
- **ওপেন সোর্সে কন্ট্রিবিউট** করুন

---

**✨ মনে রাখবেন: `git help [command]` যেকোনো কমান্ডের হেল্প দেখায়!**

**Happy Coding! 🚀**