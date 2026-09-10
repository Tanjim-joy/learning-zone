$root = 'e:\Ply_ground\Learing Zone Notes'
$logPath = 'C:\Users\WALTON\AppData\Local\Temp\lz-audit\phaseC2_log.txt'
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

# =============== PHASE C part 2 : Csharp-Work categorization ===============
$c2 = @(
    'Csharp-Work/000022222|01-CSharp/Basics/000022222',
    'Csharp-Work/11|01-CSharp/Basics/11',
    'Csharp-Work/1264623_01|01-CSharp/Basics/1264623_01',
    'Csharp-Work/1264623_2|01-CSharp/Basics/1264623_2',
    'Csharp-Work/swap|01-CSharp/Basics/swap',
    'Csharp-Work/vari|01-CSharp/Basics/vari',
    'Csharp-Work/varible|01-CSharp/Basics/varible',
    'Csharp-Work/item1variable|01-CSharp/Basics/item1variable',
    'Csharp-Work/clasAges|01-CSharp/Basics/clasAges',
    'Csharp-Work/class7.2|01-CSharp/Basics/class7.2',
    'Csharp-Work/Class9|01-CSharp/Basics/Class9',
    'Csharp-Work/class_|01-CSharp/Basics/class_',
    'Csharp-Work/Class_05WORKOUT|01-CSharp/Basics/Class_05WORKOUT',
    'Csharp-Work/class_06_class_work|01-CSharp/Basics/class_06_class_work',
    'Csharp-Work/class05workout1|01-CSharp/Basics/class05workout1',
    'Csharp-Work/class_6_03|01-CSharp/Basics/class_6_03',
    'Csharp-Work/class14|01-CSharp/Basics/class14',
    'Csharp-Work/class14classwork|01-CSharp/Basics/class14classwork',
    'Csharp-Work/ClassWork7date|01-CSharp/Basics/ClassWork7date',
    'Csharp-Work/classlran|01-CSharp/Basics/classlran',
    'Csharp-Work/ConsoleApp1|01-CSharp/Basics/ConsoleApp1',
    'Csharp-Work/ConsoleApp2|01-CSharp/Basics/ConsoleApp2',
    'Csharp-Work/divisonnumbe|01-CSharp/Basics/divisonnumbe',
    'Csharp-Work/hlwwrold|01-CSharp/Basics/hlwwrold',
    'Csharp-Work/hworld|01-CSharp/Basics/hworld',
    'Csharp-Work/take user input|01-CSharp/Basics/take user input',
    'Csharp-Work/userinput|01-CSharp/Basics/userinput',
    'Csharp-Work/uri|01-CSharp/Basics/uri',
    'Csharp-Work/taksjk|01-CSharp/Basics/taksjk',
    'Csharp-Work/ttttttt|01-CSharp/Basics/ttttttt',
    'Csharp-Work/testtttttskills|01-CSharp/Basics/testtttttskills',
    'Csharp-Work/test_ioop|01-CSharp/Basics/test_ioop',
    'Csharp-Work/try4141451|01-CSharp/Basics/try4141451',
    'Csharp-Work/Task|01-CSharp/Basics/Task',
    'Csharp-Work/Class_21_M3_02|01-CSharp/Basics/Class_21_M3_02',
    'Csharp-Work/clw02|01-CSharp/Basics/clw02',
    'Csharp-Work/forl|01-CSharp/Loops/forl',
    'Csharp-Work/forloops1|01-CSharp/Loops/forloops1',
    'Csharp-Work/forloopstring|01-CSharp/Loops/forloopstring',
    'Csharp-Work/forloo_whileloop|01-CSharp/Loops/forloo_whileloop',
    'Csharp-Work/loops|01-CSharp/Loops/loops',
    'Csharp-Work/loopsuserinput|01-CSharp/Loops/loopsuserinput',
    'Csharp-Work/looptest|01-CSharp/Loops/looptest',
    'Csharp-Work/loop|01-CSharp/Loops/loop',
    'Csharp-Work/reloop|01-CSharp/Loops/reloop',
    'Csharp-Work/whileloops|01-CSharp/Loops/whileloops',
    'Csharp-Work/hwforloops|01-CSharp/Loops/hwforloops',
    'Csharp-Work/lllooopppp|01-CSharp/Loops/lllooopppp'
)
foreach ($m in $c2) {
    $p = $m.Split('|')
    DoMove $p[0] $p[1]
}

$content = [string]::Join([char]13 + [char]10, $script:log)
[System.IO.File]::WriteAllText($logPath, $content, [System.Text.Encoding]::UTF8)
Write-Host ('c2 total: ' + $script:log.Count)
Write-Host '=== issues ==='
$script:log | Where-Object { $_ -match '^(FAIL|ERR|SKIP)' } | ForEach-Object { Write-Host $_ }