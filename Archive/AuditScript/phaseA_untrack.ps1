$root = 'e:\Ply_ground\Learing Zone Notes'
Set-Location $root

# Collect all dirs named bin/obj/.vs (skip .git)
$dirs = Get-ChildItem -LiteralPath $root -Recurse -Force -Directory | Where-Object {
    $_.Name -in @('bin','obj','.vs') -and $_.FullName -notlike '*\.git\*'
}
Write-Host ('dirs-to-untrack: ' + $dirs.Count)

$paths = $dirs | ForEach-Object { $_.FullName.Replace('\','/') }

for ($i = 0; $i -lt $paths.Count; $i += 30) {
    $end = [Math]::Min($i + 30, $paths.Count)
    $chunk = $paths[$i..($end - 1)]
    $args = @('rm','-r','--cached','--ignore-unmatch','--') + $chunk
    & git $args 2>&1 | Out-Null
}
Write-Host 'phase1 dir-untrack done'

# Safety pass: loose build-type files not under bin/obj/.vs
$tracked = @(git ls-files)
Write-Host ('tracked-after-dir-untrack: ' + $tracked.Count)
$loose = $tracked | Where-Object { $_ -match '\.(exe|dll|pdb|suo|vsidx|cache|a|so|dylib|user|ide|mpack)$' }
Write-Host ('loose-junk: ' + $loose.Count)

for ($i = 0; $i -lt $loose.Count; $i += 60) {
    $end = [Math]::Min($i + 60, $loose.Count)
    $chunk = $loose[$i..($end - 1)]
    $args = @('rm','--cached','--ignore-unmatch','--') + $chunk
    & git $args 2>&1 | Out-Null
}
Write-Host 'phase1 loose-untrack done'

$remaining = @(git ls-files)
Write-Host ('tracked-final: ' + $remaining.Count)
Write-Host '=== sample remaining ==='
$remaining | Select-Object -First 40