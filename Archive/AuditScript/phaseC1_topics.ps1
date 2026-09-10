$root = 'e:\Ply_ground\Learing Zone Notes'
$logPath = 'C:\Users\WALTON\AppData\Local\Temp\lz-audit\phaseC_log.txt'
$script:log = @()

function DoMove($relSrc, $relDst) {
    $src = $root + '\' + $relSrc
    $dst = $root + '\' + $relDst
    if (-not (Test-Path -LiteralPath $src)) { $script:log += "SKIP-NOTFOUND|$relSrc"; return }
    $dstParent = Split-Path -Path $dst -Parent
    if (-not (Test-Path -LiteralPath $dstParent)) { New-Item -ItemType Directory -Path $dstParent -Force | Out-Null }
    if (Test-Path -LiteralPath $dst) { $script:log += "ERR-DEST-EXISTS|$relSrc => $relDst"; return }
    try {
        Move-Item -LiteralPath $src -Destination $dst
        $script:log += "OK|$relSrc => $relDst"
    } catch {
        $script:log += ("FAIL|$relSrc => $relDst|" + $_.Exception.Message)
    }
}

# =============== PHASE C part 1 : notes + topic folders ===============
$c1 = @(
    'docker_tutorial_bangla.md|07-Docker-DevOps/docker_tutorial_bangla.md',
    'Git.md|08-Git/Git.md',
    'WPF-Tutorial.md|02-WPF/WPF-Tutorial.md',
    'Algorithm_learing.md|03-Algorithms/Algorithm_learing.md',
    'Go-Lang|06-Go/Go-Lang',
    'interview-preparation|05-Interview-Prep/interview-preparation',
    'csharp-linq-practice|01-CSharp/LINQ/csharp-linq-practice',
    'LeetCode C Sharp Problem/ReadOnlyCMD|04-LeetCode/ReadOnlyCMD',
    'LeetCode C Sharp Problem/LeetCode C Sharp Problem|04-LeetCode/LeetCode-CSharp',
    'Algorithms Notes for Professionals/Algorithms Notes for Professionals|03-Algorithms/Algorithms-Notes',
    'README.md|Archive/Old-README.md'
)
foreach ($m in $c1) {
    $p = $m.Split('|')
    DoMove $p[0] $p[1]
}

$content = [string]::Join([char]13 + [char]10, $script:log)
[System.IO.File]::WriteAllText($logPath, $content, [System.Text.Encoding]::UTF8)
Write-Host ('c1 total: ' + $script:log.Count)
Write-Host '=== issues ==='
$script:log | Where-Object { $_ -match '^(FAIL|ERR|SKIP)' } | ForEach-Object { Write-Host $_ }