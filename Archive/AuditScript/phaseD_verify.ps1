$root = 'e:\Ply_ground\Learing Zone Notes'
Set-Location $root

& git add -A 2>&1 | Out-String | Write-Host

Write-Host '=== STAGED FILES COUNT ==='
$staged = @(git diff --cached --name-only)
Write-Host ('staged: ' + $staged.Count)

Write-Host '=== STAGED JUNK (bin/obj/.vs/exe/dll/pdb/etc) ==='
$junk = $staged | Where-Object { $_ -match '(^|/)(bin|obj|\.vs)/|\.(exe|dll|pdb|suo|cache|vsidx|a|so|dylib|user|ide|mpack|sqlite)$' }
Write-Host ('junk staged: ' + $junk.Count)
$junk | Select-Object -First 20

Write-Host '=== STAGED SAMPLE (first 40) ==='
$staged | Select-Object -First 40

Write-Host '=== UNTRACKED REMAINING (should be empty or tiny) ==='
$untracked = @(git ls-files --others --exclude-standard)
Write-Host ('untracked: ' + $untracked.Count)
$untracked | Select-Object -First 20

$content = [string]::Join([char]13 + [char]10, $staged)
[System.IO.File]::WriteAllText('C:\Users\WALTON\AppData\Local\Temp\lz-audit\staged_after.txt', $content, [System.Text.Encoding]::UTF8)