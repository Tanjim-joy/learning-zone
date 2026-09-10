$root = 'e:\Ply_ground\Learing Zone Notes'
$logPath = 'C:\Users\WALTON\AppData\Local\Temp\lz-audit\phaseC3_log.txt'
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

# =============== PHASE C part 3 : methods/OOP/LINQ/IO/Async/Samples/WPF ===============
$c3 = @(
    'Csharp-Work/methods|01-CSharp/Methods/methods',
    'Csharp-Work/methods1|01-CSharp/Methods/methods1',
    'Csharp-Work/abstract|01-CSharp/OOP/abstract',
    'Csharp-Work/ccccls|01-CSharp/OOP/ccccls',
    'Csharp-Work/class13works|01-CSharp/OOP/class13works',
    'Csharp-Work/class16insterface|01-CSharp/OOP/class16insterface',
    'Csharp-Work/classoverloads|01-CSharp/OOP/classoverloads',
    'Csharp-Work/classs14worksss|01-CSharp/OOP/classs14worksss',
    'Csharp-Work/classss16work|01-CSharp/OOP/classss16work',
    'Csharp-Work/classwork|01-CSharp/OOP/classwork',
    'Csharp-Work/ClassWork14|01-CSharp/OOP/ClassWork14',
    'Csharp-Work/classworksssss|01-CSharp/OOP/classworksssss',
    'Csharp-Work/ConstructorFunction|01-CSharp/OOP/ConstructorFunction',
    'Csharp-Work/emp|01-CSharp/OOP/emp',
    'Csharp-Work/EmpolyeeTable|01-CSharp/OOP/EmpolyeeTable',
    'Csharp-Work/Generic|01-CSharp/OOP/Generic',
    'Csharp-Work/Getters_And_Setters|01-CSharp/OOP/Getters_And_Setters',
    'Csharp-Work/NewWorks1|01-CSharp/OOP/NewWorks1',
    'Csharp-Work/cltask1|01-CSharp/OOP/cltask1',
    'Csharp-Work/trainee|01-CSharp/OOP/trainee',
    'Csharp-Work/Class_20_Exc|01-CSharp/OOP/Class_20_Exc',
    'Csharp-Work/Product|01-CSharp/LINQ/Product',
    'Csharp-Work/Evidance11|01-CSharp/LINQ/Evidance11',
    'Csharp-Work/readlinetextfile|01-CSharp/File-IO/readlinetextfile',
    'Csharp-Work/readstream|01-CSharp/File-IO/readstream',
    'Csharp-Work/readtextfileclass05|01-CSharp/File-IO/readtextfileclass05',
    'Csharp-Work/Async|01-CSharp/Async/Async',
    'Csharp-Work/Game|01-CSharp/SampleProjects/Game',
    'Csharp-Work/1264623|01-CSharp/SampleProjects/1264623-EvidanceXm',
    'Csharp-Work/vehicle|01-CSharp/SampleProjects/vehicle',
    'Csharp-Work/class13|01-CSharp/SampleProjects/class13',
    'Csharp-Work/Encapsulation form|02-WPF/Samples/Encapsulation-form',
    'Csharp-Work/Class_22_m3|02-WPF/Samples/Class_22_m3'
)
foreach ($m in $c3) {
    $p = $m.Split('|')
    DoMove $p[0] $p[1]
}

# =============== empty shells -> Archive ===============
$shells = @(
    'Csharp-Work|Archive/Empty-Dirs/Csharp-Work',
    'LeetCode C Sharp Problem|Archive/Empty-Dirs/LeetCode C Sharp Problem',
    'Algorithms Notes for Professionals|Archive/Empty-Dirs/Algorithms Notes for Professionals'
)
foreach ($m in $shells) {
    $p = $m.Split('|')
    DoMove $p[0] $p[1]
}

$content = [string]::Join([char]13 + [char]10, $script:log)
[System.IO.File]::WriteAllText($logPath, $content, [System.Text.Encoding]::UTF8)
Write-Host ('c3 total: ' + $script:log.Count)
Write-Host '=== issues ==='
$script:log | Where-Object { $_ -match '^(FAIL|ERR|SKIP)' } | ForEach-Object { Write-Host $_ }