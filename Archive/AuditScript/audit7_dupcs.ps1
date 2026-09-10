$root = 'e:\Ply_ground\Learing Zone Notes'
$files = Get-ChildItem -LiteralPath $root -Recurse -Force -File | Where-Object {
    $_.FullName -notlike '*\.git\*' -and $_.FullName -notlike '*\bin\*' -and $_.FullName -notlike '*\obj\*' -and $_.FullName -notlike '*\.vs\*' -and $_.Extension -in '.cs','.md','.go','.html','.js'
}
Write-Host ('total candidates: ' + $files.Count)
$dup = @{}
$marks = @{}
foreach ($f in $files) {
    $h = (Get-FileHash -LiteralPath $f.FullName -Algorithm SHA256).Hash
    if (-not $marks.ContainsKey($h)) { $marks[$h] = @($f.FullName) } else { $marks[$h] += ,$f.FullName }
}
$out = @()
foreach ($h in $marks.Keys) {
    $paths = $marks[$h]
    if ($paths.Count -gt 1) {
        $rel = $paths | ForEach-Object { $_.Replace($root,'') }
        $out += ('HASH ' + $h.Substring(0,12) + '  x' + $paths.Count)
        $rel | ForEach-Object { $out += ('    ' + $_) }
        $out += '---'
    }
}
$content = [string]::Join([char]13 + [char]10, $out)
[System.IO.File]::WriteAllText('C:\Users\WALTON\AppData\Local\Temp\lz-audit\out7_dupcs.txt', $content, [System.Text.Encoding]::UTF8)
Write-Host ('duplicate groups: ' + [math]::Floor(($out.Count+1)/3))