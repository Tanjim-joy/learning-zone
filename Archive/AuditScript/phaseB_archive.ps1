$root = 'e:\Ply_ground\Learing Zone Notes'
$logPath = 'C:\Users\WALTON\AppData\Local\Temp\lz-audit\phaseB_log.txt'
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

# =============== PHASE B : archive junk ===============
$b = @(
    'Csharp-Work/C# Project|Archive/Duplicates/C# Project',
    'Csharp-Work/1264623.zip|Archive/Duplicates/1264623.zip',
    'Csharp-Work/forloo_whileloop/forloo_whileloop|Archive/Duplicates/forloo_whileloop-nested',
    'Csharp-Work/forloo_whileloop/for loop|Archive/Duplicates/forloo_whileloop-for-loop-copy',
    'Csharp-Work/tryCatch|Archive/Broken-Samples/tryCatch',
    'Csharp-Work/TryCatchC|Archive/Broken-Samples/TryCatchC',
    'interview-preparation/PrimeNumber|Archive/Broken-Samples/PrimeNumber',
    'Csharp-Work/rectangle|Archive/Empty-Experiments/rectangle',
    'Csharp-Work/Rectangle1|Archive/Empty-Experiments/Rectangle1',
    'Csharp-Work/lopptricks|Archive/Empty-Experiments/lopptricks',
    'Csharp-Work/Evidance|Archive/Empty-Experiments/Evidance',
    'Csharp-Work/age claculator|Archive/Empty-Dirs/age claculator',
    'Csharp-Work/tan|Archive/Empty-Dirs/tan',
    'Csharp-Work/test05|Archive/Empty-Dirs/test05',
    'Csharp-Work/gyfytd|Archive/Empty-Dirs/gyfytd',
    '%V%|Archive/Junk-Project/%V%',
    'LeetCode C Sharp Problem/LeetCode C Sharp Problem/189.RotateArray|Archive/LeetCode-Duplicates/189.RotateArray',
    'LeetCode C Sharp Problem/LeetCode C Sharp Problem/242.ValidAnagram|Archive/LeetCode-Duplicates/242.ValidAnagram'
)
foreach ($m in $b) {
    $p = $m.Split('|')
    DoMove $p[0] $p[1]
}

$content = [string]::Join([char]13 + [char]10, $script:log)
[System.IO.File]::WriteAllText($logPath, $content, [System.Text.Encoding]::UTF8)
Write-Host ('total moves: ' + $script:log.Count)
Write-Host '=== issues ==='
$script:log | Where-Object { $_ -match '^(FAIL|ERR|SKIP)' } | ForEach-Object { Write-Host $_ }