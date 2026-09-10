$root = 'e:\Ply_ground\Learing Zone Notes'
$out = @()
$files = Get-ChildItem -LiteralPath $root -Recurse -Force -File | Where-Object {
    $_.FullName -notlike '*\.git\*' -and $_.FullName -notlike '*\bin\*' -and $_.FullName -notlike '*\obj\*' -and $_.FullName -notlike '*\.vs\*' -and $_.Name -ne 'AssemblyInfo.cs'
}

Write-Host ('Total non-build files: ' + $files.Count)

# same basename across different folders
$out += '=== SAME FILENAME ACROSS DIFFERENT PATHS ==='
$g = $files | Group-Object { $_.Name.ToLower() } | Where-Object { $_.Count -gt 1 }
foreach ($grp in $g) {
    $paths = $grp.Group | ForEach-Object { $_.FullName.Replace($root,'') }
    $out += ('NAME: ' + $grp.Name + '  x' + $grp.Count)
    $paths | ForEach-Object { $out += ('      ' + $_) }
    $out += '---'
}

# exact duplicates by content hash among source-ish text files
$out += ''
$out += '=== EXACT CONTENT DUPLICATES (SHA-256 on .cs/.md/.txt/.sln/.csproj/.config) ==='
$text = $files | Where-Object { $_.Extension -in '.cs','.md','.txt','.sln','.csproj','.config' -and $_.Length -lt 2000000 }
Write-Host ('hashing ' + $text.Count + ' text files')
$h = @{}
foreach ($f in $text) {
    $h[$f.FullName] = (Get-FileHash -LiteralPath $f.FullName -Algorithm SHA256).Hash
}
$dup = @{}
foreach ($f in $text) {
    $key = $h[$f.FullName]
    if ($dup.ContainsKey($key)) { $dup[$key] = $dup[$key] + '|' + $f.FullName } else { $dup[$key] = $f.FullName }
}
foreach ($k in $dup.Keys) {
    if (($dup[$k] -split '\|').Count -gt 1) {
        $out += 'HASH ' + $k.Substring(0,12)
        ($dup[$k] -split '\|') | ForEach-Object { $out += ('      ' + $_.Replace($root,'')) }
        $out += '---'
    }
}

$content = [string]::Join([char]13 + [char]10, $out)
[System.IO.File]::WriteAllText('C:\Users\WALTON\AppData\Local\Temp\lz-audit\out4_dupes.txt', $content, [System.Text.Encoding]::UTF8)
Write-Host ('DONE ' + $out.Count + ' lines')