$root = 'e:\Ply_ground\Learing Zone Notes'
$out = @()

$out += '=== ANOMALY / BINARY / HEAVY FILES (excluding .git, bin, obj) ==='
$files = Get-ChildItem -LiteralPath $root -Recurse -Force -File | Where-Object {
    $_.FullName -notlike '*\.git\*' -and $_.FullName -notlike '*\bin\*' -and $_.FullName -notlike '*\obj\*' -and $_.FullName -notlike '*\.vs\*'
}
$want = $files | Where-Object { $_.Extension -in '.a', '.so', '.dylib', '.ide', '.ide-wal', '.ide-shm', '.db', '.db-wal', '.db-shm', '.sqlite', '.v2', '.pdf', '.zip', '.exe', '.dll', '.pdb', '.suo', '.testlog', '.lock', '.settings', '.user', '.mpack', '.resources', '.manifest', '.Up2Date', '.vsidx', '.bin' }
foreach ($f in $want) {
    $out += ($f.FullName.Replace($root, '') + '|' + $f.Length)
}

$out += ''
$out += '=== FILES > 1 MB (excluding .git/bin/obj) ==='
$big = $files | Where-Object { $_.Length -gt 1000000 }
foreach ($f in ($big | Sort-Object -Property Length -Descending)) {
    $mb = [math]::Round($f.Length/1MB, 2)
    $out += ($f.FullName.Replace($root, '') + '|' + $mb + ' MB')
}

$out += ''
$out += '=== .git dir size and status ==='
$content = [string]::Join([char]13 + [char]10, $out)
[System.IO.File]::WriteAllText('C:\Users\WALTON\AppData\Local\Temp\lz-audit\out6_anomaly.txt', $content, [System.Text.Encoding]::UTF8)
Write-Host 'DONE'